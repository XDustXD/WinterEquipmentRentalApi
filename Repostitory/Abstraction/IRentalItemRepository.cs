using WinterEquipmentRentalApi.Models;

namespace WinterEquipmentRentalApi.Repostitory.Abstraction;

public interface IRentalItemRepository : IRepository<RentalItem>
{
    Task<RentalItem?> GetByName(string name);
}
