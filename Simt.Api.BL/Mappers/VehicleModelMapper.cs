using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class VehicleModelMapper : ModelMapperBase<VehicleEntity, VehicleListModel, VehicleDetailModel>
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
            Operator = entity.Operator,
            Type = entity.Type,
            VehicleNumber = entity.VehicleNumber,
        };
    }

    public override VehicleDetailModel MapToDetailModel(VehicleEntity? entity)
    {
        throw new NotImplementedException();
    }

    public override VehicleEntity MapToEntity(VehicleDetailModel model)
    {
        throw new NotImplementedException();
    }
}