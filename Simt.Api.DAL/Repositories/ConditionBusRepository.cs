using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Repositories;

public class ConditionBusRepository(SimtDbContext dbContext) : RepositoryBase<ConditionBusEntity>(dbContext)
{
    private readonly DbSet<ConditionBusEntity> _dbSet = dbContext.Set<ConditionBusEntity>();
    
    public override Task<List<ConditionBusEntity>> GetAllAsync()
    {
        throw new NotImplementedException("This method is unsupported. Use the overload with paging.");
    }
    
    public override async Task<List<ConditionBusEntity>> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _dbSet
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .Include(e => e.Player)
            .ToListAsync();
    }

    public override async Task<ConditionBusEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.Player)
            .SingleOrDefaultAsync(entity => entity.Id == id);
    }

    public override async Task<Guid> InsertAsync(ConditionBusEntity entity)
    {
        var createdEntity = (await _dbSet.AddAsync(entity)).Entity;
        // do not save changes, it will be saved from player repository
        return createdEntity.Id;
    }
}