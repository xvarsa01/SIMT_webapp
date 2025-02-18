using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record StopCreationModel() : ModelBase
{
    public required string? StopName { get; set; }
    public required bool FinalStop { get; set; }
    public required bool RequestStop { get; set; }

    public static StopCreationModel EmptyCreation => new()
    {
        Id = Guid.NewGuid(),
        StopName = string.Empty,
        FinalStop = false,
        RequestStop = false,
    };
}