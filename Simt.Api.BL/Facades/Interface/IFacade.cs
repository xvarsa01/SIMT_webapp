using Simt.Api.DAL.entities;

namespace Simt.Api.BL.Facades.Interface;

public interface IFacade<TEntity, TListModel, TDetailModel, in TCreationModel>
    where TEntity : class, IEntity
    where TDetailModel : class
    where TCreationModel : class
{
    Task DeleteAsync(Guid id);
    Task<TDetailModel?> GetByIdAsync(Guid id);
    Task<List<TListModel>> GetAllAsync();
    Task<Guid> CreateAsync(TCreationModel model);
    Task<Guid?> UpdateAsync(TCreationModel model);
}
