using AutoMapper;
using WinterEquipmentRentalApi.Dto.RentalReturn;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;
using WinterEquipmentRentalApi.Services.Abstraction;

namespace WinterEquipmentRentalApi.Services.Implementation;

public class RentalReturnService(IMapper mapper, IRentalReturnRepository repo, IRentalRepository rentalRepo, IRentalItemRepository itemRepo) : IRentalReturnService
{
    public async Task<string> Add(string rentalId, CreateRentalReturnDto dto)
    {
        var isActive = await rentalRepo.IsActiveRental(rentalId);
        if (!isActive) throw new InvalidOperationException("Rental is already closed or does not exist");

        var rentalReturn = mapper.Map<CreateRentalReturnDto, RentalReturn>(dto);
        rentalReturn.RentalId = rentalId;

        var id = await repo.Add(rentalReturn);

        var rental = await rentalRepo.GetById(rentalId);
        if (rental != null)
        {
            foreach (var item in rental.RentalItems)
            {
                item.IsAvailable = true;
                var ok = await itemRepo.Update(item);
                if (!ok) throw new InvalidOperationException($"Failed to update RentalItem {item.Id}");
            }
        }

        return id;
    }

    public async Task<IEnumerable<GetRentalReturnDto>> GetAll()
    {
        var items = await repo.GetAll();
        return items.Select(x => mapper.Map<RentalReturn, GetRentalReturnDto>(x));
    }

    public async Task<GetRentalReturnDto?> GetById(string id)
    {
        var item = await repo.GetById(id) 
            ?? throw new KeyNotFoundException("RentalReturn not found");
        return mapper.Map<RentalReturn, GetRentalReturnDto>(item);
    }

    public async Task<IEnumerable<GetRentalReturnDto>> GetByClientId(string clientId)
    {
        var items = repo.GetRentalReturnsByClientId(clientId);
        return items.Select(x => mapper.Map<RentalReturn, GetRentalReturnDto>(x!));
    }

    public async Task Update(string id, CreateRentalReturnDto dto)
    {
        var entity = mapper.Map<CreateRentalReturnDto, RentalReturn>(dto);
        entity.Id = id;

        var ok = await repo.Update(entity);
        if (!ok) throw new KeyNotFoundException("RentalReturn not found");
    }

    public async Task Remove(string id)
    {
        
        var ok = await repo.Remove(id);
        if (!ok) throw new KeyNotFoundException("RentalReturn not found");
    }
}
