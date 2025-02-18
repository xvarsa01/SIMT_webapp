namespace Simt.Api.BL.Mappers.InterfaceBase;

public abstract class ModelMapperBase<TEntity, TListModel, TDetailModel, TCreationModel> : IModelMapper<TEntity, TListModel, TDetailModel, TCreationModel>
{
    public abstract TListModel MapToListModel(TEntity? entity);

    public List<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel).ToList();
    
    public List<TDetailModel> MapToDetailModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToDetailModel).ToList();

    public abstract TDetailModel MapToDetailModel(TEntity? entity);
    public abstract TEntity MapToEntity(TCreationModel model);    
}
