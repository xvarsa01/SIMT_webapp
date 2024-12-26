using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record LineListModel() : ModelBase
{
    public required string Line { get; set; }
    public required Traction Traction { get; set; }
}