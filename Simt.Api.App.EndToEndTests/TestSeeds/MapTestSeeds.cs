using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Seeds;

namespace Simt.Api.App.EndToEndTests.TestSeeds;

public static class MapTestSeeds
{
    public static readonly MapEntity TestovaciMapa = new ()
    {
        Id = Guid.Parse("13c67934-37bb-4de3-9b89-14ef3856e62e"),
        MapName = "Testovaci mapa",
        SCIN = "6-2002",
        LastChangeTime = DateTime.Parse("2024-11-24 11:56:00"),
        Version = 776,
        Public = false,
    };
    
    public static readonly MapEntity MapaSimtov = new ()
    {
        Id = Guid.Parse("cbcdc97a-adfc-401e-a7a5-925f020116d4"),
        MapName = "Mapa Simtov",
        SCIN = "6-2001",
        LastChangeTime = DateTime.Parse("2025-01-02 19:03:00"),
        Version = 13717,
        Public = true,
    };

    static MapTestSeeds()
    {
        TestovaciMapa.Lines.Add(LineSeeds.Line1);
        TestovaciMapa.Lines.Add(LineSeeds.Line13);
        TestovaciMapa.Lines.Add(LineSeeds.Line20);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<MapEntity>().HasData(
            TestovaciMapa with {Lines = [] },
            MapaSimtov with {Lines = [] }
        );
}