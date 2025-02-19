using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record LineDetailModel() : LineCreationModel
{
    public List<RouteListModel> Routes { get; set; } = new();

    public static LineDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        LineNumber = string.Empty,
        Traction = Traction.Bus,
        IntervalPeak = 0,
        IntervalNonPeak = 0,
        IntervalNight = 0,
        Status = Status.InPreparation,
        MainRoute = String.Empty,
        MapId = Guid.Empty,
        MapName = string.Empty,
    };
}