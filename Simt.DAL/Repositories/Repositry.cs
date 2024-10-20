using Microsoft.EntityFrameworkCore;
using Simt.DAL.entities;
using Simt.DAL.Mappers;

namespace Simt.DAL.Repositories;

public class RepositoryVehicle<TEntity>(DbContext dbContext, IEntityMapper<TEntity> entityMapper) : IRepository<TEntity> 
    where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
    private readonly IEntityMapper<TEntity> _entityMapper = entityMapper;
    
    public IQueryable<TEntity> Get()
    {
        return _dbSet;
    }

    public async Task DeleteAsync(Guid entityId)
    {
        _dbSet.Remove(await _dbSet.SingleAsync(i => i.Id == entityId).ConfigureAwait(false));
    }

    public async ValueTask<bool> ExistsAsync(TEntity entity)
    {
        return entity.Id != Guid.Empty && await _dbSet.AnyAsync(e => e.Id == entity.Id);
    }

    public async Task<TEntity> InsertAsync (TEntity entity)
    {
        return (await _dbSet.AddAsync(entity)).Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        TEntity existingEntity = await _dbSet.SingleAsync(e => e.Id == entity.Id);
        _entityMapper.MapToExistingEntity(existingEntity, entity);
        return existingEntity;
    }
}