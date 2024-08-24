using NetTopologySuite.Geometries;

namespace WebApi.Models.Request;

public class CreateHubRequest
{
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public Point Location { get; set; }
}