using Simt.DAL.enums;

namespace Simt.DAL.entities;

public record LinkaEntita():IEntity
{
    public required Guid Id { get; set; }
    public required string Linka { get; set; }
    public Trakcie Trakcia { get; set; }

    public ICollection<SpojEntita> Spoje { get; init; } = [];
}