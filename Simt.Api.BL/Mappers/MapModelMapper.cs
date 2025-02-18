using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class MapModelMapper : ModelMapperBase<MapEntity, MapListModel, MapDetailModel, MapDetailModel>
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
            SCIN = entity.SCIN,
            LastChangeTime = entity.LastChangeTime,
            Version = entity.Version,
            RoutesCount = entity.Lines.Sum(line => line.Routes.Count), // Aggregating routes count
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
            SCIN = entity.SCIN,
            LastChangeTime = entity.LastChangeTime,
            Version = entity.Version,
            Public = entity.Public,
            RoutesCount = entity.Lines.Sum(line => line.Routes.Count), // Aggregating routes count
        };
    }
    
    public override MapEntity MapToEntity(MapDetailModel model)
    {
        return new MapEntity
        {
            Id = model.Id,
            MapName = model.MapName,
            SCIN = model.SCIN,
            LastChangeTime = model.LastChangeTime,
            Version = model.Version,
            Public = model.Public,
        };
    }
}