using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record MapDetailModel() : ModelBase
{
    public required string MapName { get; set; }
    public required bool Public { get; set; }

    public static MapDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        MapName = string.Empty,
        Public = false
    };
}