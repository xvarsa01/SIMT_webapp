using Simt.Common.enums;

namespace Simt.Common.Models;

public class PlayerEditProfileModel
{
    public required string Email { get; set; }
    public  string? ProfileName { get; set; }
    public  string? ProfileCity { get; set; }
    public  string? ProfileWeb { get; set; }
    public string? MyStatus{ get; set; }
    public  required int BirthYear { get; set; }

    public required bool Fullscreen { get; set; }
    public required bool AdvancedControl { get; set; }
    public required DisplayResolution DisplayResolution { get; set; }
    
    public VehicleIconModel? FavouriteVehicle { get; set; }
}