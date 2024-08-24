using AutoMapper;
using Domain;
using Services.Models.Request;
using Services.Models.Response;
using Services.Repositories.Interfaces;
using Services.Services.Interfaces;
using Services.Validation;

namespace Services.Services.Implementations;

public class HubService(
    IMapper mapper,
    IHubRepository hubRepository,
    HubValidator validator) : IHubService
{
    public async Task<Guid> Create(CreateHubModel model)
    {
        await validator.ValidateAsync(model);

        var id = await hubRepository.AddAsync(mapper.Map<Hub>(model));

        return id;
    }

    public async Task<HubModel> Update(UpdateHubModel model)
    {
        await validator.ValidateAsync(model);
        
        var hub = await hubRepository.UpdateAsync(mapper.Map<Hub>(model));
        var result = mapper.Map<HubModel>(hub);
        
        return result;
    }

    public async Task<HubModel> Delete(DeleteHubModel model)
    {
        await validator.ValidateAsync(model);

        var hub = await hubRepository.DeleteAsync(mapper.Map<Hub>(model));
        var result = mapper.Map<HubModel>(hub);
        
        return result;
    }
    
    public async Task<HubModel> GetById(GetHubByIdModel model)
    {
        await validator.ValidateAsync(model);
        
        var hub = await hubRepository.GetByIdAsync(mapper.Map<Hub>(model));
        var result = mapper.Map<HubModel>(hub);
        
        return result;
    }

    public async Task<List<HubModel>> GetByCity(GetHubsByCityModel model)
    {
        await validator.ValidateAsync(model);
        
        var hubs = await hubRepository.GetByCityAsync(mapper.Map<Hub>(model));
        var result = mapper.Map<List<HubModel>>(hubs);
        
        return result;
    }
    
    public async Task<List<HubModel>> GetAll(GetAllHubsModel model)
    {
        await validator.ValidateAsync(model);
        
        var hubs = await hubRepository.GetAllAsync(model.Page, model.PageSize);
        var result = mapper.Map<List<HubModel>>(hubs);
        
        return result;
    }
}