using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.enums;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class LineModelMapper (RouteModelMapper routeModelMapper) : ModelMapperBase<LineEntity, LineListModel, LineDetailModel, LineCreationModel>
{
    public override LineListModel MapToListModel(LineEntity? entity)
    {
        if (entity is null)
        {
            return LineListModel.Empty;
        }

        return new LineListModel
        {
            Id = entity.Id,
            Traction = entity.Traction,
            Line = entity.LineNumber,
            Status = entity.Status,
            MainRoute = entity.MainRoute
        };
    }

    public override LineDetailModel MapToDetailModel(LineEntity? entity)
    {
        if (entity is null)
        {
            return LineDetailModel.Empty;
        }

        return new LineDetailModel
        {
            Id = entity.Id,
            LineNumber = entity.LineNumber,
            Traction = entity.Traction,
            IntervalPeak = entity.IntervalPeak,
            IntervalNonPeak = entity.IntervalNonPeak,
            IntervalNight = entity.IntervalNight,
            Status = entity.Status,
            MainRoute = entity.MainRoute,
            MapId = entity.MapId,
            MapName = entity.Map.MapName,
            Routes = routeModelMapper.MapToListModel(entity.Routes),
        };
    }
    
    public override LineEntity MapToEntity(LineCreationModel model)
    {

        return new LineEntity
        {
            Id = model.Id,
            Traction = model.Traction,
            IntervalPeak = model.IntervalPeak,
            IntervalNonPeak = model.IntervalNonPeak,
            IntervalNight = model.IntervalNight,
            Status = model.Status,
            MainRoute = model.MainRoute,
            MapId = model.MapId,
            LineNumber = model.LineNumber,
            Map = null!,
        };
    }
}