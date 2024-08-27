using AutoMapper;
using HubService.Contracts.ApiModels;
using HubService.Contracts.Request;
using HubService.Contracts.Response;
using Services.Models.Request;
using Services.Models.Response;


namespace WebApi.Mapper;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        // Requests -> Request models
        CreateMap<CreateHubRequest, CreateHubModel>()
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.MapFrom(c => c.Latitude))
            .ForMember(d => d.Longitude, map => map.MapFrom(c => c.Longitude));


        CreateMap<DeleteHubRequest, DeleteHubModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));


        CreateMap<GetHubByIdRequest, GetHubByIdModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        
        CreateMap<GetHubsByCityRequest, GetHubsByCityModel>()
            .ForMember(d => d.City, map => map.MapFrom(c => c.City));


        CreateMap<UpdateHubRequest, UpdateHubModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.MapFrom(c => c.Latitude))
            .ForMember(d => d.Longitude, map => map.MapFrom(c => c.Longitude));
        
        

        // Response models -> Responses
        CreateMap<HubModel, DeleteHubResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.MapFrom(c => c.Latitude))
            .ForMember(d => d.Longitude, map => map.MapFrom(c => c.Longitude));


        CreateMap<HubModel, GetHubByIdResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.MapFrom(c => c.Latitude))
            .ForMember(d => d.Longitude, map => map.MapFrom(c => c.Longitude));
        
        
        CreateMap<HubModel, UpdateHubResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.MapFrom(c => c.Latitude))
            .ForMember(d => d.Longitude, map => map.MapFrom(c => c.Longitude));


        CreateMap<HubModel, HubApiModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Latitude, map => map.MapFrom(c => c.Latitude))
            .ForMember(d => d.Longitude, map => map.MapFrom(c => c.Longitude));
    }
}