namespace Simt.Api.DAL.entities;

public record PlatformEntity() : IEntity
{
    public required Guid Id { get; set; }
    public required string PlatformName { get; set; }
    public required bool LowFloor { get; set; }
    
    public required Guid ParentStopId { get; set; }
    public required StopEntity ParentStop { get; set; }
    public ICollection<RouteStopEntity> RouteStops { get; init; } = [];
}