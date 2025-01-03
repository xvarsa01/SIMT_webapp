using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;

namespace Simt.Api.DAL.Seeds;

public static class RouteStopSeeds
{
    public static readonly RoutePlatformEntity Route13AFibichovaA = new ()
    {
        Id = Guid.Parse("6bcd2244-c18c-485a-ba60-c877a7d1cc9c"),
        NumberOfStopOnLine = 1,
        RouteId = RouteSeeds.Route13A.Id,
        PlatformId = PlatformSeeds.FibichovaA.Id,
        Route = RouteSeeds.Route13A,
        Platform = PlatformSeeds.FibichovaA,
    };    
    
    public static readonly RoutePlatformEntity Route13BFibichovaB = new ()
    {
        Id = Guid.Parse("ec36fb48-b8d0-4723-98e0-40a8a28c88dd"),
        NumberOfStopOnLine = 1,
        RouteId = RouteSeeds.Route13B.Id,
        PlatformId = PlatformSeeds.FibichovaB.Id,
        Route = RouteSeeds.Route13B,
        Platform = PlatformSeeds.FibichovaB,
    };
    
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<RoutePlatformEntity>().HasData(
            Route13AFibichovaA with{Route = null!, Platform = null!},
            Route13BFibichovaB with{Route = null!, Platform = null!}
        );
}