using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record PlayerPublicProfileModel() : ModelBase
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
    public required float Fuel { get; set; }
    public required float Cng { get; set; }
    public required float ServiceSpending { get; set; }
    public required int KmOverall { get; set; }
    public required int KmYear { get; set; }
    
    public required int KmBus { get; set; }
    public required int KmTBus { get; set; }
    public required int KmTram { get; set; }
}