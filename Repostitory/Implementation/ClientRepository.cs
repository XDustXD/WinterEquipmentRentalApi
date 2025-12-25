using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;

namespace WinterEquipmentRentalApi.Repostitory.Implementation;

public class ClientRepository(RentDbContext context, IMapper mapper) : IClientRepostitory
{
    public async Task<string> Add(Client entity)
    {
        context.Clients.Add(entity);

        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        return await context.Clients.ToListAsync();
    }

    public async Task<Client?> GetById(string id)
    {
        return await context.Clients.FindAsync(id);
    }

    public async Task<Client?> GetByLastName(string lastName)
    {
        return await context.Clients.FirstAsync(x => x.LastName == lastName);
    }

    public async Task<Client?> GetByPhoneNumber(string phoneNumber)
    {
        return await context.Clients.FirstAsync(x => x.PhoneNumber == phoneNumber);
    }

    public async Task<bool> Remove(string id)
    {
        var client = await context.Clients.FindAsync(id);

        if (client == null) return false;

        context.Clients.Remove(client);

        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Update(Client entity)
    {
        var client = await context.Clients.FindAsync(entity.Id);

        if (client == null) return false;

        mapper.Map(entity, client);
        
        await context.SaveChangesAsync();

        return true;
    }
}
