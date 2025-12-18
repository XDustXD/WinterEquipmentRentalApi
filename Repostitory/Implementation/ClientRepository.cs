using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;

namespace WinterEquipmentRentalApi.Repostitory.Implementation;

public class ClientRepository(RentDbContext context) : IClientRepostitory
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
        return await context.Clients.FindAsync(id)
            ?? throw new Exception("Cannot find client");
    }

    public async Task<Client?> GetByLastName(string lastName)
    {
        return await context.Clients.FirstAsync(x => x.LastName == lastName);
    }

    public async Task<Client?> GetByPhoneNumber(string phoneNumber)
    {
        return await context.Clients.FirstAsync(x => x.PhoneNumber == phoneNumber);
    }

    public async Task Remove(string id)
    {
        var client = await context.Clients.FindAsync(id)
            ?? throw new Exception("Cannot find client");

        context.Clients.Remove(client);
    }

    public async Task Update(Client entity)
    {
        var client = await context.Clients.FindAsync(entity.Id)
            ?? throw new Exception("Cannot find client");

        client.Id = entity.Id;
        client.FirstName = entity.FirstName;
        client.LastName = entity.LastName;
        client.PhoneNumber = entity.PhoneNumber;

        await context.SaveChangesAsync();
    }
}
