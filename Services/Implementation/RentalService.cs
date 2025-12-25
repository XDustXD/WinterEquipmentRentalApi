using AutoMapper;
using WinterEquipmentRentalApi.Dto.Rental;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;
using WinterEquipmentRentalApi.Services.Abstraction;

namespace WinterEquipmentRentalApi.Services.Implementation;

public class RentalService(IMapper mapper, IRentalRepository rentalRepo, IRentalReturnRepository rentalReturnRepo,
    IClientRepostitory clientRepo, IRentalItemRepository itemRepo) : IRentalService
{
    public async Task<string> Add(CreateRentalDto entity)
    {
        var client = await clientRepo.GetById(entity.ClientId)
            ?? throw new KeyNotFoundException("Client not found");

        var rental = mapper.Map<CreateRentalDto, Rental>(entity);
        rental.ClientID = client.Id;
        rental.Client = client;
        rental.RentalItems = [];

        if (entity.RentalItemIds.Count == 0)
            throw new InvalidOperationException("At least one RentalItem must be specified");

        foreach (var itemId in entity.RentalItemIds)
        {
            var item = await itemRepo.GetById(itemId) ?? throw new KeyNotFoundException($"RentalItem {itemId} not found");

            if (!item.IsAvailable) throw new InvalidOperationException($"RentalItem {itemId} is not available");

            item.IsAvailable = false;
            var updated = await itemRepo.Update(item);
            if (!updated) throw new InvalidOperationException($"Failed to update RentalItem {itemId}");

            rental.RentalItems.Add(item);
        }

        rental.PricePerHour = rental.RentalItems.Sum(i => i.Price);

        return await rentalRepo.Add(rental);
    }

    public async Task<IEnumerable<GetRentalDto>> GetAll()
    {
        var rentals = await rentalRepo.GetAll();
        return rentals.Select(r => mapper.Map<Rental, GetRentalDto>(r));
    }

    public async Task<GetRentalDto?> GetById(string id)
    {
        var rental = await rentalRepo.GetById(id)
            ?? throw new KeyNotFoundException("Rental not found");

        return mapper.Map<Rental, GetRentalDto>(rental);
    }

    public async Task Update(string id, UpdateRentalDto entity)
    {
        var rental = mapper.Map<UpdateRentalDto, Rental>(entity);
        rental.Id = id;
        rental.RentalItems = [];

        foreach (var itemId in entity.RentalItemIds)
        {
            var item = await itemRepo.GetById(itemId) ?? throw new KeyNotFoundException($"RentalItem {itemId} not found");
            rental.RentalItems.Add(item);
        }

        rental.PricePerHour = rental.RentalItems.Sum(i => i.Price);

        var ok = await rentalRepo.Update(rental);
        if (!ok) throw new KeyNotFoundException("Rental not found");
    }

    public async Task Remove(string id)
    {
        if (await rentalRepo.IsActiveRental(id))
        {
            var rental = await rentalRepo.GetById(id);
            if (rental != null)
            {
                foreach (var item in rental.RentalItems)
                {
                    item.IsAvailable = true;
                    var okupdate = await itemRepo.Update(item);
                    if (!okupdate) throw new InvalidOperationException($"Failed to update RentalItem {item.Id}");
                }
            }
        }
        
        var ok = await rentalRepo.Remove(id);
        if (!ok) throw new KeyNotFoundException("Rental not found");
    }

    public async Task<string> EndRental(string id)
    {
        var isActive = await rentalRepo.IsActiveRental(id);
        if (!isActive) throw new InvalidOperationException("Rental is already closed or does not exist");

        var rentalReturn = new RentalReturn(){
            RentalId = id,
        };

        var rental = await rentalRepo.GetById(id);
        if (rental != null)
        {
            foreach (var item in rental.RentalItems)
            {
                item.IsAvailable = true;
                var ok = await itemRepo.Update(item);
                if (!ok) throw new InvalidOperationException($"Failed to update RentalItem {item.Id}");
            }
        }

        TimeSpan rentalDuration = DateTime.UtcNow - rental!.RentalDate;
        decimal hours = (decimal)rentalDuration.TotalHours;
        rentalReturn.Cost = hours * rental.PricePerHour;

        var returnId = await rentalReturnRepo.Add(rentalReturn);

        return returnId;
    }
}
