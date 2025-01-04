using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlatformDetailModel() : ModelBase
{
    public required string PlatformName { get; set; }
    public required bool LowFloor { get; set; }
    
    public required Guid ParentStopId { get; set; }
    public required string ParentStopName { get; set; }
    
    public List<RouteStopModel> RouteStops { get; set; } = new();
    public List<RouteListModel> RouteStarts { get; set; } = new();
    public List<RouteListModel> RouteFinals { get; set; } = new();
    
    public static PlatformDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        PlatformName = string.Empty,
        LowFloor = false,
        ParentStopId = Guid.Empty,
        ParentStopName = String.Empty,
    };
}