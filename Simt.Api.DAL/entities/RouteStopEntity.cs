namespace Simt.Api.DAL.entities;

public record RouteStopEntity() : IEntity
{
    public required Guid Id { get; set; }
    public required int Platform { get; set; }
    public required int NumberOfStopOnLine { get; set; }
    
    public required Guid RouteId { get; set; }
    public required Guid StopId { get; set; }
    public required RouteEntity Route { get; set; }
    public required StopEntity Stop { get; set; }
}