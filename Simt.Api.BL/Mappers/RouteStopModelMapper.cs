using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class RouteStopModelMapper : ModelMapperBase<RouteStopEntity, RouteStopModel, RouteStopModel>
{
    public override RouteStopModel MapToListModel(RouteStopEntity? entity)
    {
        if (entity is null)
        {
            return RouteStopModel.Empty;
        }

        return new RouteStopModel
        {
            Id = entity.Id,
            Platform = entity.Platform,
            NumberOfStopOnLine = entity.NumberOfStopOnLine,
            RouteId = entity.RouteId,
            StopId = entity.StopId,
        };
    }

    public override RouteStopModel MapToDetailModel(RouteStopEntity? entity)
    {
        if (entity is null)
        {
            return RouteStopModel.Empty;
        }

        return new RouteStopModel
        {
            Id = entity.Id,
            Platform = entity.Platform,
            NumberOfStopOnLine = entity.NumberOfStopOnLine,
            RouteId = entity.RouteId,
            StopId = entity.StopId,
        };
    }
    
    public override RouteStopEntity MapToEntity(RouteStopModel model)
    {
        return new RouteStopEntity
        {
            Id = model.Id,
            Platform = model.Platform,
            NumberOfStopOnLine = model.NumberOfStopOnLine,
            RouteId = model.StopId,
            StopId = model.StopId,
            Route = null!,
            Stop = null!,
        };
    }
}