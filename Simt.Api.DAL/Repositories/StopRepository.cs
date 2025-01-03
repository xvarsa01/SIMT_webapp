using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class StopRepository(SimtDbContext dbContext) : RepositoryBase<StopEntity>(dbContext)
{
    private readonly DbSet<StopEntity> _dbSet = dbContext.Set<StopEntity>();
    
    public override async Task<StopEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.Platforms)
            .ThenInclude(e => e.RouteStops)
            .ThenInclude(e => e.Route)
            .ThenInclude(e => e.Line)
            .SingleOrDefaultAsync(entity => entity.Id == id);
    }
}