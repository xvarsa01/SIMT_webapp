using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlayerDetailModel() : PlayerCreationModel
{
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