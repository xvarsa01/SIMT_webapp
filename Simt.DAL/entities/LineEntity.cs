using AutoMapper;
using Simt.DAL.enums;

namespace Simt.DAL.entities;

public record LineEntity():IEntity
{
    public required Guid Id { get; set; }
    public required string Line { get; set; }
    public Traction Traction { get; set; }

    public ICollection<ServiceEntity> Services { get; init; } = [];
}

public class LineEntityMapperProfile : Profile  
{
    public LineEntityMapperProfile()
    {
        CreateMap<LineEntity, LineEntity>();
    }
}