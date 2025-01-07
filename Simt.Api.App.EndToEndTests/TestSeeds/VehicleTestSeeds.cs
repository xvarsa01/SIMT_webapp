using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Seeds;
using Simt.Common.enums;

namespace Simt.Api.App.EndToEndTests.TestSeeds;

public static class VehicleTestSeeds
{
    public static readonly VehicleEntity TatraT3 = new ()
    {
        Id = Guid.NewGuid(),
        Manufacturer = "Tatra",
        Type = "T3R.P",
        Operator = "Dopravní Podnik hl.m. Prahy",
        ManufacturerShort = "Tatra",
        TypeShort = "T3R.P",
        OperatorShort = "DPP",
        VehicleNumber = "8361",
        SCIN = "1044-0012",
        SizeB = "1.6.99-2159 1.7.100-2159",
        Line = null,
        Author = null,
        GameVersion = null,
        AlternativeDrive = false,
        TwoWay = false,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        GoldVersion = true,
        Status = Status.InGame,
        Traction = Traction.Tram,
        LowFloor = LowFloor.HighFloor
    };
    
    public static readonly VehicleEntity VehicleForRemove = new ()
    {
        Id = Guid.Parse("94ac1ce1-7f6b-40a0-b57a-f43a8e047791"),
        Manufacturer = "Tatra",
        Type = "T3R.P",
        Operator = "Dopravní Podnik hl.m. Prahy",
        ManufacturerShort = "Tatra",
        TypeShort = "T3R.P",
        OperatorShort = "DPP",
        VehicleNumber = "8361",
        SCIN = "1044-0012",
        SizeB = "1.6.99-2159 1.7.100-2159",
        Line = null,
        Author = null,
        GameVersion = null,
        AlternativeDrive = false,
        TwoWay = false,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        GoldVersion = true,
        Status = Status.InGame,
        Traction = Traction.Tram,
        LowFloor = LowFloor.HighFloor
    };

    
    static VehicleTestSeeds()
    {
        TatraT3.Services.Add(ServiceSeeds.Service1);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<VehicleEntity>().HasData(
            TatraT3 with{Services = Array.Empty<ServiceEntity>()},
            VehicleForRemove with{Services = Array.Empty<ServiceEntity>()}
        );
}