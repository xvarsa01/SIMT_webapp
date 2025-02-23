using System.ComponentModel.DataAnnotations;
using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record VehicleDetailModel() : ModelBase
{
    [Required(ErrorMessage = "Výrobca je povinný")]
    public required string Manufacturer { get; set; }
    [Required(ErrorMessage = "Typ je povinný")]
    public required string Type { get; set; }
    [Required(ErrorMessage = "Dopravca je povinný")]
    public required string Operator { get; set; }
    [Required(ErrorMessage = "Skratka výrobcu je povinná")]
    public required string ManufacturerShort { get; set; }
    [Required(ErrorMessage = "Skratka typu je povinná")]
    public required string TypeShort { get; set; }
    [Required(ErrorMessage = "Skratka operátora je povinná")]
    public required string OperatorShort { get; set; }
    [Required(ErrorMessage = "Číslo vozu je povinné")]
    public required string VehicleNumber { get; set; }
    [Required(ErrorMessage = "Číslo SCINu je povinné")]
    public required string SCIN { get; set; }
    public string? SizeB { get; set; }
    public string? Line { get; set; }
    public string? Author { get; set; }
    public string? GameVersion { get; set; }
    public string? Icon { get; set; }
    public required bool GoldVersion{ get; set; }
    public required bool AlternativeDrive{ get; set; }
    public required bool TwoWay{ get; set; }
    public required bool DieselDrive{ get; set; }
    public required bool CngDrive{ get; set; }
    public required bool BatteryDrive{ get; set; }
    public required bool AirConditioning{ get; set; }
    
    
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
        Status = Status.InPreparation,
        Traction = Traction.Bus,
        LowFloor = LowFloor.HighFloor
    };
}