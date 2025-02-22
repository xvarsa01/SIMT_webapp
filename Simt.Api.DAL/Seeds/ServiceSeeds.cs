using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Seeds;

public static class ServiceSeeds
{
    public static readonly ServiceEntity Service1 = new ()
    {
        Id = Guid.Parse("2edcaf54-ad99-4e22-aba9-7fc80a8c991b"),
        AvgAhead = 0,
        AvgDelay = 0,
        PassengersCarried = 0,
        GameMoneyGained = 0,
        DateTime = default,
        Finished = true,
        PlayerId = PlayerSeeds.PlayerAdam.Id,
        RouteId = RouteSeeds.Route1A.Id,
        VehicleId = VehicleSeeds.TatraT3DPP.Id,
        Player = PlayerSeeds.PlayerAdam,
        Route = RouteSeeds.Route1A,
        Vehicle = VehicleSeeds.TatraT3DPP
    };
    public static readonly ServiceEntity Service2 = new ()
    {
        Id = Guid.Parse("b4fc280b-01fd-48c2-9ac3-f1d72cab6a29"),
        AvgAhead = 0,
        AvgDelay = 0,
        PassengersCarried = 0,
        GameMoneyGained = 0,
        DateTime = default,
        Finished = true,
        PlayerId = PlayerSeeds.PlayerPeter.Id,
        RouteId = RouteSeeds.Route13A.Id,
        VehicleId = VehicleSeeds.TatraT3DPP.Id,
        Player = PlayerSeeds.PlayerPeter,
        Route = RouteSeeds.Route13A,
        Vehicle = VehicleSeeds.TatraT3DPP
    };
    public static readonly ServiceEntity Service3 = new ()
    {
        Id = Guid.Parse("a22610a9-f4b8-4122-a5d9-6243f82c2744"),
        AvgAhead = 0,
        AvgDelay = 0,
        PassengersCarried = 0,
        GameMoneyGained = 0,
        DateTime = default,
        Finished = true,
        PlayerId = PlayerSeeds.PlayerPeter.Id,
        RouteId = RouteSeeds.Route13B.Id,
        VehicleId = VehicleSeeds.TatraT3DPP.Id,
        Player = PlayerSeeds.PlayerPeter,
        Route = RouteSeeds.Route13B,
        Vehicle = VehicleSeeds.TatraT3DPP
    };
    public static readonly ServiceEntity Service4 = new ()
    {
        Id = Guid.Parse("8fbdbdfd-21de-4b19-88b3-53b140087c13"),
        AvgAhead = 0,
        AvgDelay = 0,
        PassengersCarried = 0,
        GameMoneyGained = 0,
        DateTime = default,
        Finished = true,
        PlayerId = PlayerSeeds.PlayerPeter.Id,
        RouteId = RouteSeeds.Route1B.Id,
        VehicleId = VehicleSeeds.TatraT3DPP.Id,
        Player = PlayerSeeds.PlayerPeter,
        Route = RouteSeeds.Route1B,
        Vehicle = VehicleSeeds.TatraT3DPP
    };
    public static readonly ServiceEntity Service5 = new ()
    {
        Id = Guid.Parse("343c92e6-7e07-42ca-8f81-81f94c444a5b"),
        AvgAhead = 5,
        AvgDelay = 15,
        PassengersCarried = 31,
        GameMoneyGained = 0,
        DateTime = DateTime.Now,
        Finished = false,
        PlayerId = PlayerSeeds.PlayerTomas.Id,
        RouteId = RouteSeeds.Route1B.Id,
        VehicleId = VehicleSeeds.TatraT3DPP.Id,
        Player = PlayerSeeds.PlayerTomas,
        Route = RouteSeeds.Route1B,
        Vehicle = VehicleSeeds.TatraT3DPP
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ServiceEntity>().HasData(
            Service1 with{Player = null!, Route = null!, Vehicle = null!},
            Service2 with{Player = null!, Route = null!, Vehicle = null!},
            Service3 with{Player = null!, Route = null!, Vehicle = null!},
            Service4 with{Player = null!, Route = null!, Vehicle = null!},
            Service5 with{Player = null!, Route = null!, Vehicle = null!}
        );
}