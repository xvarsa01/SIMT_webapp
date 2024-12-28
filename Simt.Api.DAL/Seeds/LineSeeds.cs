using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Seeds;

public static class LineSeeds
{
    public static readonly LineEntity Line1 = new ()
    {
        Id = Guid.Parse("326c41b2-5e91-4173-b6e3-5e690ced68fc"),
        LineNumber = "1",
        Traction = Traction.Tram,
        Map = MapSeeds.TestovaciMapa,
        MapId = MapSeeds.TestovaciMapa.Id
    };    
    public static readonly LineEntity Line13 = new ()
    {
        Id = Guid.Parse("c1b6e519-0e9d-4c8d-ae4b-f9feda4737fa"),
        LineNumber = "13",
        Traction = Traction.Trolejbus,
        Map = MapSeeds.TestovaciMapa,
        MapId = MapSeeds.TestovaciMapa.Id
    };
    public static readonly LineEntity Line20 = new ()
    {
        Id = Guid.Parse("bfb1aff4-4160-44ed-8cfa-23e81de7f342"),
        LineNumber = "20",
        Traction = Traction.Bus,
        Map = MapSeeds.TestovaciMapa,
        MapId = MapSeeds.TestovaciMapa.Id
    };
    
    static LineSeeds()
    {
        Line1.Services.Add(ServiceSeeds.Service1);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<LineEntity>().HasData(
            Line1 with{Services = []},
            Line13 with{Services = []},
            Line20 with{Services = []}
        );
}