using Domain;

namespace Services.Repositories.Interfaces;

public interface IHubRepository
{
    Task<Guid> AddAsync(Hub hub);
    
    Task<Hub> UpdateAsync(Hub hub);
    
    Task<Hub> DeleteAsync(Hub hub);

    Task<Hub> GetByIdAsync(Hub hub);
    
    Task<List<Hub>> GetByCityAsync(Hub hub);
    
    Task<List<Hub>> GetAllAsync(int page, int pageSize);
}