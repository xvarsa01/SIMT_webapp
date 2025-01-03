using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class RouteStopModelMapper : ModelMapperBase<RoutePlatformEntity, RouteStopModel, RouteStopModel>
{
    public override RouteStopModel MapToListModel(RoutePlatformEntity? entity)
    {
        if (entity is null)
        {
            return RouteStopModel.Empty;
        }

        return new RouteStopModel
        {
            Id = entity.Id,
            NumberOfStopOnLine = entity.NumberOfStopOnLine,
            RouteId = entity.RouteId,
            PlatformId = entity.PlatformId,
        };
    }

    public override RouteStopModel MapToDetailModel(RoutePlatformEntity? entity)
    {
        return MapToListModel(entity);
    }
    
    public override RoutePlatformEntity MapToEntity(RouteStopModel model)
    {
        return new RoutePlatformEntity
        {
            Id = model.Id,
            NumberOfStopOnLine = model.NumberOfStopOnLine,
            RouteId = model.RouteId,
            PlatformId = model.PlatformId,
            Route = null!,
            Platform = null!,
        };
    }
}