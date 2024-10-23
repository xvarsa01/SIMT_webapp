using Simt.DAL.entities;

namespace Simt.DAL.Repositories;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{

    IList<TEntity> GetAll();
    IList<TEntity> GetAll(int pageNumber, int pageSize);
    Task DeleteAsync(Guid entityId);
    ValueTask<bool> ExistsAsync(TEntity entity);
    Task<TEntity> InsertAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
}