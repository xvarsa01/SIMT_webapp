using AutoMapper;

namespace Simt.DAL.entities;

public record ServiceEntity:IEntity
{
    public required Guid Id { get; set; }
    public required int AvgAhead { get; set; }
    public required int AvgDelay { get; set; }
    public required int PassengersCarried { get; set; }
    public required int GameMoneyGained { get; set; }
    public required DateTime DateTime { get; set; }
    
    public required Guid PlayerId { get; set; }
    public required Guid LineId { get; set; }
    public required Guid VehicleId { get; set; }
    
    public required PlayerEntity Player { get; init; }
    public required LineEntity Line { get; init; }
    public required VehicleEntity Vehicle { get; init; }
}

public class ServiceEntityMapperProfile : Profile  
{
    public ServiceEntityMapperProfile()
    {
        CreateMap<ServiceEntity, ServiceEntity>();
    }
}