using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class LineModelMapper (RouteModelMapper routeModelMapper) : ModelMapperBase<LineEntity, LineListModel, LineDetailModel>
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
            MapId = entity.MapId,
            Routes = routeModelMapper.MapToListModel(entity.Routes),
        };
    }
    
    public override LineEntity MapToEntity(LineDetailModel model)
    {

        return new LineEntity
        {
            Id = model.Id,
            Traction = model.Traction,
            IntervalPeak = model.IntervalPeak,
            IntervalNonPeak = model.IntervalNonPeak,
            IntervalNight = model.IntervalNight,
            MapId = model.MapId,
            LineNumber = model.LineNumber,
            Map = null!,
        };
    }
}