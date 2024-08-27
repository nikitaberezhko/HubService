using AutoMapper;
using Domain;
using Services.Models.Request;
using Services.Models.Response;

namespace Services.Mapper;

public class ServicesMappingProfile : Profile
{
    public ServicesMappingProfile()
    {
        // Request models -> Domain
        CreateMap<CreateHubModel, Hub>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.MapFrom(c => c.Latitude))
            .ForMember(d => d.Longitude, map => map.MapFrom(c => c.Longitude))
            .ForMember(d => d.IsDeleted, map => map.Ignore());


        CreateMap<UpdateHubModel, Hub>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.MapFrom(c => c.Latitude))
            .ForMember(d => d.Longitude, map => map.MapFrom(c => c.Longitude))
            .ForMember(d => d.IsDeleted, map => map.Ignore());


        CreateMap<DeleteHubModel, Hub>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.Ignore())
            .ForMember(d => d.City, map => map.Ignore())
            .ForMember(d => d.Latitude, map => map.Ignore())
            .ForMember(d => d.Longitude, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());


        CreateMap<GetHubByIdModel, Hub>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.Ignore())
            .ForMember(d => d.City, map => map.Ignore())
            .ForMember(d => d.Latitude, map => map.Ignore())
            .ForMember(d => d.Longitude, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());


        CreateMap<GetHubsByCityModel, Hub>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.Address, map => map.Ignore())
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.Ignore())
            .ForMember(d => d.Longitude, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());

        
        
        // Domain -> Response models
        CreateMap<Hub, HubModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.MapFrom(c => c.Latitude))
            .ForMember(d => d.Longitude, map => map.MapFrom(c => c.Longitude));
    }
}