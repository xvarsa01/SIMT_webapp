using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class PlatformModelMapper (RouteStopModelMapper routeStopModelMapper, RouteModelMapper routeModelMapper)
    : ModelMapperBase<PlatformEntity, PlatformListModel, PlatformDetailModel>
{
    public override PlatformListModel MapToListModel(PlatformEntity? entity)
    {
        if (entity is null)
        {
            return PlatformListModel.Empty;
        }

        return new PlatformListModel
        {
            Id = entity.Id,
            PlatformName = entity.PlatformName,
            ParentStopId = entity.ParentStopId,
            ParentStopName = entity.ParentStop.StopName!
        };
    }

    public override PlatformDetailModel MapToDetailModel(PlatformEntity? entity)
    {
        if (entity is null)
        {
            return PlatformDetailModel.Empty;
        }

        return new PlatformDetailModel
        {
            Id = entity.Id,
            PlatformName = entity.PlatformName,
            LowFloor = entity.LowFloor,
            ParentStopId = entity.ParentStopId,
            ParentStopName = entity.ParentStop.StopName!,
            RouteStops = routeStopModelMapper.MapToListModel(entity.RouteStops),
            RouteStarts = routeModelMapper.MapToListModel(entity.RouteStarts),
            RouteFinals = routeModelMapper.MapToListModel(entity.RouteFinals),
        };
    }
    
    public override PlatformEntity MapToEntity(PlatformDetailModel detailModel)
    {
        return new PlatformEntity
        {
            Id = detailModel.Id,
            PlatformName = detailModel.PlatformName,
            LowFloor = detailModel.LowFloor,
            ParentStopId = detailModel.ParentStopId,
            ParentStop = null!,
        };
    }
}