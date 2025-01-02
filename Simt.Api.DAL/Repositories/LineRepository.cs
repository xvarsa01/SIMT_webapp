using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class LineRepository(SimtDbContext dbContext) : RepositoryBase<LineEntity>(dbContext)
{
    private readonly DbSet<LineEntity> _dbSet = dbContext.Set<LineEntity>();
    
    public override async Task<LineEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.Routes)
            .ThenInclude(e => e.StartStop)
            .Include(e => e.Routes)
            .ThenInclude(e => e.FinalStop)
            .SingleOrDefaultAsync(entity => entity.Id == id);
    }
}