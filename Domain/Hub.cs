using NetTopologySuite.Geometries;

namespace Domain;

public class Hub
{
    public Guid Id { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public Point Location { get; set; }
    
    public bool IsDeleted { get; set; }
}