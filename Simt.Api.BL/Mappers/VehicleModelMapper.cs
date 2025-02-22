using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class VehicleModelMapper : ModelMapperBase<VehicleEntity, VehicleListModel, VehicleDetailModel, VehicleDetailModel>
{
    public override VehicleListModel MapToListModel(VehicleEntity? entity)
    {
        if (entity == null)
        {
            return VehicleListModel.Empty;
        }

        return new VehicleListModel
        {
            Id = entity.Id,
            Manufacturer = entity.Manufacturer,
            Type = entity.Type,
            Operator = entity.Operator,
            OperatorShort = entity.OperatorShort,
            VehicleNumber = entity.VehicleNumber,
            SCIN = entity.SCIN,
            SizeB = entity.SizeB,
            Author = entity.Author,
            GameVersion = entity.GameVersion,
            Icon = entity.Icon,
            GoldVersion = entity.GoldVersion,
            Status = entity.Status,
        };
    }

    public override VehicleDetailModel MapToDetailModel(VehicleEntity? entity)
    {
        if (entity == null)
        {
            return VehicleDetailModel.Empty;
        }

        return new VehicleDetailModel
        {
            Id = entity.Id,
            Manufacturer = entity.Manufacturer,
            Type = entity.Type,
            Operator = entity.Operator,
            ManufacturerShort = entity.ManufacturerShort,
            TypeShort = entity.TypeShort,
            OperatorShort = entity.OperatorShort,
            VehicleNumber = entity.VehicleNumber,
            SCIN = entity.SCIN,
            SizeB = entity.SizeB,
            Line = entity.Line,
            Author = entity.Author,
            GameVersion = entity.GameVersion,
            Icon = entity.Icon,
            GoldVersion = entity.GoldVersion,
            AlternativeDrive = entity.AlternativeDrive,
            TwoWay = entity.TwoWay,
            DieselDrive = entity.DieselDrive,
            CngDrive = entity.CngDrive,
            BatteryDrive = entity.BatteryDrive,
            AirConditioning = entity.AirConditioning,
            Status = entity.Status,
            Traction = entity.Traction,
            LowFloor = entity.LowFloor,
        };
    }

    public override VehicleEntity MapToEntity(VehicleDetailModel model)
    {
        return new VehicleEntity
        {
            Id = model.Id,
            Manufacturer = model.Manufacturer,
            Type = model.Type,
            Operator = model.Operator,
            ManufacturerShort = model.ManufacturerShort,
            TypeShort = model.TypeShort,
            OperatorShort = model.OperatorShort,
            VehicleNumber = model.VehicleNumber,
            SCIN = model.SCIN,
            SizeB = model.SizeB,
            Line = model.Line,
            Author = model.Author,
            GameVersion = model.GameVersion,
            Icon = model.Icon,
            GoldVersion = model.GoldVersion,
            AlternativeDrive = model.AlternativeDrive,
            TwoWay = model.TwoWay,
            DieselDrive = model.DieselDrive,
            CngDrive = model.CngDrive,
            BatteryDrive = model.BatteryDrive,
            AirConditioning = model.AirConditioning,
            Status = model.Status,
            Traction = model.Traction,
            LowFloor = model.LowFloor,
        };
    }
}