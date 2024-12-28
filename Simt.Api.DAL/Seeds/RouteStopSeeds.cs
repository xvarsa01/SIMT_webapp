using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Seeds;

public static class RouteStopSeeds
{
    public static readonly RouteStopEntity Route13AFibichova = new ()
    {
        Id = Guid.Parse("6bcd2244-c18c-485a-ba60-c877a7d1cc9c"),
        Platform = 1,
        NumberOfStopOnLine = 1,
        RouteId = RouteSeeds.Route13A.Id,
        StopId = StationSeeds.Fibichova.Id,
        Route = RouteSeeds.Route13A,
        Stop = StationSeeds.Fibichova,
    };    
    
    public static readonly RouteStopEntity Route13BFibichova = new ()
    {
        Id = Guid.Parse("ec36fb48-b8d0-4723-98e0-40a8a28c88dd"),
        Platform = 2,
        NumberOfStopOnLine = 1,
        RouteId = RouteSeeds.Route13B.Id,
        StopId = StationSeeds.Fibichova.Id,
        Route = RouteSeeds.Route13B,
        Stop = StationSeeds.Fibichova,
    };
    
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<RouteEntity>().HasData(
            Route13AFibichova,
            Route13BFibichova
        );
}