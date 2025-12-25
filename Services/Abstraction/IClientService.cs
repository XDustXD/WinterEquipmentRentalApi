using WinterEquipmentRentalApi.Dto.Client;

namespace WinterEquipmentRentalApi.Services.Abstraction;

public interface IClientService
{
    Task<string> Add(CreateClientDto entity);
    Task<IEnumerable<GetClientDto>> GetAll();
    Task<GetClientDto?> GetById(string id);
    Task<GetClientDto?> GetByPhoneNumber(string phoneNumber);
    Task Update(string id, UpdateClientDto entity);
    Task Remove(string id);
}
