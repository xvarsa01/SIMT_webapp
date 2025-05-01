namespace Simt.Api.DAL.entities;

public record ConditionTramEntity() : IEntity
{
    public required Guid Id { get; set; }
    public required int Bulbs { get; set; }
    public required int Battery { get; set; }
    public required int Carbons { get; set; }
    public required int AirConditioning { get; set; }
    public required int Sand { get; set; }
    public required int Wheels { get; set; }
    public required int Paint { get; set; }
    public required int Dirt { get; set; }
    public required int Cleaning { get; set; }
    
    public required PlayerEntity Player { get; init; }

    public static ConditionTramEntity Empty => new()
    {
        Id = Guid.NewGuid(),
        Bulbs = 22,
        Battery = 100,
        Carbons = 100,
        AirConditioning = 100,
        Sand = 100,
        Wheels = 100,
        Paint = 100,
        Dirt = 100,
        Cleaning = 100,
        Player = null!,
    };
}