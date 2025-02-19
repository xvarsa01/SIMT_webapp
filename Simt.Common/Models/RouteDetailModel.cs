using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record RouteDetailModel : RouteCreationModel
{
    public required string? StartStopName { get; set; }
    public required string? FinalStopName { get; set; }
    public required string LineNumber { get; set; }
    public ICollection<RouteStopModel> Stops { get; init; } = [];

    public static RouteDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        RouteCode = string.Empty,
        FrontBUSE = string.Empty,
        RightBUSE = string.Empty,
        RearBUSE = string.Empty,
        RewardMoney = 0,
        RewardPoints = 0,
        Status = Status.InPreparation,
        OnlyLowFloor = false,
        TwoWay = false,
        AlternativeDrive = false,
        StartPlatformId = Guid.Empty,
        FinalPlatformId = Guid.Empty,
        LineId = Guid.Empty,
        StartStopName = string.Empty,
        FinalStopName = string.Empty,
        LineNumber = string.Empty
    };
}