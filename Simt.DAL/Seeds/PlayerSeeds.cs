using Microsoft.EntityFrameworkCore;
using Simt.DAL.entities;

namespace Simt.DAL.Seeds;

public static class PlayerSeeds
{
    public static readonly PlayerEntity PlayerAdam = new()
    {
        Id = Guid.NewGuid(),
        Nick = "Adam137",
        LastLogin = 0,
        PlayTime = 0,
        PassengersCarried = 0,
        PointsGained = 0,
        GameMoney = 0,
        Fuel = 0,
        Cng = 0,
        ServisSpending = 0,
        KmOverall = 0,
        KmYear = 0
    };

    public static readonly PlayerEntity PlayerTomas = new()
    {
        Id = Guid.NewGuid(),
        Nick = "Tomas",
        LastLogin = 0,
        PlayTime = 0,
        PassengersCarried = 0,
        PointsGained = 0,
        GameMoney = 0,
        Fuel = 0,
        Cng = 0,
        ServisSpending = 0,
        KmOverall = 0,
        KmYear = 0
    };

    static PlayerSeeds()
    {
        PlayerAdam.Services.Add(ServiceSeeds.Service1);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<PlayerEntity>().HasData(
            PlayerAdam with{Services = Array.Empty<ServiceEntity>()},
            PlayerTomas
        );
}