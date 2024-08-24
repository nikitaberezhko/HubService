using Services.Models.Request;
using Services.Models.Response;

namespace Services.Services.Interfaces;

public interface IHubService
{
    Task<Guid> Create(CreateHubModel model);

    Task<HubModel> Update(UpdateHubModel model);

    Task<HubModel> Delete(DeleteHubModel model);

    Task<HubModel> GetById(GetHubByIdModel model);

    Task<List<HubModel>> GetByCity(GetHubsByCityModel model);

    Task<List<HubModel>> GetAll(GetAllHubsModel model);
}