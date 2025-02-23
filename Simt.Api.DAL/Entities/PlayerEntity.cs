using Simt.Common.enums;

namespace Simt.Api.DAL.entities;

public record PlayerEntity:IEntity
{
    public required Guid Id { get; set; }
    public required DateOnly GoldVersionExpiration { get; set; }
    public required string Nick { get; set; }
    public required string Email { get; set; }
    public string? ProfileName { get; set; }
    public string? ProfileCity { get; set; }
    public string? ProfileWeb { get; set; }
    public required int BirthYear { get; set; }
    public string? MyStatus{ get; set; }
    public required DateOnly RegistrationDate { get; set; }
    public required int LastLogin { get; set; }
    public required int PlayTime { get; set; }
    public required int PassengersCarried { get; set; }
    public required int PointsGained { get; set; }
    public required int GameMoney { get; set; }
    public required double Fuel { get; set; }
    public required double Cng { get; set; }
    public required double ServiceSpending { get; set; }
    public required int KmOverall { get; set; }
    public required int KmYear { get; set; }
    
    public required int KmBus { get; set; }
    public required int KmTBus { get; set; }
    public required int KmTram { get; set; }

    public required bool Fullscreen { get; set; }
    public required bool AdvancedControl { get; set; }
    public required DisplayResolution DisplayResolution { get; set; }
    public required TrafficLevel TrafficLevel { get; set; }
    public required VisibilityLength VisibilityLength { get; set; }
    
    public Guid? FavouriteVehicleId { get; set; }
    public VehicleEntity? FavouriteVehicle { get; set; }
    public ICollection<ServiceEntity> Services { get; init; } = [];
}