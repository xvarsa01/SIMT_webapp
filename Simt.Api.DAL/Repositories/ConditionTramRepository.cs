using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Repositories;

public class ConditionTramRepository(SimtDbContext dbContext) : RepositoryBase<ConditionTramEntity>(dbContext)
{
    private readonly DbSet<ConditionTramEntity> _dbSet = dbContext.Set<ConditionTramEntity>();
    
    public override async Task<Guid> InsertAsync(ConditionTramEntity entity)
    {
        var createdEntity = (await _dbSet.AddAsync(entity)).Entity;
        // do not save changes, it will be saved from player repository
        return createdEntity.Id;
    }
}