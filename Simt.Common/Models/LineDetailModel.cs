using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record LineDetailModel() : ModelBase
{
    public required string Line { get; set; }
    public required Traction Traction { get; set; }
    public  required int TotalDrivenCount { get; set; }
    
    public List<ServiceListModel> Services { get; set; } = new();

    public static LineDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Line = string.Empty,
        Traction = Traction.Bus,
        TotalDrivenCount = 0
    };
}