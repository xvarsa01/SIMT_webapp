using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class RouteModelMapper : ModelMapperBase<RouteEntity, RouteListModel, RouteDetailModel>
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
            StartStopId = entity.StartStopId,
            FinalStopId = entity.FinalStopId,
            LineId = entity.LineId,
            StartStopName = entity.StartStop.StopName,
            FinalStopName = entity.FinalStop.StopName,
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
            StartStopId = entity.StartStopId,
            FinalStopId = entity.FinalStopId,
            LineId = entity.LineId,
            StartStopName = entity.StartStop.StopName,
            FinalStopName = entity.FinalStop.StopName,
            LineNumber = entity.Line.LineNumber,
            
            // TODO
            Stops = []
        };
    }
    
    public override RouteEntity MapToEntity(RouteDetailModel model)
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
            StartStopId = model.StartStopId,
            FinalStopId = model.FinalStopId,
            LineId = model.LineId,
            Line = null!,
            StartStop = null!,
            FinalStop = null!,
        };
    }
}