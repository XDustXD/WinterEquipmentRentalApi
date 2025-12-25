using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;

namespace WinterEquipmentRentalApi.Repostitory.Implementation;

public class RentalItemRepostitory(RentDbContext context, IMapper mapper) : IRentalItemRepository
{
    public async Task<string> Add(RentalItem entity)
    {
        context.RentalItems.Add(entity);

        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<RentalItem>> GetAll()
    {
        return await context.RentalItems.ToListAsync();
    }

    public async Task<RentalItem?> GetById(string id)
    {
        return await context.RentalItems.FindAsync(id);
    }

    public async Task<RentalItem?> GetByName(string name)
    {
        return await context.RentalItems.FirstAsync(x => x.Name == name);
    }

    public async Task<bool> Remove(string id)
    {
        var item = await context.RentalItems.FindAsync(id);

        if (item == null) return false;

        context.RentalItems.Remove(item);

        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Update(RentalItem entity)
    {
        var item = await context.RentalItems.FindAsync(entity.Id);

        if (item == null) return false;

        mapper.Map(entity, item);

        await context.SaveChangesAsync();
        
        return true;
    }
}
