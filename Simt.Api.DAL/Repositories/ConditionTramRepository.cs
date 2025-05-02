using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Repositories;

public class ConditionTramRepository(SimtDbContext dbContext) : RepositoryBase<ConditionTramEntity>(dbContext)
{
    private readonly DbSet<ConditionTramEntity> _dbSet = dbContext.Set<ConditionTramEntity>();
    
    public override Task<List<ConditionTramEntity>> GetAllAsync()
    {
        throw new NotImplementedException("This method is unsupported. Use the overload with paging.");
    }
    
    public override async Task<List<ConditionTramEntity>> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _dbSet
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .Include(e => e.Player)
            .ToListAsync();
    }
    
    public override async Task<ConditionTramEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.Player)
            .SingleOrDefaultAsync(entity => entity.Id == id);
    }
    public override async Task<Guid> InsertAsync(ConditionTramEntity entity)
    {
        var createdEntity = (await _dbSet.AddAsync(entity)).Entity;
        // do not save changes, it will be saved from player repository
        return createdEntity.Id;
    }
}