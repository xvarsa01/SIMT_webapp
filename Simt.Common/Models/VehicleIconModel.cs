using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record VehicleIconModel : ModelBase
{
    public string? Icon { get; set; }
    public string? Description { get; set; }
}