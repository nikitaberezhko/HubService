using WebApi.Models.ApiModels;

namespace WebApi.Models.Response;

public class GetAllHubsResponse
{
    public List<HubApiModel> Hubs { get; set; }
}