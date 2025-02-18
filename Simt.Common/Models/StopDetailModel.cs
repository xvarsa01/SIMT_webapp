using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record StopDetailModel() : StopCreationModel
{
    public List<PlatformListModel> Platforms { get; set; } = new();

    public static StopDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        StopName = string.Empty,
        FinalStop = false,
        RequestStop = false,
    };
}