namespace Simt.Api.DAL.entities;

public record ConditionTramEntity() : IEntity
{
    public Guid Id { get; set; }
    public required int Bulbs { get; set; }
    public required int Battery { get; set; }
    public required int Carbons { get; set; }
    public required int AirConditioning { get; set; }
    public required int Sand { get; set; }
    public required int Wheels { get; set; }
    public required int Paint { get; set; }
    public required int Dirt { get; set; }
    public required int Cleaning { get; set; }
    
    // public required Guid PLayerId { get; set; }
    public required PlayerEntity Player { get; init; }

}