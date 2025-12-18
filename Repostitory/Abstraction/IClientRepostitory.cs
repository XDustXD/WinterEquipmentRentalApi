using WinterEquipmentRentalApi.Models;

namespace WinterEquipmentRentalApi.Repostitory.Abstraction;

public interface IClientRepostitory : IRepository<Client>
{
    Task<Client?> GetByPhoneNumber(string phoneNumber);
    Task<Client?> GetByLastName(string lastName);
}
