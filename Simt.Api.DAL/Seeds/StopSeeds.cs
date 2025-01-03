using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Seeds;

public static class StopSeeds
{
    public static readonly StopEntity Rolky = new ()
    {
        Id = Guid.Parse("c3e914af-e5bf-4689-a808-5783a674a6d4"),
        StopName = "Rolky",
        FinalStop = true,
        RequestStop = false,
    };
    
    public static readonly StopEntity Fibichova = new ()
    {
        Id = Guid.Parse("0a4c1202-4985-473a-ad36-4fc55ff0648c"),
        StopName = "Fibichova",
        FinalStop = false,
        RequestStop = false,
    };

    public static readonly StopEntity HlavniNadrazi = new ()
    {
        Id = Guid.Parse("dd55e45e-afd4-4c71-9454-5d41ac8995c1"),
        StopName = "Hlavni Nadrazi",
        FinalStop = true,
        RequestStop = false,
    };
    
    public static readonly StopEntity Koprasy = new ()
    {
        Id = Guid.Parse("8bc71901-33ab-487f-bee5-8304d00ffdd4"),
        StopName = "Koprasy",
        FinalStop = true,
        RequestStop = false,
    };
    
    public static readonly StopEntity StrelnaHora = new ()
    {
        Id = Guid.Parse("bdc3df34-195b-4051-bbb4-ff382d9cad3f"),
        StopName = "Strelna Hora",
        FinalStop = true,
        RequestStop = false,
    };
        

    static StopSeeds()
    {
        Rolky.Platforms.Add(PlatformSeeds.RolkyVystup);
        Rolky.Platforms.Add(PlatformSeeds.RolkyNastup);
        
        Fibichova.Platforms.Add(PlatformSeeds.FibichovaA);
        Fibichova.Platforms.Add(PlatformSeeds.FibichovaB);
        
        HlavniNadrazi.Platforms.Add(PlatformSeeds.HlavniNadraziA);
        HlavniNadrazi.Platforms.Add(PlatformSeeds.HlavniNadraziB);
        
        Koprasy.Platforms.Add(PlatformSeeds.KoprasyVystup);
        Koprasy.Platforms.Add(PlatformSeeds.KoprasyNastup);
        
        StrelnaHora.Platforms.Add(PlatformSeeds.StrelnaHoraVystup);
        StrelnaHora.Platforms.Add(PlatformSeeds.StrelnaHoraNastup);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StopEntity>().HasData(
            Rolky with{Platforms = []},
            Fibichova with{Platforms = []},
            HlavniNadrazi with{Platforms = []},
            Koprasy with{Platforms = []},
            StrelnaHora with{Platforms = []}
        );
}