using System;

namespace WinterEquipmentRentalApi.Dto;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public required string Message { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
}
