using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;

namespace WinterEquipmentRentalApi.Repostitory.Implementation;

public class RentalReturnRepository(RentDbContext context, IMapper mapper) : IRentalReturnRepository
{
    public async Task<string> Add(RentalReturn entity)
    {
        context.RentalReturns.Add(entity);

        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<RentalReturn>> GetAll()
    {
        return await context.RentalReturns.ToListAsync();
    }

    public async Task<RentalReturn?> GetById(string id)
    {
        return await context.RentalReturns.FindAsync(id);
    }

    public IEnumerable<RentalReturn> GetRentalReturnsByClientId(string clientId)
    {
        return context.RentalReturns
            .Include(x => x.Rental)
            .Where(x => x.Rental.ClientID == clientId);
    }

    public async Task<bool> Remove(string id)
    {
        var item = await context.RentalReturns.FindAsync(id);

        if (item == null) return false;

        context.RentalReturns.Remove(item);

        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Update(RentalReturn entity)
    {
        var rentalReturn = await context.RentalReturns.FindAsync(entity.Id);

        if (rentalReturn == null) return false;

        mapper.Map(entity, rentalReturn);

        await context.SaveChangesAsync();

        return true;
    }
}