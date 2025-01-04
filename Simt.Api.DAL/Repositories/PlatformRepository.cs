using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class PlatformRepository(SimtDbContext dbContext) : RepositoryBase<PlatformEntity>(dbContext)
{
    private readonly DbSet<PlatformEntity> _dbSet = dbContext.Set<PlatformEntity>();
    
    public override async Task<List<PlatformEntity>> GetAllAsync()
    {
        return await _dbSet
            .Include(e => e.ParentStop)
            .ToListAsync();
    }
    
    public override async Task<PlatformEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.ParentStop)
            
            .Include(e => e.RouteStops)
            // .ThenInclude(e => e.Route)
            // .ThenInclude(e => e.Line)
            //
            .Include(e => e.RouteStarts)
            .ThenInclude(e => e.Line)
            .Include(e => e.RouteStarts)
            .ThenInclude(e => e.FinalPlatform)
            .ThenInclude(e => e.ParentStop)
            
            .Include(e => e.RouteFinals)
            .ThenInclude(e => e.Line)
            .Include(e => e.RouteFinals)
            .ThenInclude(e => e.StartPlatform)
            .ThenInclude(e => e.ParentStop)
            
            .SingleOrDefaultAsync(entity => entity.Id == id);
    }
}