using Simt.BL.Mappers.InterfaceBase;
using Simt.Common.Models;
using Simt.Common.Models.InterfaceBase;
using Simt.DAL.entities;

namespace Simt.BL.Mappers;

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