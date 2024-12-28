namespace Simt.Api.DAL.entities;

public record MapEntity() : IEntity
{
    public required Guid Id { get; set; }
    public required string MapName { get; set; }
    public required bool Public { get; set; }
}