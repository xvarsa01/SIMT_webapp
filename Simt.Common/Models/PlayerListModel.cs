using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlayerListModel() : ModelBase
{
    public required string Nick { get; set; }
    public  string? ProfileName { get; set; }
    public  string? ProfileCity { get; set; }

    public static PlayerListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Nick = string.Empty,
        ProfileName = null,
        ProfileCity = null
    };
}