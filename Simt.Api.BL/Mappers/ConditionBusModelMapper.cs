using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.enums;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class ConditionBusModelMapper : ModelMapperBase<ConditionBusEntity, ConditionBusModel, ConditionBusModel, ConditionBusModel>
{
    public override ConditionBusModel MapToListModel(ConditionBusEntity? entity)
    {
        return MapToDetailModel(entity);
    }
    public override ConditionBusModel MapToDetailModel(ConditionBusEntity? entity)
    {
        if (entity == null)
        {
            return ConditionBusModel.Empty;
        }

        return new ConditionBusModel
        {
            Id = entity.Id,
            Bulbs = entity.Bulbs,
            BrakeLining = entity.BrakeLining,
            Filters = entity.Filters,
            Silencers = entity.Silencers,
            PaintRepairs = entity.PaintRepairs,
            Tires = entity.Tires,
            Cleaning = entity.Cleaning,
            Battery = entity.Battery,
            Corrosion = entity.Corrosion,
            Dirt = entity.Dirt,
            AirDevice = entity.AirDevice,
            TechnicalInspection = entity.TechnicalInspection,
            PlayerNick = entity.Player.Nick,
        };
    }

    public override ConditionBusEntity MapToEntity(ConditionBusModel model)
    {
        return new ConditionBusEntity
        {
            Id = model.Id,
            Bulbs = model.Bulbs,
            BrakeLining = model.BrakeLining,
            Filters = model.Filters,
            Silencers = model.Silencers,
            PaintRepairs = model.PaintRepairs,
            Tires = model.Tires,
            Cleaning = model.Cleaning,
            Battery = model.Battery,
            Corrosion = model.Corrosion,
            Dirt = model.Dirt,
            AirDevice = model.AirDevice,
            TechnicalInspection = model.TechnicalInspection,
            Player = null!,
        };
    }
}