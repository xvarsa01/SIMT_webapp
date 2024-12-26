using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record VehicleListModel() : ModelBase
{
    public required string Manufacturer { get; set; }
    public required string Type { get; set; }
    public required string Operator { get; set; }
    public required string VehicleNumber { get; set; }
}