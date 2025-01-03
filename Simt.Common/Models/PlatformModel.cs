using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlatformModel() : ModelBase
{
    public required string PlatformName { get; set; }
    public required bool LowFloor { get; set; }
    
    public required Guid ParentStopId { get; set; }
    
    public List<RouteStopModel> RouteStops { get; set; } = new();
    
    public static PlatformModel Empty => new()
    {
        Id = Guid.NewGuid(),
        PlatformName = string.Empty,
        LowFloor = false,
        ParentStopId = Guid.Empty,
    };
}