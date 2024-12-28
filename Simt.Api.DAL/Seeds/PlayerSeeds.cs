using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Seeds;

public static class PlayerSeeds
{
    public static readonly PlayerEntity PlayerAdam = new()
    {
        Id = Guid.NewGuid(),
        GoldVersionExpiration = default,
        Nick = "Adam137",
        Email = "adam137@gmail.com",
        ProfileName = "Adam",
        ProfileCity = "Bratislava",
        BirthYear = 2003,
        RegistrationDate = DateOnly.Parse("2018-04-14"),
        LastLogin = 0,
        PlayTime = 0,
        PassengersCarried = 0,
        PointsGained = 0,
        GameMoney = 0,
        Fuel = 0,
        Cng = 0,
        ServiceSpending = 0,
        KmOverall = 0,
        KmYear = 0,
        KmBus = 0,
        KmTBus = 0,
        KmTram = 0,
        Fullscreen = true,
        AdvancedControl = true,
        DisplayResolution = DisplayResolution.Res1920X1080,
    };

    public static readonly PlayerEntity PlayerTomas = new()
    {
        Id = Guid.NewGuid(),
        GoldVersionExpiration = DateOnly.MaxValue,
        Nick = "Tomas",
        Email = "tomas@gmail.com",
        RegistrationDate = DateOnly.MinValue,
        LastLogin = 0,
        PlayTime = 0,
        PassengersCarried = 0,
        PointsGained = 0,
        GameMoney = 0,
        Fuel = 0,
        Cng = 0,
        ServiceSpending = 0,
        KmOverall = 0,
        KmYear = 0,
        KmBus = 0,
        KmTBus = 0,
        KmTram = 0,
        BirthYear = 0,
        Fullscreen = true,
        AdvancedControl = true,
        DisplayResolution = DisplayResolution.Res1920X1080,
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