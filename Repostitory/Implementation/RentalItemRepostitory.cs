using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;

namespace WinterEquipmentRentalApi.Repostitory.Implementation;

public class RentalItemRepostitory(RentDbContext context) : IRentalItemRepository
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
        return await context.RentalItems.FindAsync(id) 
            ?? throw new Exception("Cannot find rental item");
    }

    public async Task<RentalItem> GetByName(string name)
    {
        return await context.RentalItems.FirstAsync(x => x.Name == name);
    }

    public async Task Remove(string id)
    {
        var item = await context.RentalItems.FindAsync(id)
            ?? throw new Exception("Cannot find rental item");

        context.RentalItems.Remove(item);
    }

    public async Task Update(RentalItem entity)
    {
        var item = await context.RentalItems.FindAsync(entity.Id)
            ?? throw new Exception("Cannot find rental item");

        item.Id = entity.Id;
        item.Name = entity.Name;
        item.IsAvailable = entity.IsAvailable;
        item.Price = entity.Price;

        await context.SaveChangesAsync();
    }
}
