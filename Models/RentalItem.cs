namespace WinterEquipmentRentalApi.Models;

public class RentalItem
{
    public string Id { get; set; } = new Guid().ToString();
    public required string Name { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Price { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = [];
}
