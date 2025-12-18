using AutoMapper;
using WinterEquipmentRentalApi.Dto.RentalItem;
using WinterEquipmentRentalApi.Models;

namespace WinterEquipmentRentalApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateRentalItem, RentalItem>();
        CreateMap<RentalItem, GetRentalItemDto>();
        CreateMap<UpdateRentalItemDto, RentalItem>();
    }
}
