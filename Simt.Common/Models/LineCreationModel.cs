using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record LineCreationModel() : ModelBase
{
    public required string LineNumber { get; set; }
    public required Traction Traction { get; set; }
    public int IntervalPeak { get; set; }
    public int IntervalNonPeak { get; set; }
    public int IntervalNight { get; set; }
    public required Status Status { get; set; }
    public required string? MainRoute { get; set; }

    public required Guid MapId { get; set; }
    
    public static LineCreationModel EmptyCreation => new()
    {
        Id = Guid.NewGuid(),
        LineNumber = string.Empty,
        Traction = Traction.Bus,
        IntervalPeak = 0,
        IntervalNonPeak = 0,
        IntervalNight = 0,
        Status = Status.InPreparation,
        MainRoute = string.Empty,
        MapId = Guid.Empty,
    };
}