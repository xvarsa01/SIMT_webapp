using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record StationDetailModel() : ModelBase
{
    public required string StopName { get; set; }
    public required bool FinalStop { get; set; }
    public required bool RequestStop { get; set; }
    public required bool LowFloor { get; set; }

    public static StationDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        StopName = string.Empty,
        FinalStop = false,
        RequestStop = false,
        LowFloor = false,
    };
}