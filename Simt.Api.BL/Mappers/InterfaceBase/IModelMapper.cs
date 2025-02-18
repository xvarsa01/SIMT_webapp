namespace Simt.Api.BL.Mappers.InterfaceBase;

public interface IModelMapper<TEntity, TListModel, TDetailModel, TCreateModel>
{
    TListModel MapToListModel(TEntity? entity);

    List<TListModel> MapToListModel(IEnumerable<TEntity> entities);
    List<TDetailModel> MapToDetailModel(IEnumerable<TEntity> entities);

    TDetailModel MapToDetailModel(TEntity? entity);
    TEntity MapToEntity(TCreateModel model);
}
