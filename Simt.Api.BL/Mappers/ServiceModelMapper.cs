using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class ServiceModelMapper : ModelMapperBase<ServiceEntity, ServiceListModel, ServiceDetailModel>
{
    public override ServiceListModel MapToListModel(ServiceEntity? entity)
    {
        if (entity == null)
        {
            return ServiceListModel.Empty;
        }

        return new ServiceListModel
        {
            Id = entity.Id,
            DateTime = entity.DateTime,
            LineDirection = entity.LineDirection,
            PlayerId = entity.PlayerId,
            LineId = entity.LineId,
            LineName = entity.Line.Line,
            LineTraction = entity.Line.Traction,
            VehicleId = entity.VehicleId,
            VehicleNumber = entity.Vehicle.VehicleNumber,
            VehicleType = entity.Vehicle.Type
        };
    }

    public override ServiceDetailModel MapToDetailModel(ServiceEntity? entity)
    {
        if (entity == null)
        {
            return ServiceDetailModel.Empty;
        }

        return new ServiceDetailModel
        {
            Id = entity.Id,
            AvgAhead = entity.AvgAhead,
            AvgDelay = entity.AvgDelay,
            PassengersCarried = entity.PassengersCarried,
            GameMoneyGained = entity.GameMoneyGained,
            DateTime = entity.DateTime,
            Finished = entity.Finished,
            PlayerId = entity.PlayerId,
            LineId = entity.LineId,
            VehicleId = entity.VehicleId,
            LineName = entity.Line.Line,
            LineDirection = entity.LineDirection,
            LineTraction = entity.Line.Traction,
            VehicleType = entity.Vehicle.Type,
            VehicleNumber = entity.Vehicle.VehicleNumber,
        };
    }

    public override ServiceEntity MapToEntity(ServiceDetailModel model)
    {
        return new ServiceEntity
        {
            Id = model.Id,
            AvgAhead = model.AvgAhead,
            AvgDelay = model.AvgDelay,
            PassengersCarried = model.PassengersCarried,
            GameMoneyGained = model.GameMoneyGained,
            DateTime = model.DateTime,
            Finished = model.Finished,
            LineDirection = model.LineDirection,
            PlayerId = model.PlayerId,
            LineId = model.LineId,
            VehicleId = model.VehicleId,
            Player = null!,
            Line = null!,
            Vehicle = null!
        };
    }
}