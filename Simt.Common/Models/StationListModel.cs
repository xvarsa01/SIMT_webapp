using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record StationListModel() : ModelBase
{
    public required string StopName { get; set; }
    public required bool FinalStop { get; set; }

    public static StationListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        StopName = string.Empty,
        FinalStop = false,
    };
}