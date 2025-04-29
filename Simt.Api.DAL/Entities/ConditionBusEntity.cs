namespace Simt.Api.DAL.entities;

public record ConditionBusEntity() : IEntity
{
    public Guid Id { get; set; }
    public required int Bulbs { get; set; }
    public required int BrakeLining { get; set; }
    public required int Filters { get; set; }
    public required int Silencers { get; set; }
    public required int PaintRepairs { get; set; }
    public required int Tires { get; set; }
    public required int Cleaning { get; set; }
    public required int Battery { get; set; }
    public required int Corrosion { get; set; }
    public required int Dirt { get; set; }
    public required int AirDevice { get; set; }
    public required int TechnicalInspection { get; set; }
    
    // public required Guid PLayerId { get; set; }
    public required PlayerEntity Player { get; init; }
}