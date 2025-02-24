using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Seeds;

public static class ConditionBusSeeds
{
    public static readonly ConditionBusEntity ConditionBusPlayerAdam = new()
    {
        Id = Guid.Parse("12b86bef-dcda-47d8-a9bf-ac1dea4d1143"),
        Bulbs = 22,
        BrakeLining = 100,
        Filters = 100,
        Silencers = 100,
        PaintRepairs = 100,
        Tires = 100,
        Cleaning = 100,
        Battery = 100,
        Corrosion = 100,
        Dirt = 0,
        AirDevice = 30,
        TechnicalInspection = 365,
        PLayerId = PlayerSeeds.PlayerAdam.Id,
        Player = PlayerSeeds.PlayerAdam
    };
    
    public static readonly ConditionBusEntity ConditionBusPlayerPeter = new()
    {
        Id = Guid.Parse("407d2c6f-ab4c-49a0-bae1-2379382f5602"),
        Bulbs = 22,
        BrakeLining = 100,
        Filters = 100,
        Silencers = 100,
        PaintRepairs = 100,
        Tires = 100,
        Cleaning = 100,
        Battery = 100,
        Corrosion = 100,
        Dirt = 0,
        AirDevice = 30,
        TechnicalInspection = 365,
        PLayerId = PlayerSeeds.PlayerPeter.Id,
        Player = PlayerSeeds.PlayerPeter
    };
    
    public static readonly ConditionBusEntity ConditionBusPlayerTomas = new()
    {
        Id = Guid.Parse("8b0cffa5-bc44-4182-b035-031c83d53b04"),
        Bulbs = 22,
        BrakeLining = 100,
        Filters = 100,
        Silencers = 100,
        PaintRepairs = 100,
        Tires = 100,
        Cleaning = 100,
        Battery = 100,
        Corrosion = 100,
        Dirt = 0,
        AirDevice = 30,
        TechnicalInspection = 365,
        PLayerId = PlayerSeeds.PlayerTomas.Id,
        Player = PlayerSeeds.PlayerTomas
    };
    
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ConditionBusEntity>().HasData(
            ConditionBusPlayerAdam with{Player = null!},
            ConditionBusPlayerPeter with{Player = null!},
            ConditionBusPlayerTomas with{Player = null!}
        );
}