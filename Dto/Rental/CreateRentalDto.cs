namespace WinterEquipmentRentalApi.Dto.Rental;

public class CreateRentalDto
{
    public required string ClientId { get; set; }
    public List<string> RentalItemIds { get; set; } = [];
}
