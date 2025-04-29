using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.enums;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class ConditionTramModelMapper : ModelMapperBase<ConditionTramEntity, ConditionTramModel, ConditionTramModel, ConditionTramModel>
{
    public override ConditionTramModel MapToListModel(ConditionTramEntity? entity)
    {
        return MapToDetailModel(entity);
    }
    public override ConditionTramModel MapToDetailModel(ConditionTramEntity? entity)
    {
        if (entity == null)
        {
            return ConditionTramModel.Empty;
        }

        return new ConditionTramModel
        {
            Id = entity.Id,
            Bulbs = entity.Bulbs,
            Battery = entity.Battery,
            Carbons = entity.Carbons,
            AirConditioning = entity.AirConditioning,
            Sand = entity.Sand,
            Wheels = entity.Wheels,
            Paint = entity.Paint,
            Dirt = entity.Dirt,
            Cleaning = entity.Cleaning,
            PlayerNick = entity.Player.Nick,
        };
    }

    public override ConditionTramEntity MapToEntity(ConditionTramModel model)
    {
        return new ConditionTramEntity
        {
            Id = model.Id,
            Bulbs = model.Bulbs,
            Battery = model.Battery,
            Carbons = model.Carbons,
            AirConditioning = model.AirConditioning,
            Sand = model.Sand,
            Wheels = model.Wheels,
            Paint = model.Paint,
            Dirt = model.Dirt,
            Cleaning = model.Cleaning,
            Player = null!,
        };
    }
}
