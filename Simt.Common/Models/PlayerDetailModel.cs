using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlayerDetailModel() : ModelBase
{
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
    public required Guid FavouriteVehicleId {get;set;}
    
    public ICollection<ServiceListModel> Services { get; init; } = [];
    
    public static PlayerDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        GoldVersionExpiration = DateOnly.MinValue,
        Nick = string.Empty,
        Email = string.Empty,
        ProfileName = string.Empty,
        ProfileCity = string.Empty,
        ProfileWeb = string.Empty,
        BirthYear = 0,
        MyStatus = string.Empty,
        RegistrationDate = default,
        LastLogin = 0,
        PlayTime = 0,
        PassengersCarried = 0,
        PointsGained = 0,
        GameMoney = 0,
        Fuel = 0,
        Cng = 0,
        ServiceSpending = 0,
        KmOverall = 0,
        KmYear = 0,
        KmBus = 0,
        KmTBus = 0,
        KmTram = 0,

        Fullscreen = true,
        AdvancedControl = false,
        DisplayResolution = DisplayResolution.Res1920X1080,
        TrafficLevel = TrafficLevel.TrafficLevel3,
        VisibilityLength = VisibilityLength.ViewLength250M,
        FavouriteVehicleId = Guid.Empty,
    };
}