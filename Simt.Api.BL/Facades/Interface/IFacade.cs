using Simt.Api.DAL.entities;

namespace Simt.Api.BL.Facades.Interface;

public interface IFacade<TEntity, TListModel, TDetailModel>
    where TEntity : class, IEntity
    where TDetailModel : class
{
    Task DeleteAsync(Guid id);
    Task<TDetailModel?> GetByIdAsync(Guid id);
    Task<List<TListModel>> GetAllAsync();
    Task<Guid> CreateAsync(TDetailModel model);
    Task<Guid?> UpdateAsync(TDetailModel model);
}
