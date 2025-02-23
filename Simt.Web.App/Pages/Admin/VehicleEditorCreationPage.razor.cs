using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages.Admin;

public partial class VehicleEditorCreationPage : ComponentBase
{
    [Inject]
    private VehicleFacade VehicleFacade { get; set; } = null!;
    
    public VehicleDetailModel Vehicle { get; set; } = VehicleDetailModel.Empty;

    [Inject]
    public NavigationManager NavigationManager { get; init; } = null!;

    private void FlipGoldVersion() => Vehicle.GoldVersion = !Vehicle.GoldVersion;

    private void FlipAlternativeDrive() => Vehicle.AlternativeDrive = !Vehicle.AlternativeDrive;

    private void FlipTwoWay() => Vehicle.TwoWay = !Vehicle.TwoWay;

    private void FlipDieselDrive() => Vehicle.DieselDrive = !Vehicle.DieselDrive;

    private void FlipCNGDrive() => Vehicle.CngDrive = !Vehicle.CngDrive;

    private void FlipBatteryDrive() => Vehicle.BatteryDrive = !Vehicle.BatteryDrive;

    private void FlipAirConditioning() => Vehicle.AirConditioning = !Vehicle.AirConditioning;

    private async Task Save()
    {
        await VehicleFacade.CreateAsync(Vehicle);
        NavigationManager.NavigateTo($"/admin/vozidla");
    }
}