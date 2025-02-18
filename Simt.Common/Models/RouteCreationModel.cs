using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record RouteCreationModel : ModelBase
{
    public required string RouteCode { get; set; }
    public required string FrontBUSE { get; set; }
    public required string RightBUSE { get; set; }
    public required string RearBUSE { get; set; }
    
    public required int RewardMoney { get; set; } 
    public required int RewardPoints { get; set; } 

    public required Status Status { get; set; }
    public required bool OnlyLowFloor { get; set; }
    public required bool TwoWay { get; set; }
    public required bool AlternativeDrive{ get; set; }
    
    public string? MenuInfoMessageCz{ get; set; }
    public string? MenuInfoMessageEn{ get; set; }
    public string? MenuInfoMessageDe{ get; set; }
    
    public required Guid StartPlatformId { get; set; }
    public required Guid FinalPlatformId { get; set; }
    public required Guid LineId { get; set; }
    public required string? StartStopName { get; set; }
    public required string? FinalStopName { get; set; }
    public required string LineNumber { get; set; }
    
    public static RouteCreationModel EmptyCreation => new()
    {
        Id = Guid.NewGuid(),
        RouteCode = string.Empty,
        FrontBUSE = string.Empty,
        RightBUSE = string.Empty,
        RearBUSE = string.Empty,
        RewardMoney = 0,
        RewardPoints = 0,
        Status = Status.InGame,
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