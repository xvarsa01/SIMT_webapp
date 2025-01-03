using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record StopListModel() : ModelBase
{
    public required string? StopName { get; set; }
    public required bool FinalStop { get; set; }

    public static StopListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        StopName = string.Empty,
        FinalStop = false,
    };
}