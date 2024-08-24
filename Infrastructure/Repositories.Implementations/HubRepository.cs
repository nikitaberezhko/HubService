using Domain;
using Exceptions.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Interfaces;

namespace Infrastructure.Repositories.Implementations;

public class HubRepository(DbContext context) : IHubRepository
{
    public async Task<Guid> AddAsync(Hub hub)
    {
        hub.Id = Guid.NewGuid();
        await context.Set<Hub>().AddAsync(hub);
        await context.SaveChangesAsync();

        return hub.Id;
    }

    public async Task<Hub> UpdateAsync(Hub hub)
    {
        var hubFromDb = await context.Set<Hub>().FirstOrDefaultAsync(x => x.Id == hub.Id);
        if (hubFromDb != null)
        {
            context.Entry(hubFromDb).CurrentValues.SetValues(hub);
            await context.SaveChangesAsync();
            return hubFromDb; 
        }

        throw new InfrastructureException
        {
            Title = "Hub not found",
            Message = "Hub with this id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    public async Task<Hub> DeleteAsync(Hub hub)
    {
        var hubFromDb = await context.Set<Hub>().FirstOrDefaultAsync(x => x.Id == hub.Id);
        if (hubFromDb != null)
        {
            hubFromDb.IsDeleted = true;
            await context.SaveChangesAsync();
            return hubFromDb;
        }

        throw new InfrastructureException
        {
            Title = "Hub not found",
            Message = "Hub with this id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    public async Task<Hub> GetByIdAsync(Hub hub)
    {
        var hubFromDb = await context.Set<Hub>().FirstOrDefaultAsync(x => x.Id == hub.Id);
        if (hubFromDb != null)
            return hubFromDb;

        throw new InfrastructureException
        {
            Title = "Hub not found",
            Message = "Hub with this id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    public async Task<List<Hub>> GetByCityAsync(Hub hub)
    {
        var hubsFromDb = await context.Set<Hub>().Where(x => x.City == hub.City).ToListAsync();
        return hubsFromDb;
    }

    public async Task<List<Hub>> GetAllAsync(int page, int pageSize)
    {
        var hubs = await context.Set<Hub>()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return hubs;
    }
}