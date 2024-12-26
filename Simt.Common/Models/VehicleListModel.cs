using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record VehicleListModel() : ModelBase
{
    public required string Manufacturer { get; set; }
    public required string Type { get; set; }
    public required string Operator { get; set; }
    public required string VehicleNumber { get; set; }

    public static VehicleListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Manufacturer = String.Empty,
        Type = String.Empty,
        Operator = String.Empty,
        VehicleNumber = String.Empty,
    };
}