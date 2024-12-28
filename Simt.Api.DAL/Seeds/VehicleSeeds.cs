using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Seeds;

public static class VehicleSeeds
{
    public static readonly VehicleEntity TatraT3 = new ()
    {
        Id = Guid.NewGuid(),
        Manufacturer = "Tatra",
        Type = "T3R.P",
        Operator = "Dopravní Podnik hl.m. Prahy",
        VehicleNumber = "8361",
        Scin = "1044-0012",
        SizeB = "1.6.99-2159 1.7.100-2159",
        Line = null,
        Author = null,
        GameVersion = null,
        GoldVersion = true,
        Status = Status.InGame,
        Traction = Traction.Tram,
        LowFloor = LowFloor.HighFloor
    };
    
    static VehicleSeeds()
    {
        TatraT3.Services.Add(ServiceSeeds.Service1);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<VehicleEntity>().HasData(
            TatraT3 with{Services = Array.Empty<ServiceEntity>()}
        );
}