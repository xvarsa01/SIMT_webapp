using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record VehicleDetailModel() : ModelBase
{
    public required string Manufacturer { get; set; }
    public required string Type { get; set; }
    public required string Operator { get; set; }
    public required string VehicleNumber { get; set; }
    public required string Scin { get; set; }
    public string? SizeB { get; set; }
    public string? Line { get; set; }
    public string? Author { get; set; }
    public string? GameVersion { get; set; }
    
    public required bool GoldVersion{ get; set; }
    
    public Status Status { get; set; }
    public Traction Traction { get; set; }
    public LowFloor LowFloor { get; set; }
}