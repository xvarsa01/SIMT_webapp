using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record MapListModel() : ModelBase
{
    public required string MapName { get; set; }
    public required string SCIN { get; set; }
    public required DateTime LastChangeTime { get; set; }
    public required int Version { get; set; }
    public required int LinesCount { get; set; }
    public required int RoutesCount { get; set; }

    public static MapListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        MapName = string.Empty,
        SCIN = string.Empty,
        LastChangeTime = DateTime.Now,
        Version = 0,
        LinesCount = 0,
        RoutesCount = 0,
    };
}