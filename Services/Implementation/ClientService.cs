using AutoMapper;
using WinterEquipmentRentalApi.Dto.Client;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Repostitory.Abstraction;
using WinterEquipmentRentalApi.Services.Abstraction;

namespace WinterEquipmentRentalApi.Services.Implementation;

public class ClientService(IMapper mapper, IClientRepostitory clientRepo) : IClientService
{
    public async Task<string> Add(CreateClientDto entity)
    {
        var client = mapper.Map<CreateClientDto, Client>(entity);
        return await clientRepo.Add(client);
    }

    public async Task<IEnumerable<GetClientDto>> GetAll()
    {
        var clients = await clientRepo.GetAll();
        return clients.Select(c => mapper.Map<Client, GetClientDto>(c));
    }

    public async Task<GetClientDto?> GetById(string id)
    {
        var client = await clientRepo.GetById(id)
            ?? throw new KeyNotFoundException("Client not found");

        return mapper.Map<Client, GetClientDto>(client);
    }

    public async Task<GetClientDto?> GetByPhoneNumber(string phoneNumber)
    {
        var client = await clientRepo.GetByPhoneNumber(phoneNumber)
            ?? throw new KeyNotFoundException("Client not found");

        return mapper.Map<Client, GetClientDto>(client);
    }

    public async Task Update(string id, UpdateClientDto entity)
    {
        var client = mapper.Map<UpdateClientDto, Client>(entity);
        client.Id = id;

        var ok = await clientRepo.Update(client);
        if (!ok) throw new KeyNotFoundException("Client not found");
    }

    public async Task Remove(string id)
    {
        var ok = await clientRepo.Remove(id);
        if (!ok) throw new KeyNotFoundException("Client not found");
    }
}
