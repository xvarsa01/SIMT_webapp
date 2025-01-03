namespace Simt.Api.DAL.entities;

public record StopEntity() : IEntity
{
    public required Guid Id { get; set; }
    public required string? StopName { get; set; }
    public required bool FinalStop { get; set; }
    public required bool RequestStop { get; set; }
    public required bool LowFloor { get; set; }
    public ICollection<RouteStopEntity> LineRouteStops { get; init; } = [];
}