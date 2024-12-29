using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Seeds;

public static class MapSeeds
{
    public static readonly MapEntity TestovaciMapa = new ()
    {
        Id = Guid.Parse("13c67934-37bb-4de3-9b89-14ef3856e62e"),
        MapName = "Testovaci mapa",
        Public = false,
    };
    
    public static readonly MapEntity MapaSimtov = new ()
    {
        Id = Guid.Parse("cbcdc97a-adfc-401e-a7a5-925f020116d4"),
        MapName = "Mapa Simtov",
        Public = true,
    };

    static MapSeeds()
    {
        // TODO why this cant be here????
        // TestovaciMapa.Lines.Add(LineSeeds.Line1);
        // TestovaciMapa.Lines.Add(LineSeeds.Line13);
        // TestovaciMapa.Lines.Add(LineSeeds.Line20);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<MapEntity>().HasData(
            TestovaciMapa with {Lines = [] },
            MapaSimtov with {Lines = [] }
        );
}