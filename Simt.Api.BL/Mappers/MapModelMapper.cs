using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class MapModelMapper : ModelMapperBase<MapEntity, MapListModel, MapDetailModel>
{
    public override MapListModel MapToListModel(MapEntity? entity)
    {
        if (entity is null)
        {
            return MapListModel.Empty;
        }

        return new MapListModel
        {
            Id = entity.Id,
            MapName = entity.MapName,
        };
    }

    public override MapDetailModel MapToDetailModel(MapEntity? entity)
    {
        if (entity is null)
        {
            return MapDetailModel.Empty;
        }

        return new MapDetailModel
        {
            Id = entity.Id,
            MapName = entity.MapName,
            Public = entity.Public,
        };
    }
    
    public override MapEntity MapToEntity(MapDetailModel model)
    {
        return new MapEntity
        {
            Id = model.Id,
            MapName = model.MapName,
            Public = model.Public,
        };
    }
}