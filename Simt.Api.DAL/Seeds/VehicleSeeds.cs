using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.entities;
using Simt.Common.enums;

namespace Simt.Api.DAL.Seeds;

public static class VehicleSeeds
{
    public static readonly VehicleEntity TatraT3DPP = new ()
    {
        Id = Guid.Parse("32a9226a-1bd8-48f2-b80c-1c123ddd04af"),
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
        Author = "Kiubka",
        GameVersion = "1.5.95 1.5.96 1.6.97 1.6.98 1.6.99",
        Icon = "",
        GoldVersion = true,
        AlternativeDrive = false,
        TwoWay = false,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        Status = Status.InPreparation,
        Traction = Traction.Tram,
        LowFloor = LowFloor.HighFloor
    };
    public static readonly VehicleEntity TatraT3DPP2 = new ()
    {
        Id = Guid.Parse("f3d7e6a2-7364-48aa-9f38-81b3c930992b"),
        Manufacturer = "Tatra",
        Type = "T3R.P",
        Operator = "Dopravní Podnik hl.m. Prahy",
        ManufacturerShort = "Tatra",
        TypeShort = "T3R.P",
        OperatorShort = "DPP",
        VehicleNumber = "8362",
        SCIN = "1044-0013",
        SizeB = "1.6.99-2159 1.7.100-2159",
        Line = null,
        Author = "Kiubka",
        GameVersion = "1.5.95 1.5.96 1.6.97 1.6.98 1.6.99",
        Icon = "",
        GoldVersion = true,
        AlternativeDrive = false,
        TwoWay = false,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        Status = Status.InPreparation,
        Traction = Traction.Tram,
        LowFloor = LowFloor.HighFloor
    };
    public static readonly VehicleEntity TatraT3DPO = new ()
    {
        Id = Guid.Parse("5ea1fb70-8fb6-40cf-bca6-34f1c65b0bfd"),
        Manufacturer = "Tatra",
        Type = "T3R.P",
        Operator = "Dopravní podnik Ostrava",
        ManufacturerShort = "Tatra",
        TypeShort = "T3R.P",
        OperatorShort = "DPO",
        VehicleNumber = "260",
        SCIN = "6-0041",
        SizeB = "1.6.99-0 1.7.100-0 1.8.101-0",
        Line = null,
        Author = "Tomas",
        GameVersion = "1.5.95 1.5.96 1.6.97 1.6.98 1.6.99",
        Icon = "https://simt.cz/img/vozidla/6-0041.jpg",
        GoldVersion = true,
        AlternativeDrive = false,
        TwoWay = false,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        Status = Status.Active,
        Traction = Traction.Tram,
        LowFloor = LowFloor.HighFloor
    };
    public static readonly VehicleEntity Skoda30T = new ()
    {
        Id = Guid.Parse("7a098f55-baa4-44d4-be9f-03cb1b888593"),
        Manufacturer = "Škoda",
        ManufacturerShort = "Škoda",
        Type = "30T",
        TypeShort = "30T",
        Operator = "Dopravný podnik Bratislava",
        OperatorShort = "DPB",
        VehicleNumber = "7501",
        SCIN = "8-0001",
        SizeB = "1.6.99-100 1.7.100-100 1.8.101-100",
        Line = null,
        Author = "Pebrach",
        GameVersion = "1.5.92 1.5.93 1.5.95 1.5.96 1.6.97 1.6.98 1.6.99",
        Icon = "https://simt.cz/img/vozidla/8-0001.jpg",
        GoldVersion = true,
        AlternativeDrive = false,
        TwoWay = true,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        Status = Status.Active,
        Traction = Traction.Tram,
        LowFloor = LowFloor.LowFloor
    };
    
    public static readonly VehicleEntity Skoda32TrDPMJ = new ()
    {
        Id = Guid.Parse("82b07c79-0651-42ac-b9b9-54aeeebb5b5e"),
        Manufacturer = "Škoda",
        ManufacturerShort = "Škoda",
        Type = "32Tr",
        TypeShort = "32Tr",
        Operator = "Dopravní podnik města Jihlavy",
        OperatorShort = "DPMJ",
        VehicleNumber = "11",
        SCIN = "1044-0005",
        SizeB = "1.7.100-6422 1.8.101-6422",
        Line = null,
        Author = "Adam137, Kiubka, Shredder",
        GameVersion = "1.6.99",
        Icon = "https://simt.cz/img/vozidla/1044-0005.jpg",
        GoldVersion = true,
        AlternativeDrive = false,
        TwoWay = false,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        Status = Status.Active,
        Traction = Traction.Trolejbus,
        LowFloor = LowFloor.LowFloor
    };
    
    public static readonly VehicleEntity IrisbusCitelisDPMB = new ()
    {
        Id = Guid.Parse("e6be6043-e58b-4f08-b518-a2cbb76024ef"),
        Manufacturer = "Irisbus",
        ManufacturerShort = "Irisbus",
        Type = "Citelis 12M",
        TypeShort = "Citelis 12M",
        Operator = "Dopravní podnik města Brno",
        OperatorShort = "DPMB",
        VehicleNumber = "7656",
        SCIN = "10-0018",
        SizeB = "1.6.99-771 1.7.100-771 1.8.101-771",
        Line = null,
        Author = "Shredder",
        GameVersion = "1.5.92 1.5.93 1.5.95 1.5.96 1.6.97 1.6.98 1.6.99",
        Icon = "https://simt.cz/img/vozidla/10-0018.jpg",
        GoldVersion = false,
        AlternativeDrive = false,
        TwoWay = false,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        Status = Status.Active,
        Traction = Traction.Bus,
        LowFloor = LowFloor.LowFloor
    };
    
    static VehicleSeeds()
    {
        TatraT3DPP.Services.Add(ServiceSeeds.Service1);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<VehicleEntity>().HasData(
            TatraT3DPP with{Services = Array.Empty<ServiceEntity>()},
            TatraT3DPP2 with{Services = Array.Empty<ServiceEntity>()},
            TatraT3DPO with{Services = Array.Empty<ServiceEntity>()},
            Skoda30T with{Services = Array.Empty<ServiceEntity>()},
            Skoda32TrDPMJ with{Services = Array.Empty<ServiceEntity>()},
            IrisbusCitelisDPMB with{Services = Array.Empty<ServiceEntity>()}
        );
}