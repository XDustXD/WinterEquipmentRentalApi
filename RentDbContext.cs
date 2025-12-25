using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi.Models;

namespace WinterEquipmentRentalApi;

public class RentDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<RentalItem> RentalItems { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalReturn> RentalReturns { get; set; }
}
