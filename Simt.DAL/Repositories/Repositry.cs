using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Simt.DAL.entities;

namespace Simt.DAL.Repositories;

public class RepositoryVehicle<TEntity>(DbContext dbContext, IMapper mapper) : IRepository<TEntity> 
    where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
    private readonly IMapper _mapper = mapper;
    

    public virtual IList<TEntity> GetAll() => _dbSet.ToList();
    public virtual IList<TEntity> GetAll(int pageNumber, int pageSize)
    {
        return _dbSet
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();
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
        _mapper.Map(existingEntity, entity);
        return existingEntity;
    }
}