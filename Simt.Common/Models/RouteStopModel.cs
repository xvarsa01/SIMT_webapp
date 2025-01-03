using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record RouteStopModel : ModelBase
{
    public required int NumberOfStopOnLine { get; set; }
    
    public required Guid RouteId { get; set; }
    public required Guid PlatformId { get; set; }

    public static RouteStopModel Empty => new()
    {
        Id = Guid.NewGuid(),
        NumberOfStopOnLine = 0,
        RouteId = Guid.Empty,
        PlatformId = Guid.Empty,
    };
}