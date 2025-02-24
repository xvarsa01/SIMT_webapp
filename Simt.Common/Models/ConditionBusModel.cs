using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record ConditionBusModel() : ModelBase
{
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
    
    public required Guid PLayerId { get; set; }
    
    public static ConditionBusModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Bulbs = 22,
        BrakeLining = 100,
        Filters = 100,
        Silencers = 100,
        PaintRepairs = 100,
        Tires = 100,
        Cleaning = 100,
        Battery = 100,
        Corrosion = 100,
        Dirt = 100,
        AirDevice = 30,
        TechnicalInspection = 365,
        PLayerId = Guid.Empty,
    };
}