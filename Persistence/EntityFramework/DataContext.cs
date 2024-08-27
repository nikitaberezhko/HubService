using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityFramework;

public class DataContext : DbContext
{
    public DbSet<Hub> Hubs { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hub>().Property(x => x.Id).HasColumnName("id");
        modelBuilder.Entity<Hub>().Property(x => x.Address).HasColumnName("address");
        modelBuilder.Entity<Hub>().Property(x => x.City).HasColumnName("city");
        modelBuilder.Entity<Hub>().Property(x => x.Latitude).HasColumnName("latitude");
        modelBuilder.Entity<Hub>().Property(x => x.Longitude).HasColumnName("longitude");
        modelBuilder.Entity<Hub>().Property(x => x.IsDeleted).HasColumnName("is_deleted");
    }
}