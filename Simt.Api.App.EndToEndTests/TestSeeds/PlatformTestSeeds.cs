using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Seeds;

namespace Simt.Api.App.EndToEndTests.TestSeeds;

public static class PlatformTestSeeds
{
    public static readonly PlatformEntity RolkyVystup = new ()
    {
        Id = Guid.Parse("5996ca07-617e-4f39-aa23-4fc4d71d3e07"),
        PlatformName = "Rolky vystup",
        LowFloor = true,
        ParentStopId = StopSeeds.Rolky.Id,
        ParentStop = StopSeeds.Rolky,
    };
    public static readonly PlatformEntity RolkyNastup = new ()
    {
        Id = Guid.Parse("b1c91ff5-1acb-4b4e-90de-75e7db1f32e0"),
        PlatformName = "Rolky nastup",
        LowFloor = true,
        ParentStopId = StopSeeds.Rolky.Id,
        ParentStop = StopSeeds.Rolky,
    };
    
    public static readonly PlatformEntity FibichovaA = new ()
    {
        Id = Guid.Parse("b5dcaef9-d42f-48ec-a6ab-2d2344218909"),
        PlatformName = "Fibichova A",
        LowFloor = true,
        ParentStopId = StopSeeds.Fibichova.Id,
        ParentStop = StopSeeds.Fibichova,
    };
    public static readonly PlatformEntity FibichovaB = new ()
    {
        Id = Guid.Parse("3fe0057a-1c47-45c9-9e02-8ade09bceebb"),
        PlatformName = "Fibichova B",
        LowFloor = true,
        ParentStopId = StopSeeds.Fibichova.Id,
        ParentStop = StopSeeds.Fibichova,
    };

    public static readonly PlatformEntity HlavniNadraziA = new ()
    {
        Id = Guid.Parse("dd55e45e-afd4-4c71-9454-5d41ac8995c1"),
        PlatformName = "Hlavni Nadrazi A",
        LowFloor = true,
        ParentStopId = StopSeeds.HlavniNadrazi.Id,
        ParentStop = StopSeeds.HlavniNadrazi,
    };
    public static readonly PlatformEntity HlavniNadraziB = new ()
    {
        Id = Guid.Parse("626abb45-ddc9-4120-8ee6-c2f46e8a8b4f"),
        PlatformName = "Hlavni Nadrazi B",
        LowFloor = true,
        ParentStopId = StopSeeds.HlavniNadrazi.Id,
        ParentStop = StopSeeds.HlavniNadrazi,
    };
    
    public static readonly PlatformEntity KoprasyVystup = new ()
    {
        Id = Guid.Parse("fa806c63-a744-4ad1-b8f5-07bb8f77197b"),
        PlatformName = "Koprasy vystup",
        LowFloor = true,
        ParentStopId = StopSeeds.Koprasy.Id,
        ParentStop = StopSeeds.Koprasy,
    };
    public static readonly PlatformEntity KoprasyNastup = new ()
    {
        Id = Guid.Parse("7c3c99eb-4a3b-4ccb-82d2-ada934cc6f86"),
        PlatformName = "Koprasy nastup",
        LowFloor = true,
        ParentStopId = StopSeeds.Koprasy.Id,
        ParentStop = StopSeeds.Koprasy,
    };
    
    public static readonly PlatformEntity StrelnaHoraVystup = new ()
    {
        Id = Guid.Parse("bdc3df34-195b-4051-bbb4-ff382d9cad3f"),
        PlatformName = "Strelna Hora vystup",
        LowFloor = true,
        ParentStopId = StopSeeds.StrelnaHora.Id,
        ParentStop = StopSeeds.StrelnaHora,
    };
    public static readonly PlatformEntity StrelnaHoraNastup = new ()
    {
        Id = Guid.Parse("1515718c-8e94-4c6d-8d2d-f7a2a05c42dd"),
        PlatformName = "Strelna Hora nastup",
        LowFloor = true,
        ParentStopId = StopSeeds.StrelnaHora.Id,
        ParentStop = StopSeeds.StrelnaHora,
    };
        

    static PlatformTestSeeds()
    {
        FibichovaA.RouteStops.Add(RouteStopSeeds.Route13AFibichovaA);
        FibichovaB.RouteStops.Add(RouteStopSeeds.Route13BFibichovaB);
        
        RolkyNastup.RouteStarts.Add(RouteSeeds.Route13A);
        RolkyVystup.RouteFinals.Add(RouteSeeds.Route13B);
        
        HlavniNadraziA.RouteStarts.Add(RouteSeeds.Route13B);
        HlavniNadraziB.RouteFinals.Add(RouteSeeds.Route13A);
        
        KoprasyNastup.RouteStarts.Add(RouteSeeds.Route1A);
        KoprasyVystup.RouteFinals.Add(RouteSeeds.Route1B);
        
        StrelnaHoraNastup.RouteStarts.Add(RouteSeeds.Route1B);
        StrelnaHoraVystup.RouteFinals.Add(RouteSeeds.Route1A);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<PlatformEntity>().HasData(
            RolkyVystup with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!},
            RolkyNastup with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!},
            FibichovaA with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!},
            FibichovaB with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!},
            HlavniNadraziA with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!},
            HlavniNadraziB with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!},
            KoprasyVystup with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!},
            KoprasyNastup with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!},
            StrelnaHoraVystup with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!},
            StrelnaHoraNastup with{RouteStops = [], RouteStarts = [], RouteFinals = [], ParentStop = null!}
        );
}