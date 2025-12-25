using System;
using WinterEquipmentRentalApi.Dto.RentalItem;

namespace WinterEquipmentRentalApi.Services.Abstraction;

public interface IRentalItemService
{
    Task<GetRentalItemDto> GetByName(string name);
    Task<GetRentalItemDto> GetById(string id);
    Task<IEnumerable<GetRentalItemDto>> GetAll();
    Task<string> Add(CreateRentalItem entity);
    Task Update(string id, UpdateRentalItemDto entity);
    Task Remove(string id);
}
