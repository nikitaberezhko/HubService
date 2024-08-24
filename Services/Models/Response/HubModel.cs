using NetTopologySuite.Geometries;

namespace Services.Models.Response;

public class HubModel
{
    public Guid Id { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public Point Location { get; set; } 
}