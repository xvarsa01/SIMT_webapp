using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlatformDetailModel() : PlatformCreationModel
{
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