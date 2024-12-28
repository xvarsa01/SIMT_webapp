using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record VehicleDetailModel() : ModelBase
{
    public required string Manufacturer { get; set; }
    public required string Type { get; set; }
    public required string Operator { get; set; }
    public required string ManufacturerShort { get; set; }
    public required string TypeShort { get; set; }
    public required string OperatorShort { get; set; }
    public required string VehicleNumber { get; set; }
    public required string SCIN { get; set; }
    public string? SizeB { get; set; }
    public string? Line { get; set; }
    public string? Author { get; set; }
    public string? GameVersion { get; set; }
    public required bool AlternativeDrive{ get; set; }
    public required bool TwoWay{ get; set; }
    public required bool DieselDrive{ get; set; }
    public required bool CngDrive{ get; set; }
    public required bool BatteryDrive{ get; set; }
    public required bool AirConditioning{ get; set; }
    
    public required bool GoldVersion{ get; set; }
    
    public Status Status { get; set; }
    public Traction Traction { get; set; }
    public LowFloor LowFloor { get; set; }

    public static VehicleDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Manufacturer = String.Empty,
        Type = string.Empty,
        Operator = string.Empty,
        ManufacturerShort = string.Empty,
        TypeShort = string.Empty,
        OperatorShort = string.Empty,
        VehicleNumber = String.Empty,
        SCIN = string.Empty,
        SizeB = null,
        Line = null,
        Author = null,
        GameVersion = null,
        GoldVersion = false,
        AlternativeDrive = false,
        TwoWay = false,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        Status = Status.InGame,
        Traction = Traction.Bus,
        LowFloor = LowFloor.HighFloor
    };
}