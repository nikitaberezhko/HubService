using WebApi.Models.ApiModels;

namespace WebApi.Models.Response;

public class GetHubsByCityResponse
{
    public List<HubApiModel> Hubs { get; set; }
}