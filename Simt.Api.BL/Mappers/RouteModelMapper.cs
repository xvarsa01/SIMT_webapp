using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class RouteModelMapper (RouteStopModelMapper routeStopModelMapper) : ModelMapperBase<RouteEntity, RouteListModel, RouteDetailModel, RouteCreationModel>
{
    public override RouteListModel MapToListModel(RouteEntity? entity)
    {
        if (entity is null)
        {
            return RouteListModel.Empty;
        }

        return new RouteListModel
        {
            Id = entity.Id,
            RouteCode = entity.RouteCode,
            Status = entity.Status,
            StartPlatformId = entity.StartPlatformId,
            FinalPlatformId = entity.FinalPlatformId,
            LineId = entity.LineId,
            StartStopName = entity.StartPlatform.ParentStop.StopName,
            FinalStopName = entity.FinalPlatform.ParentStop.StopName,
            LineName = entity.Line.LineNumber,
        };
    }

    public override RouteDetailModel MapToDetailModel(RouteEntity? entity)
    {
        if (entity is null)
        {
            return RouteDetailModel.Empty;
        }

        return new RouteDetailModel
        {
            Id = entity.Id,
            RouteCode = entity.RouteCode,
            FrontBUSE = entity.FrontBUSE,
            RightBUSE = entity.RightBUSE,
            RearBUSE = entity.RearBUSE,
            RewardMoney = entity.RewardMoney,
            RewardPoints = entity.RewardPoints,
            Status = entity.Status,
            OnlyLowFloor = entity.OnlyLowFloor,
            TwoWay = entity.TwoWay,
            AlternativeDrive = entity.AlternativeDrive,
            StartPlatformId = entity.StartPlatformId,
            FinalPlatformId = entity.FinalPlatformId,
            LineId = entity.LineId,
            StartStopName = entity.StartPlatform.ParentStop.StopName,
            FinalStopName = entity.FinalPlatform.ParentStop.StopName,
            LineNumber = entity.Line.LineNumber,
            Stops = routeStopModelMapper.MapToListModel(entity.RouteStops)
        };
    }
    
    public override RouteEntity MapToEntity(RouteCreationModel model)
    {
        return new RouteEntity
        {
            Id = model.Id,
            RouteCode = model.RouteCode,
            FrontBUSE = model.FrontBUSE,
            RightBUSE = model.RightBUSE,
            RearBUSE = model.RearBUSE,
            RewardMoney = model.RewardMoney,
            RewardPoints = model.RewardPoints,
            Status = model.Status,
            OnlyLowFloor =  model.OnlyLowFloor,
            TwoWay = model.TwoWay,
            AlternativeDrive = model.AlternativeDrive,
            StartPlatformId = model.StartPlatformId,
            FinalPlatformId = model.FinalPlatformId,
            LineId = model.LineId,
            Line = null!,
            StartPlatform = null!,
            FinalPlatform = null!,
        };
    }
}