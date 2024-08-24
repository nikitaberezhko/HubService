using NetTopologySuite.Geometries;

namespace WebApi.Models.ApiModels;

public class HubApiModel
{
    public Guid Id { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public Point Location { get; set; } 
}