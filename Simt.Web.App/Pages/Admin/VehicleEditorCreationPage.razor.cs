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

    private void FlipGoldVersion(bool value) => Vehicle.GoldVersion = value;

    private void FlipAlternativeDrive(bool value) => Vehicle.AlternativeDrive = value;

    private void FlipTwoWay(bool value) => Vehicle.TwoWay = value;

    private void FlipDieselDrive(bool value) => Vehicle.DieselDrive = value;

    private void FlipCNGDrive(bool value) => Vehicle.CngDrive = value;

    private void FlipBatteryDrive(bool value) => Vehicle.BatteryDrive = value;

    private void FlipAirConditioning(bool value) => Vehicle.AirConditioning = value;

    private async Task Save()
    {
        await VehicleFacade.CreateAsync(Vehicle);
        NavigationManager.NavigateTo($"/admin/vozidla");
    }
}