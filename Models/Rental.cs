namespace WinterEquipmentRentalApi.Models;

public class Rental
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public decimal PricePerHour { get; set; }
    public DateTime RentalDate { get; set; } = DateTime.UtcNow;

    public required string ClientID { get; set; }
    public required Client Client { get; set; }
    public virtual ICollection<RentalItem> RentalItems {get; set;} = [];
    public RentalReturn? RentalReturn { get; set; }
}
