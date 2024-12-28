using AutoMapper;
using Simt.Common.enums;

namespace Simt.Api.DAL.entities;

public record VehicleEntity:IEntity
{
    public required Guid Id { get; set; }
    
    public required string Manufacturer { get; set; }
    public required string Type { get; set; }
    public required string Operator { get; set; }
    public required string VehicleNumber { get; set; }
    public required string Scin { get; set; }
    public string? SizeB { get; set; }
    public string? Line { get; set; }
    public string? Author { get; set; }
    public string? GameVersion { get; set; }
    public string? Icon { get; set; }
    public required bool GoldVersion{ get; set; }
    
    public Status Status { get; set; }
    public Traction Traction { get; set; }
    public LowFloor LowFloor { get; set; }
    
    public ICollection<ServiceEntity> Services { get; init; } = [];
}

public class VehicleEntityMapperProfile : Profile
{
    public VehicleEntityMapperProfile()
    {
        CreateMap<VehicleEntity, VehicleEntity>();
    }
}