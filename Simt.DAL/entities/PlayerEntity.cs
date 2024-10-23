using AutoMapper;

namespace Simt.DAL.entities;

public record PlayerEntity:IEntity
{
    public required Guid Id { get; set; }
    public required string Nick { get; set; }
    public required int LastLogin { get; set; }
    public required int PlayTime { get; set; }
    public required int PassengersCarried { get; set; }
    public required int PointsGained { get; set; }
    public required int GameMoney { get; set; }
    public required float Fuel { get; set; }
    public required float Cng { get; set; }
    public required float ServisSpending { get; set; }
    public required int KmOverall { get; set; }
    public required int KmYear { get; set; }

    public ICollection<ServiceEntity> Services { get; init; } = [];
}

public class PlayerEntityMapperProfile : Profile  
{
    public PlayerEntityMapperProfile()
    {
        CreateMap<PlayerEntity, PlayerEntity>();
    }
}