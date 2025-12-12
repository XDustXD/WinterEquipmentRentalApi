namespace WinterEquipmentRentalApi.Models;

public class Rental
{
    public string Id { get; set; } = new Guid().ToString();
    public int RentHours { get; set; }
    public decimal Cost { get; set; }

    public required string ClientID { get; set; }
    public required Client Client { get; set; }
    public virtual ICollection<RentalItem> RentalItems {get; set;} = [];
}
