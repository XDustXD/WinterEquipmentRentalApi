namespace WinterEquipmentRentalApi.Dto.RentalItem;

public class GetRentalItemDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Price { get; set; }
}
