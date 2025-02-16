using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.DAL.Repositories;

public class LineRepository(SimtDbContext dbContext) : RepositoryBase<LineEntity>(dbContext)
{
    private readonly DbSet<LineEntity> _dbSet = dbContext.Set<LineEntity>();
    
    public override async Task<LineEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.Routes)
            .ThenInclude(e => e.StartPlatform)
            .ThenInclude(e => e.ParentStop)
            
            .Include(e => e.Routes)
            .ThenInclude(e => e.FinalPlatform)
            .ThenInclude(e => e.ParentStop)
            
            .SingleOrDefaultAsync(entity => entity.Id == id);
    }
    
    public async Task<List<LineEntity>> GetAllByMapAsync(Guid mapId)
    {
        return await _dbSet
            .Where(line => line.MapId == mapId)
            .ToListAsync();
    }
}