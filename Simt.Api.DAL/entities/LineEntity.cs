using Simt.Common.enums;

namespace Simt.Api.DAL.entities;

public record LineEntity():IEntity
{
    public required Guid Id { get; set; }
    public required string LineNumber { get; set; }
    public required Traction Traction { get; set; }

    public int IntervalPeak { get; set; }
    public int IntervalNonPeak { get; set; }
    public int IntervalNight { get; set; }

    public required Guid MapId { get; set; }
    public required MapEntity Map { get; set; }
    public ICollection<RouteEntity> Routes { get; init; } = [];
}