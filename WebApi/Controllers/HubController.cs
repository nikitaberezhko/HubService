using Asp.Versioning;
using AutoMapper;
using CommonModel.Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request;
using Services.Services.Interfaces;
using WebApi.Models.ApiModels;
using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/hubs")]
[ApiVersion(1)]
public class HubController(
    IMapper mapper,
    IHubService hubService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetAllHubsResponse>>> GetAll(
        GetAllHubsRequest request)
    {
        var result = await hubService.GetAll(
            new GetAllHubsModel { Page = request.Page, PageSize = request.PageSize });
        var response = new CommonResponse<GetAllHubsResponse>{ Data = new GetAllHubsResponse 
            { Hubs = mapper.Map<List<HubApiModel>>(result) } };

        return response;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommonResponse<GetHubByIdResponse>>> GetById(
        [FromRoute] GetHubByIdRequest request)
    {
        var result = await hubService.GetById(mapper.Map<GetHubByIdModel>(request));
        var response = new CommonResponse<GetHubByIdResponse> 
            { Data = mapper.Map<GetHubByIdResponse>(result) };
        
        return response;
    }
    
    [HttpGet("cities/{city}")]
    public async Task<ActionResult<CommonResponse<GetHubsByCityResponse>>> GetByCity(
        [FromRoute] GetHubsByCityRequest request)
    {
        var result = await hubService.GetByCity(mapper.Map<GetHubsByCityModel>(request));
        var response = new CommonResponse<GetHubsByCityResponse> 
            { Data = mapper.Map<GetHubsByCityResponse>(result) };
        
        return response;
    }

    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateHubResponse>>> Create(
        CreateHubRequest request)
    {
        var result = await hubService.Create(mapper.Map<CreateHubModel>(request));
        var response = new CommonResponse<CreateHubResponse> 
            { Data = mapper.Map<CreateHubResponse>(result) };
        
        return response; 
    }
    
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateHubResponse>>> Update(
        UpdateHubRequest request)
    {
        var result = await hubService.Update(mapper.Map<UpdateHubModel>(request));
        var response = new CommonResponse<UpdateHubResponse> 
            { Data = mapper.Map<UpdateHubResponse>(result) };
        
        return response; 
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CommonResponse<DeleteHubResponse>>> Delete(
        [FromRoute] DeleteHubRequest request)
    {
        var result = await hubService.Delete(mapper.Map<DeleteHubModel>(request));
        var response = new CommonResponse<DeleteHubResponse> 
            { Data = mapper.Map<DeleteHubResponse>(result) };
        
        return response; 
    }
}