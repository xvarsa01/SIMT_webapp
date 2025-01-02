using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class MapRepository(SimtDbContext dbContext) : RepositoryBase<MapEntity>(dbContext)
{
    private readonly DbSet<MapEntity> _dbSet = dbContext.Set<MapEntity>();
    
    public override async Task<List<MapEntity>> GetAllAsync()
    {
        return await _dbSet
            .Include(e => e.Lines)
            .ThenInclude(e => e.Routes)
            .ToListAsync();
    }
    
    public override async Task<MapEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.Lines)
            .ThenInclude(e => e.Routes)
            .SingleOrDefaultAsync(entity => entity.Id == id);
    }
}