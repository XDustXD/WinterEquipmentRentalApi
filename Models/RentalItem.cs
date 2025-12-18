namespace WinterEquipmentRentalApi.Models;

public class RentalItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
    public decimal Price { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = [];
}
