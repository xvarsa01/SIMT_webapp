using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class StationModelMapper : ModelMapperBase<StationEntity, StationListModel, StationDetailModel>
{
    public override StationListModel MapToListModel(StationEntity? entity)
    {
        if (entity is null)
        {
            return StationListModel.Empty;
        }

        return new StationListModel
        {
            Id = entity.Id,
            StopName = entity.StopName,
            FinalStop = entity.FinalStop,
        };
    }

    public override StationDetailModel MapToDetailModel(StationEntity? entity)
    {
        if (entity is null)
        {
            return StationDetailModel.Empty;
        }

        return new StationDetailModel
        {
            Id = entity.Id,
            StopName = entity.StopName,
            FinalStop = entity.FinalStop,
            RequestStop = entity.RequestStop,
            LowFloor = entity.LowFloor,
        };
    }
    
    public override StationEntity MapToEntity(StationDetailModel model)
    {
        return new StationEntity
        {
            Id = model.Id,
            StopName = model.StopName,
            FinalStop = model.FinalStop,
            RequestStop = model.FinalStop,
            LowFloor = model.LowFloor,
        };
    }
}