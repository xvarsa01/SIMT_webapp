using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record RouteStopModel : ModelBase
{
    public required int Platform { get; set; }
    public required int NumberOfStopOnLine { get; set; }
    
    public required Guid RouteId { get; set; }
    public required Guid StopId { get; set; }

    public static RouteStopModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Platform = 0,
        NumberOfStopOnLine = 0,
        RouteId = Guid.Empty,
        StopId = Guid.Empty,
    };
}