using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlatformCreationModel() : ModelBase
{
    public required string PlatformName { get; set; }
    public required bool LowFloor { get; set; }
    
    public required Guid ParentStopId { get; set; }
    public required string ParentStopName { get; set; }
    
    public static PlatformCreationModel EmptyCreation => new()
    {
        Id = Guid.NewGuid(),
        PlatformName = string.Empty,
        LowFloor = false,
        ParentStopId = Guid.Empty,
        ParentStopName = String.Empty,
    };
}