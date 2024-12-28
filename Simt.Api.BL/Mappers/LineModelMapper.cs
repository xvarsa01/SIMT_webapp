using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL.entities;
using Simt.Common.Models;

namespace Simt.Api.BL.Mappers;

public class LineModelMapper : ModelMapperBase<LineEntity, LineListModel, LineDetailModel>
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
            Line = entity.Line,
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
            Traction = entity.Traction,
            Line = entity.Line,
            TotalDrivenCount = entity.Services.Count,
        };
    }
    
    public override LineEntity MapToEntity(LineDetailModel model)
    {

        return new LineEntity
        {
            Id = model.Id,
            Traction = model.Traction,
            Line = model.Line,
        };
    }
}