using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Seeds;

public static class ConditionTramSeeds
{
    public static readonly ConditionTramEntity ConditionTramPlayerAdam = new()
    {
        Id = Guid.Parse("12b86bef-dcda-47d8-a9bf-ac1dea4d1143"),
        Bulbs = 22,
        Battery = 100,
        Carbons = 100,
        AirConditioning = 100,
        Sand = 100,
        Wheels = 100,
        Paint = 100,
        Dirt = 100,
        Cleaning = 100,
        // PLayerId = PlayerSeeds.PlayerAdam.Id,
        Player = PlayerSeeds.PlayerAdam,
    };
    
    public static readonly ConditionTramEntity ConditionTramPlayerPeter = new()
    {
        Id = Guid.Parse("24aa72b3-6f91-4a20-a09c-99366ff358f1"),
        Bulbs = 22,
        Battery = 100,
        Carbons = 100,
        AirConditioning = 100,
        Sand = 100,
        Wheels = 100,
        Paint = 100,
        Dirt = 100,
        Cleaning = 100,
        // PLayerId = PlayerSeeds.PlayerPeter.Id,
        Player = PlayerSeeds.PlayerPeter,
    };

    public static readonly ConditionTramEntity ConditionTramPlayerTomas = new()
    {
        Id = Guid.Parse("5f968afd-e664-42aa-a52b-eae6d3fab703"),
        Bulbs = 22,
        Battery = 100,
        Carbons = 100,
        AirConditioning = 100,
        Sand = 100,
        Wheels = 100,
        Paint = 100,
        Dirt = 100,
        Cleaning = 100,
        // PLayerId = PlayerSeeds.PlayerTomas.Id,
        Player = PlayerSeeds.PlayerTomas,
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ConditionTramEntity>().HasData(
            ConditionTramPlayerAdam,
            ConditionTramPlayerPeter,
            ConditionTramPlayerTomas
        );
}