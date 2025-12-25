using WinterEquipmentRentalApi.Dto.RentalItem;
using WinterEquipmentRentalApi.Dto.RentalReturn;

namespace WinterEquipmentRentalApi.Dto.Rental;

public class GetRentalDto
{
    public required string Id { get; set; }
    public decimal PricePerHour { get; set; }
    public DateTime RentalDate { get; set; }
    public required string ClientId { get; set; }
    public IEnumerable<GetRentalItemDto> RentalItems { get; set; } = new List<GetRentalItemDto>();
    public GetRentalReturnDto? RentalReturn { get; set; }
}
