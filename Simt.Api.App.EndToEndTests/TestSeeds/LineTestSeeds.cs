using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Seeds;
using Simt.Common.enums;

namespace Simt.Api.App.EndToEndTests.TestSeeds;

public static class LineTestSeeds
{
    public static readonly LineEntity Line1 = new ()
    {
        Id = Guid.Parse("326c41b2-5e91-4173-b6e3-5e690ced68fc"),
        LineNumber = "1",
        Traction = Traction.Tram,
        Status = Status.NonActive,
        MainRoute = null,
        Map = MapSeeds.TestovaciMapa,
        MapId = MapSeeds.TestovaciMapa.Id
    };    
    public static readonly LineEntity Line13 = new ()
    {
        Id = Guid.Parse("c1b6e519-0e9d-4c8d-ae4b-f9feda4737fa"),
        LineNumber = "13",
        Traction = Traction.Trolejbus,
        Status = Status.NonActive,
        MainRoute = null,
        Map = MapSeeds.TestovaciMapa,
        MapId = MapSeeds.TestovaciMapa.Id
    };
    public static readonly LineEntity Line20 = new ()
    {
        Id = Guid.Parse("bfb1aff4-4160-44ed-8cfa-23e81de7f342"),
        LineNumber = "20",
        Traction = Traction.Bus,
        Status = Status.NonActive,
        MainRoute = null,
        Map = MapSeeds.TestovaciMapa,
        MapId = MapSeeds.TestovaciMapa.Id
    };
    
    static LineTestSeeds()
    {
        Line1.Routes.Add(RouteSeeds.Route1A);
        Line1.Routes.Add(RouteSeeds.Route1B);
        Line13.Routes.Add(RouteSeeds.Route13A);
        Line13.Routes.Add(RouteSeeds.Route13B);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<LineEntity>().HasData(
            Line1 with{Routes = [], Map = null!},
            Line13 with{Routes = [], Map = null!},
            Line20 with{Routes = [], Map = null!}
        );
}