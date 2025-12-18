namespace WinterEquipmentRentalApi.Dto.RentalItem;

public class UpdateRentalItemDto
{
    public required string Name { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Price { get; set; }
}
