using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;

namespace WinterEquipmentRentalApi.Repostitory.Implementation;

public class RentalRepository(RentDbContext context) : IRentalRepository
{
    public async Task<string> Add(Rental entity)
    {
        context.Rentals.Add(entity);

        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<Rental>> GetAll()
    {
        return await context.Rentals.ToListAsync();
    }

    public async Task<Rental?> GetById(string id)
    {
        return await context.Rentals.FindAsync(id)
                    ?? throw new Exception("Cannot find client");
    }

    public async Task Remove(string id)
    {
        var item = await context.Rentals.FindAsync(id)
            ?? throw new Exception("Cannot find client");

        context.Rentals.Remove(item);
    }

    public async Task Update(Rental entity)
    {
        var rental = await context.Rentals.FindAsync(entity.Id)
            ?? throw new Exception("Cannot find client");

        rental.Id = entity.Id;
        rental.RentHours = entity.RentHours;
        rental.Cost = entity.Cost;
        rental.ClientID = entity.ClientID;

        await context.SaveChangesAsync();
    }
}
