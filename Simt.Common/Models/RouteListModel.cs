using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record RouteListModel : ModelBase
{
    public required string RouteCode { get; set; }
    public required Status Status { get; set; }
    public required Guid StartPlatformId { get; set; }
    public required Guid FinalPlatformId { get; set; }
    public required Guid LineId { get; set; }
    public required string? StartStopName { get; set; }
    public required string? FinalStopName { get; set; }
    public required string LineName { get; set; }

    public static RouteListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        RouteCode = string.Empty,
        Status = Status.InPreparation,
        StartPlatformId = Guid.Empty,
        FinalPlatformId = Guid.Empty,
        LineId = Guid.Empty,
        StartStopName = string.Empty,
        FinalStopName = string.Empty,
        LineName = string.Empty
    };
}