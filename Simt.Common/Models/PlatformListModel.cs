using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlatformListModel() : ModelBase
{
    public required string PlatformName { get; set; }
    
    public required Guid ParentStopId { get; set; }
    public required string ParentStopName { get; set; }
    
    public static PlatformListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        PlatformName = string.Empty,
        ParentStopId = Guid.Empty,
        ParentStopName = String.Empty,
    };
}