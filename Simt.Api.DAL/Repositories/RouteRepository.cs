using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class RouteRepository(SimtDbContext dbContext) : RepositoryBase<RouteEntity>(dbContext)
{
    private readonly DbSet<RouteEntity> _dbSet = dbContext.Set<RouteEntity>();
    
    public override async Task<List<RouteEntity>> GetAllAsync()
    {
        return await _dbSet
            .Include(e => e.Line)
            .Include(e => e.StartStop)
            .Include(e => e.FinalStop)
            .ToListAsync();
    }
    
    public override async Task<RouteEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.Line)
            .Include(e => e.StartStop)
            .Include(e => e.FinalStop)
            .SingleOrDefaultAsync(entity => entity.Id == id);
    }
}