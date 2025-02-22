using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record VehicleListModel() : ModelBase
{
    public required string Manufacturer { get; set; }
    public required string Type { get; set; }
    public required string Operator { get; set; }
    public required string OperatorShort { get; set; }
    public required string VehicleNumber { get; set; }
    public required string SCIN { get; set; }
    public string? SizeB { get; set; }
    public string? Author { get; set; }
    public string? GameVersion { get; set; }
    public string? Icon { get; set; }
    public required bool GoldVersion{ get; set; }
    public Status Status { get; set; }

    public static VehicleListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Manufacturer = String.Empty,
        Type = String.Empty,
        Operator = String.Empty,
        OperatorShort = string.Empty,
        VehicleNumber = string.Empty,
        SCIN = string.Empty,
        SizeB = null,
        Author = null,
        GameVersion = null,
        Icon = null,
        GoldVersion = false,
        Status = Status.InPreparation,
    };
}