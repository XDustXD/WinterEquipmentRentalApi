using AutoMapper;
using WinterEquipmentRentalApi.Dto.RentalItem;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;
using WinterEquipmentRentalApi.Services.Abstraction;

namespace WinterEquipmentRentalApi.Services.Implementation;

public class RentalItemService(IMapper mapper, IRentalItemRepository itemRepo) : IRentalItemService
{
    public async Task<string> Add(CreateRentalItem entity)
    {
        var rentalItem = mapper.Map<CreateRentalItem, RentalItem>(entity);

        return await itemRepo.Add(rentalItem);
    }

    public async Task Remove(string id)
    {
        var ok = await itemRepo.Remove(id);

        if (!ok) throw new KeyNotFoundException("RentalItem not found");
    }

    public async Task<IEnumerable<GetRentalItemDto>> GetAll()
    {
        var rentalItems = await itemRepo.GetAll();

        var rentalItemDtos = rentalItems
            .Select(item => mapper.Map<RentalItem, GetRentalItemDto>(item));

        return rentalItemDtos;
    }

    public async Task<GetRentalItemDto> GetById(string id)
    {
        var rentalItem = await itemRepo.GetById(id)
            ?? throw new KeyNotFoundException("RentalItem not found");

        var rentalItemDto = mapper.Map<RentalItem, GetRentalItemDto>(rentalItem);

        return rentalItemDto;
    }

    public async Task<GetRentalItemDto> GetByName(string name)
    {
        var rentalItem = await itemRepo.GetByName(name) 
            ?? throw new KeyNotFoundException("RentalItem not found");

        var rentalItemDto = mapper.Map<RentalItem, GetRentalItemDto>(rentalItem);

        return rentalItemDto;
    }

    public async Task Update(string id, UpdateRentalItemDto entity)
    {
        var rentalItem = mapper.Map<UpdateRentalItemDto, RentalItem>(entity);
        rentalItem.Id = id;

        var ok = await itemRepo.Update(rentalItem);

        if (!ok) throw new KeyNotFoundException("RentalItem not found");
    }
}
