namespace WinterEquipmentRentalApi.Dto.Client;

public class CreateClientDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
}
