using Microsoft.EntityFrameworkCore;
using Simt.DAL.entities;
using Simt.DAL.enums;

namespace Simt.DAL.Seeds;

public static class LineSeeds
{
    public static readonly LineEntity Line1 = new LineEntity
    {
        Id = Guid.NewGuid(),
        Line = "1",
        Traction = Traction.Tram,
        Services = []
    };
    public static readonly LineEntity Line20 = new LineEntity
    {
        Id = Guid.NewGuid(),
        Line = "20",
        Traction = Traction.Bus,
        Services = []
    };
    
    static LineSeeds()
    {
        Line1.Services.Add(ServiceSeeds.Service1);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<LineEntity>().HasData(
            Line1 with{Services = Array.Empty<ServiceEntity>()},
            Line20
        );
}