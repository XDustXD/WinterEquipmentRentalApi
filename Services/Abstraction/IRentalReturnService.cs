using WinterEquipmentRentalApi.Dto.RentalReturn;

namespace WinterEquipmentRentalApi.Services.Abstraction;

public interface IRentalReturnService
{
    Task<string> Add(string rentalId, CreateRentalReturnDto dto);
    Task<IEnumerable<GetRentalReturnDto>> GetAll();
    Task<GetRentalReturnDto?> GetById(string id);
    Task<IEnumerable<GetRentalReturnDto>> GetByClientId(string clientId);
    Task Update(string id, CreateRentalReturnDto dto);
    Task Remove(string id);
}
