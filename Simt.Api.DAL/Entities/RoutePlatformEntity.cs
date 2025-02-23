namespace Simt.Api.DAL.entities;

public record RoutePlatformEntity() : IEntity
{
    public required Guid Id { get; set; }
    public required int NumberOfStopOnLine { get; set; }
    
    public required Guid RouteId { get; set; }
    public required Guid PlatformId { get; set; }
    public required RouteEntity Route { get; set; }
    public required PlatformEntity Platform { get; set; }
}