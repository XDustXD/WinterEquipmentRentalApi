namespace WinterEquipmentRentalApi.Dto.RentalReturn;

public class GetRentalReturnDto
{
    public string Id { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public DateTime ReturnDate { get; set; }
    public required string RentalId { get; set; }
}
