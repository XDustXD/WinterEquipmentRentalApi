using System;

namespace WinterEquipmentRentalApi.Models;

public class RentalReturn
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public decimal Cost { get; set; }
    public DateTime ReturnDate { get; set; } = DateTime.UtcNow;
    public required string RentalId { get; set; }
    public Rental Rental { get; set; } = null!;
}
