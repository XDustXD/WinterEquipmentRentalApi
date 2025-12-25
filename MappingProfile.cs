using AutoMapper;
using WinterEquipmentRentalApi.Dto.RentalItem;
using WinterEquipmentRentalApi.Dto.Client;
using WinterEquipmentRentalApi.Models;
using WinterEquipmentRentalApi.Dto.Rental;
using WinterEquipmentRentalApi.Dto.RentalReturn;

namespace WinterEquipmentRentalApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateRentalItem, RentalItem>();
        CreateMap<RentalItem, GetRentalItemDto>();
        CreateMap<UpdateRentalItemDto, RentalItem>();

        // Client mappings
        CreateMap<CreateClientDto, Client>();
        CreateMap<Client, GetClientDto>();
        CreateMap<UpdateClientDto, Client>();
        CreateMap<Client, Client>();

        // Rental mappings
        CreateMap<CreateRentalDto, Rental>();
        CreateMap<Rental, GetRentalDto>();
        CreateMap<UpdateRentalDto, Rental>();

        // RentalReturn mappings
        CreateMap<CreateRentalReturnDto, RentalReturn>();
        CreateMap<RentalReturn, GetRentalReturnDto>();
    }
}
