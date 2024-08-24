using AutoMapper;
using Services.Models.Request;
using Services.Models.Response;
using WebApi.Models.ApiModels;
using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Mapper;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        // Requests -> Request models
        CreateMap<CreateHubRequest, CreateHubModel>()
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Location, map => map.MapFrom(c => c.Location));


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
            .ForMember(d => d.Location, map => map.MapFrom(c => c.Location));
        
        

        // Response models -> Responses
        CreateMap<HubModel, CreateHubResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        

        CreateMap<HubModel, DeleteHubResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Location, map => map.MapFrom(c => c.Location));

        
        CreateMap<HubModel, GetHubByIdResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Location, map => map.MapFrom(c => c.Location));;
        
        
        CreateMap<HubModel, UpdateHubResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Location, map => map.MapFrom(c => c.Location));;


        CreateMap<HubModel, HubApiModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Address, map => map.MapFrom(c => c.Address))
            .ForMember(d => d.City, map => map.MapFrom(c => c.City))
            .ForMember(d => d.Location, map => map.MapFrom(c => c.Location));;
    }
}