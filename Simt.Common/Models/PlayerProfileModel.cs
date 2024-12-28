using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlayerProfileModel() : ModelBase
{
    public required string Nick { get; set; }       
    public  string? ProfileName { get; set; }
    public  string? ProfileCity { get; set; }
    public  string? ProfileWeb { get; set; }
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
    
    public static PlayerProfileModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Nick = string.Empty,
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
    };
}