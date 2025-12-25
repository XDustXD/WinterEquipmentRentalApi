using System.ComponentModel.DataAnnotations;

namespace WinterEquipmentRentalApi.Dto.Client;

public class UpdateClientDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    [Phone]
    public required string PhoneNumber { get; set; }
}
