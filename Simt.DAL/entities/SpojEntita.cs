namespace Simt.DAL.entities;

public record SpojEntita:IEntity
{
    public required Guid Id { get; set; }
    public required HracEntita Hrac { get; set; }
    public required LinkaEntita Linka { get; set; }
}