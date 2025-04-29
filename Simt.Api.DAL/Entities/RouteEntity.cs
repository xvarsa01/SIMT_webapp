using Simt.Common.enums;

namespace Simt.Api.DAL.entities;

public record RouteEntity() : IEntity
{
    public required Guid Id { get; set; }
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
    public required PlatformEntity StartPlatform { get; set; }
    public required PlatformEntity FinalPlatform { get; set; }
    public required LineEntity Line { get; set; }
    public ICollection<RoutePlatformEntity> RouteStops { get; init; } = [];
    
    public ICollection<ServiceEntity> Services { get; init; } = [];
}