﻿using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Seeds;

public static class RouteSeeds
{
    public static readonly RouteEntity Route1A = new ()
    {
        Id = Guid.Parse("2a93b7f8-2945-42c3-8fa8-4d462a8a3957"),
        RouteCode = "A",
        FrontBUSE = "1 Strelna Hora",
        RightBUSE = "1 Strelna Hora",
        RearBUSE = "1",
        RewardMoney = 0,
        RewardPoints = 0,
        Status = Status.Active,
        OnlyLowFloor = false,
        TwoWay = false,
        AlternativeDrive = false,
        StartPlatformId = PlatformSeeds.KoprasyNastup.Id,
        FinalPlatformId = PlatformSeeds.StrelnaHoraVystup.Id,
        LineId = LineSeeds.Line1.Id,
        StartPlatform = PlatformSeeds.KoprasyNastup,
        FinalPlatform = PlatformSeeds.StrelnaHoraVystup,
        Line = LineSeeds.Line1,
    };    
    public static readonly RouteEntity Route1B = new ()
    {
        Id = Guid.Parse("2e4342ef-1fb0-42e1-85e9-ddb9cc7b2740"),
        RouteCode = "B",
        FrontBUSE = "1 Koprasy",
        RightBUSE = "1 Koprasy",
        RearBUSE = "1",
        RewardMoney = 0,
        RewardPoints = 0,
        Status = Status.Active,
        OnlyLowFloor = false,
        TwoWay = false,
        AlternativeDrive = false,
        StartPlatformId = PlatformSeeds.StrelnaHoraNastup.Id,
        FinalPlatformId = PlatformSeeds.KoprasyVystup.Id,
        LineId = LineSeeds.Line1.Id,
        StartPlatform = PlatformSeeds.StrelnaHoraNastup,
        FinalPlatform = PlatformSeeds.KoprasyVystup,
        Line = LineSeeds.Line1,
    };
    public static readonly RouteEntity Route13A = new ()
    {
        Id = Guid.Parse("8e58d49f-6bda-47df-a8f6-8e7b901dd739"),
        RouteCode = "A",
        FrontBUSE = "13 Hlavni Nadrazi",
        RightBUSE = "13 Hlavni Nadrazi",
        RearBUSE = "13",
        RewardMoney = 0,
        RewardPoints = 0,
        Status = Status.Active,
        OnlyLowFloor = false,
        TwoWay = false,
        AlternativeDrive = false,
        StartPlatformId = PlatformSeeds.RolkyNastup.Id,
        FinalPlatformId = PlatformSeeds.HlavniNadraziB.Id,
        LineId = LineSeeds.Line13.Id,
        StartPlatform = PlatformSeeds.RolkyNastup,
        FinalPlatform = PlatformSeeds.HlavniNadraziB,
        Line = LineSeeds.Line13,
    };    
    public static readonly RouteEntity Route13B = new ()
    {
        Id = Guid.Parse("feae0ac8-7de1-4d9e-97b9-3b149e331d76"),
        RouteCode = "B",
        FrontBUSE = "13 Koprasy",
        RightBUSE = "13 Koprasy",
        RearBUSE = "13",
        RewardMoney = 0,
        RewardPoints = 0,
        Status = Status.Active,
        OnlyLowFloor = false,
        TwoWay = false,
        AlternativeDrive = false,
        StartPlatformId = PlatformSeeds.HlavniNadraziA.Id,
        FinalPlatformId = PlatformSeeds.RolkyVystup.Id,
        LineId = LineSeeds.Line13.Id,
        StartPlatform = PlatformSeeds.HlavniNadraziA,
        FinalPlatform = PlatformSeeds.RolkyVystup,
        Line = LineSeeds.Line13,
    };
   
    
    static RouteSeeds()
    {
        Route13A.RouteStops.Add(RouteStopSeeds.Route13AFibichovaA);
        Route13B.RouteStops.Add(RouteStopSeeds.Route13BFibichovaB);
        
        Route1A.Services.Add(ServiceSeeds.Service1);
        Route13A.Services.Add(ServiceSeeds.Service2);
        Route13B.Services.Add(ServiceSeeds.Service3);
        Route1B.Services.Add(ServiceSeeds.Service4);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<RouteEntity>().HasData(
            Route1A with{RouteStops = [], Services = [], FinalPlatform = null!, StartPlatform = null!, Line = null!},
            Route1B with{RouteStops = [], Services = [], FinalPlatform = null!, StartPlatform = null!, Line = null!},
            Route13A with{RouteStops = [], Services = [], FinalPlatform = null!, StartPlatform = null!, Line = null!},
            Route13B with{RouteStops = [], Services = [], FinalPlatform = null!, StartPlatform = null!, Line = null!}
        );
}