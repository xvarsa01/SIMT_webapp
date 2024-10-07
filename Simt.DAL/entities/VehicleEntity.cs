namespace Simt.DAL.entities;

public record VehicleEntity:IEntity
{
    public required Guid Id { get; set; }
    
    
    public ICollection<ServiceEntity> Services { get; init; } = [];
}