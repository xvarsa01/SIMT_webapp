using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record MapListModel() : ModelBase
{
    public required string MapName { get; set; }

    public static MapListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        MapName = string.Empty,
    };
}