namespace Simt.Api.DAL.entities;

public record MapEntity() : IEntity
{
    public required Guid Id { get; set; }
    public required string MapName { get; set; }
    public required string SCIN { get; set; }
    public required DateTime LastChangeTime { get; set; }
    public required int Version { get; set; }
    public required bool Public { get; set; }
    
    public ICollection<LineEntity> Lines { get; init; } = [];
}