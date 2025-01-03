using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class PlatformModelMapper (RouteStopModelMapper routeStopModelMapper) : ModelMapperBase<PlatformEntity, PlatformModel, PlatformModel>
{
    public override PlatformModel MapToListModel(PlatformEntity? entity)
    {
        if (entity is null)
        {
            return PlatformModel.Empty;
        }

        return new PlatformModel
        {
            Id = entity.Id,
            PlatformName = entity.PlatformName,
            LowFloor = entity.LowFloor,
            ParentStopId = entity.ParentStopId,
            RouteStops = routeStopModelMapper.MapToListModel(entity.RouteStops)
        };
    }

    public override PlatformModel MapToDetailModel(PlatformEntity? entity)
    {
        return MapToListModel(entity);
    }
    
    public override PlatformEntity MapToEntity(PlatformModel model)
    {
        return new PlatformEntity
        {
            Id = model.Id,
            PlatformName = model.PlatformName,
            LowFloor = model.LowFloor,
            ParentStopId = model.ParentStopId,
            ParentStop = null!,
        };
    }
}