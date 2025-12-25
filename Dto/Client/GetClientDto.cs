namespace WinterEquipmentRentalApi.Dto.Client;

public class GetClientDto
{
    public string Id { get; set; } = string.Empty;
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
}
