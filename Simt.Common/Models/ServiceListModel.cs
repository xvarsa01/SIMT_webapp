using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record ServiceListModel() : ModelBase
{
    public required DateTime DateTime { get; set; }
    
    public required Guid PlayerId { get; set; }
    public required Guid? RouteId { get; set; }
    public required Guid? VehicleId { get; set; }
    
    public required string LineName { get; set; }
    public required string? LineDirection { get; set; }
    public required Traction? LineTraction { get; set; }
    
    public required string VehicleType { get; set; }
    public required string VehicleNumber { get; set; }

    public static ServiceListModel Empty => new ()
    {
        Id = Guid.NewGuid(),
        DateTime = default,
        PlayerId = Guid.Empty,
        RouteId = Guid.Empty,
        VehicleId = Guid.Empty,
        LineName = String.Empty,
        LineDirection = String.Empty,
        LineTraction = Traction.Bus,
        VehicleType = String.Empty,
        VehicleNumber = String.Empty
    };
}