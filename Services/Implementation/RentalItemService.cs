using WinterEquipmentRentalApi.Dto.RentalItem;
using WinterEquipmentRentalApi.Repostitory.Abstraction;
using WinterEquipmentRentalApi.Services.Interfaces;

namespace WinterEquipmentRentalApi.Services.Implementation;

public class RentalItemService(IRentalItemRepository itemRepo) : IRentalItemService
{
    public Task<string> Add(CreateRentalItem entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetRentalItemDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<GetRentalItemDto?> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<GetRentalItemDto> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateRentalItemDto entity)
    {
        throw new NotImplementedException();
    }
}
