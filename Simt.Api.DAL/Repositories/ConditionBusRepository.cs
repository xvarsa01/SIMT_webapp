using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Repositories;

public class ConditionBusRepository(SimtDbContext dbContext) : RepositoryBase<ConditionBusEntity>(dbContext)
{
    private readonly DbSet<ConditionBusEntity> _dbSet = dbContext.Set<ConditionBusEntity>();
    
    public override async Task<Guid> InsertAsync(ConditionBusEntity entity)
    {
        var createdEntity = (await _dbSet.AddAsync(entity)).Entity;
        // do not save changes, it will be saved from player repository
        return createdEntity.Id;
    }
}