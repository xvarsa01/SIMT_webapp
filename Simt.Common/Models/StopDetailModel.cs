using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record StopDetailModel() : ModelBase
{
    public required string? StopName { get; set; }
    public required bool FinalStop { get; set; }
    public required bool RequestStop { get; set; }
    
    public List<PlatformListModel> Platforms { get; set; } = new();

    public static StopDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        StopName = string.Empty,
        FinalStop = false,
        RequestStop = false,
    };
}