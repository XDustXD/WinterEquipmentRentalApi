using System.ComponentModel.DataAnnotations;

namespace WinterEquipmentRentalApi.Models;

public class Client
{
    public string Id { get; set; } = new Guid().ToString();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    [Phone]
    public required string PhoneNumber { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = [];
}
