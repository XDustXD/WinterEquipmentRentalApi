using System;
using WinterEquipmentRentalApi.Models;

namespace WinterEquipmentRentalApi.Repostitory.Abstraction;

public interface IRentalRepository : IRepository<Rental>
{
    Rental? GetRentalByClientId(string clientId);
    Task<bool> IsActiveRental(string rentalId);
    IEnumerable<Rental?> GetActiveRentals();
}
