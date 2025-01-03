using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class StopModelMapper : ModelMapperBase<StopEntity, StopListModel, StopDetailModel>
{
    public override StopListModel MapToListModel(StopEntity? entity)
    {
        if (entity is null)
        {
            return StopListModel.Empty;
        }

        return new StopListModel
        {
            Id = entity.Id,
            StopName = entity.StopName,
            FinalStop = entity.FinalStop,
        };
    }

    public override StopDetailModel MapToDetailModel(StopEntity? entity)
    {
        if (entity is null)
        {
            return StopDetailModel.Empty;
        }

        return new StopDetailModel
        {
            Id = entity.Id,
            StopName = entity.StopName,
            FinalStop = entity.FinalStop,
            RequestStop = entity.RequestStop,
            LowFloor = entity.LowFloor,
        };
    }
    
    public override StopEntity MapToEntity(StopDetailModel model)
    {
        return new StopEntity
        {
            Id = model.Id,
            StopName = model.StopName,
            FinalStop = model.FinalStop,
            RequestStop = model.FinalStop,
            LowFloor = model.LowFloor,
        };
    }
}