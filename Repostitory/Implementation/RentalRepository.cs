using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;

namespace WinterEquipmentRentalApi.Repostitory.Implementation;

public class RentalRepository(RentDbContext context, IMapper mapper) : IRentalRepository
{
    public async Task<string> Add(Rental entity)
    {
        context.Rentals.Add(entity);

        await context.SaveChangesAsync();

        return entity.Id;
    }

    public IEnumerable<Rental?> GetActiveRentals()
    {
        return context.Rentals
            .Where(r => r.RentalReturn == null);
    }

    public async Task<IEnumerable<Rental>> GetAll()
    {
        return await context.Rentals.ToListAsync();
    }

    public async Task<Rental?> GetById(string id)
    {
        return await context.Rentals
            .Include(r => r.RentalItems)
            .Include(r => r.RentalReturn)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public Rental? GetRentalByClientId(string clientId)
    {
        return context.Rentals.FirstOrDefault(r => r.ClientID == clientId);
    }

    public async Task<bool> IsActiveRental(string rentalId)
    {
        var rental = await context.Rentals.FindAsync(rentalId);

        if (rental == null) return false;

        return rental?.RentalReturn == null;
    }

    public async Task<bool> Remove(string id)
    {
        var item = await context.Rentals.FindAsync(id);

        if (item == null) return false;

        context.Rentals.Remove(item);

        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Update(Rental entity)
    {
        var rental = await context.Rentals.FindAsync(entity.Id);

        if (rental == null) return false;

        mapper.Map(entity, rental);

        await context.SaveChangesAsync();

        return true;
    }
}
