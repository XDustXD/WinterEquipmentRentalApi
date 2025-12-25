using System;
using WinterEquipmentRentalApi.Models;

namespace WinterEquipmentRentalApi.Repostitory.Abstraction;

public interface IRentalReturnRepository : IRepository<RentalReturn>
{
    IEnumerable<RentalReturn?> GetRentalReturnsByClientId(string clientId);
}
