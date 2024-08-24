using NetTopologySuite.Geometries;

namespace Services.Models.Request;

public class CreateHubModel
{
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public Point Location { get; set; }
}