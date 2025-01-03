using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Repositories;

public class ServiceRepository(SimtDbContext dbContext) : RepositoryBase<ServiceEntity>(dbContext)
{
    private readonly DbSet<ServiceEntity> _dbSet = dbContext.Set<ServiceEntity>();
    
    public override async Task<List<ServiceEntity>> GetAllAsync()
    {
        return await _dbSet
            .Include(e => e.Route)
            .Include(e => e.Route).ThenInclude(e => e.FinalPlatform)
            .Include(e => e.Route).ThenInclude(e => e.Line)
            .Include(e => e.Vehicle)
            .ToListAsync();
    }
    
    public async Task<List<ServiceEntity>> GetAllActiveAsync()
    {
        return await _dbSet
            .Where(e => e.Finished == false)
            .Include(e => e.Route)
            .Include(e => e.Route).ThenInclude(e => e.FinalPlatform)
            .Include(e => e.Route).ThenInclude(e => e.Line)
            .Include(e => e.Vehicle)
            .ToListAsync();
    }
    
    public async Task<List<ServiceEntity>> GetAllForPlayerAsync(Guid playerId, int pageNumber, int pageSize)
    {
        return await _dbSet
            .Where(e => e.PlayerId == playerId)
            .Include(e => e.Route)
            .Include(e => e.Route).ThenInclude(e => e.FinalPlatform)
            .Include(e => e.Route).ThenInclude(e => e.Line)
            .Include(e => e.Vehicle)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
    }
    
    public override async Task<ServiceEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.Route)
            .Include(e => e.Route).ThenInclude(e => e.FinalPlatform)
            .Include(e => e.Route).ThenInclude(e => e.Line)
            .Include(e => e.Vehicle)
            .SingleOrDefaultAsync(entity => entity.Id == id);
    }
}