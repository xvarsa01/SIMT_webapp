namespace Simt.Api.BL.Mappers.InterfaceBase;

public abstract class ModelMapperBase<TEntity, TListModel, TDetailModel> : IModelMapper<TEntity, TListModel, TDetailModel>
{
    public abstract TListModel MapToListModel(TEntity? entity);

    public List<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel).ToList();

    public abstract TDetailModel MapToDetailModel(TEntity? entity);
    public abstract TEntity MapToEntity(TDetailModel model);    
}
