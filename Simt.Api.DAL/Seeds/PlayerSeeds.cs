using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Seeds;

public static class PlayerSeeds
{
    public static readonly PlayerEntity PlayerAdam = new()
    {
        Id = Guid.Parse("404e7e00-b0f9-40d6-a549-32d725f534a5"),
        GoldVersionExpiration = DateOnly.MaxValue,
        Nick = "Adam137",
        Email = "adam137@gmail.com",
        MyStatus = "a",
        ProfileName = "Adam",
        ProfileCity = "Bratislava",
        ProfileWeb = "a",
        BirthYear = 2003,
        RegistrationDate = DateOnly.Parse("2018-04-14"),
        LastLogin = 2,
        PlayTime = 559,
        PassengersCarried = 59474,
        PointsGained = 17613,
        GameMoney = 552548,
        Fuel = 45,
        Cng = 117,
        ServiceSpending = 453031,
        KmOverall = 5589,
        KmYear = 5589,
        KmBus = 1868,
        KmTBus = 2485,
        KmTram = 1236,
        Fullscreen = true,
        AdvancedControl = true,
        DisplayResolution = DisplayResolution.Res1920X1080,
        TrafficLevel = TrafficLevel.TrafficLevel3,
        VisibilityLength = VisibilityLength.ViewLength500M,
        // ConditionBusId = ConditionBusSeeds.ConditionBusPlayerAdam.Id,
        ConditionBus = ConditionBusSeeds.ConditionBusPlayerAdam,
        // ConditionTramId = ConditionTramSeeds.ConditionTramPlayerAdam.Id,
        ConditionTram = ConditionTramSeeds.ConditionTramPlayerAdam,
    };
    
    public static readonly PlayerEntity PlayerTomas = new()
    {
        Id = Guid.Parse("28acb56a-a0e1-4590-953a-6dc69ac98deb"),
        GoldVersionExpiration = DateOnly.MaxValue,
        Nick = "Tomas",
        Email = "tomas@gmail.com",
        ProfileName = "Tomas",
        ProfileCity = "Plzen",
        ProfileWeb = "simt.cz",
        BirthYear = 1990,
        MyStatus = "Nic se neudělá samo... ;)",
        RegistrationDate = DateOnly.MinValue,
        LastLogin = 0,
        PlayTime = 774,
        PassengersCarried = 10142,
        PointsGained = 3065,
        GameMoney = 58344,
        Fuel = 65.0,
        Cng = 224.5974,
        ServiceSpending = 32580,
        KmOverall = 7766,
        KmYear = 1707,
        KmBus = 611,
        KmTBus = 456,
        KmTram = 640,
        Fullscreen = true,
        AdvancedControl = true,
        DisplayResolution = DisplayResolution.Res1920X1080,
        TrafficLevel = TrafficLevel.TrafficLevel3,
        VisibilityLength = VisibilityLength.ViewLength500M,
        // ConditionBusId = ConditionBusSeeds.ConditionBusPlayerTomas.Id,
        ConditionBus = ConditionBusSeeds.ConditionBusPlayerTomas,
        // ConditionTramId = ConditionTramSeeds.ConditionTramPlayerTomas.Id,
        ConditionTram = ConditionTramSeeds.ConditionTramPlayerTomas,
    };
    
    public static readonly PlayerEntity PlayerPeter = new()
    {
        Id = Guid.Parse("6b639161-1713-4179-b96d-8978174b6463"),
        GoldVersionExpiration = DateOnly.MaxValue,
        Nick = "Shredder",
        Email = "petaprihoda@seznam.cz",
        ProfileName = "Shredder",
        ProfileCity = "Jihlava",
        ProfileWeb = "http://shredder.dpsimtov.eu/",
        BirthYear = 0,
        MyStatus = "Jsou lidé schopní, neschopní a pak všehoschopní, ke kterému typu patříš ty, hm? ",
        RegistrationDate = DateOnly.Parse("2013-12-19"),
        LastLogin = 3,
        PlayTime = 6512,
        PassengersCarried = 96740,
        PointsGained = 55059,
        GameMoney = 3546856,
        Fuel = 117.5714,
        Cng = 45.0868,
        ServiceSpending = 1117700,
        KmOverall = 34144,
        KmYear = 20918,
        KmBus = 2003,
        KmTBus = 18814,
        KmTram = 101,
        Fullscreen = true,
        AdvancedControl = true,
        DisplayResolution = DisplayResolution.Res1920X1080,
        TrafficLevel = TrafficLevel.TrafficLevel3,
        VisibilityLength = VisibilityLength.ViewLength500M,
        // ConditionBusId = ConditionBusSeeds.ConditionBusPlayerPeter.Id,
        ConditionBus = ConditionBusSeeds.ConditionBusPlayerPeter,
        // ConditionTramId = ConditionTramSeeds.ConditionTramPlayerPeter.Id,
        ConditionTram = ConditionTramSeeds.ConditionTramPlayerPeter,
    };

    static PlayerSeeds()
    {
        PlayerAdam.Services.Add(ServiceSeeds.Service1);
        PlayerPeter.Services.Add(ServiceSeeds.Service2);
        PlayerPeter.Services.Add(ServiceSeeds.Service3);
        PlayerPeter.Services.Add(ServiceSeeds.Service4);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<PlayerEntity>().HasData(
            PlayerAdam with{Services = []},
            PlayerPeter with{Services = []!},
            PlayerTomas with{Services = []}
        );
}