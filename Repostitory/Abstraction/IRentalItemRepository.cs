using WinterEquipmentRentalApi.Models;

namespace WinterEquipmentRentalApi.Repostitory.Abstraction;

public interface IRentalItemRepository
{
    Task<RentalItem> GetByName(string name);
}
