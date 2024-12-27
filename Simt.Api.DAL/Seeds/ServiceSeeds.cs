using Microsoft.EntityFrameworkCore;
using Simt.DAL.entities;

namespace Simt.DAL.Seeds;

public static class ServiceSeeds
{
    public static readonly ServiceEntity Service1 = new ()
    {
        Id = Guid.NewGuid(),
        AvgAhead = 0,
        AvgDelay = 0,
        PassengersCarried = 0,
        GameMoneyGained = 0,
        DateTime = default,
        LineDirection = "Koprasy",
        Finished = true,
        PlayerId = PlayerSeeds.PlayerAdam.Id,
        LineId = LineSeeds.Line1.Id,
        VehicleId = VehicleSeeds.TatraT3.Id,
        Player = PlayerSeeds.PlayerAdam,
        Line = LineSeeds.Line1,
        Vehicle = VehicleSeeds.TatraT3
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ServiceEntity>().HasData(
            Service1 with { Player = null!, Line = null!, Vehicle = null!}
        );
}