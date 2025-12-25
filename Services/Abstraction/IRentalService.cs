using WinterEquipmentRentalApi.Dto.Rental;
using WinterEquipmentRentalApi.Dto.RentalReturn;

namespace WinterEquipmentRentalApi.Services.Abstraction;

public interface IRentalService
{
    Task<string> Add(CreateRentalDto entity);
    Task<IEnumerable<GetRentalDto>> GetAll();
    Task<GetRentalDto?> GetById(string id);
    Task Update(string id, UpdateRentalDto entity);
    Task Remove(string id);
    Task<string> EndRental(string id);
}
