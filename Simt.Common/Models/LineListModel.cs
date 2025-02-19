using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record LineListModel() : ModelBase
{
    public required string LineNumber { get; set; }
    public required Traction Traction { get; set; }
    public required Status Status { get; set; }
    public required string? MainRoute { get; set; }

    public static LineListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        LineNumber = string.Empty,
        Traction = Traction.Bus,
        Status = Status.InPreparation,
        MainRoute = String.Empty
    };
}