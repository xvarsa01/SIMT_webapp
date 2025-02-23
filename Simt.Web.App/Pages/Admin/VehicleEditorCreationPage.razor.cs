using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages.Admin;

public partial class VehicleEditorCreationPage : ComponentBase
{
    [Inject]
    private VehicleFacade VehicleFacade { get; set; } = null!;
    
    [Parameter]
    public string? Id { get; set; }
    
    public VehicleDetailModel Vehicle { get; set; } = VehicleDetailModel.Empty;

    [Inject]
    public NavigationManager NavigationManager { get; init; } = null!;
    
    
    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(Id) && Guid.TryParse(Id, out Guid parsedId))
        {
            try
            {
                Vehicle = await VehicleFacade.GetByIdAsync(parsedId);
            }
            catch (Exception)
            {
                NavigationManager.NavigateTo("/admin/vozidla");
            }
        }
        else if (!string.IsNullOrEmpty(Id))
        {
            // If the ID is present but not a valid GUID, redirect
            NavigationManager.NavigateTo("/admin/vozidla");
        }
    }
    

    private void FlipGoldVersion(bool value) => Vehicle.GoldVersion = value;

    private void FlipAlternativeDrive(bool value) => Vehicle.AlternativeDrive = value;

    private void FlipTwoWay(bool value) => Vehicle.TwoWay = value;

    private void FlipDieselDrive(bool value) => Vehicle.DieselDrive = value;

    private void FlipCNGDrive(bool value) => Vehicle.CngDrive = value;

    private void FlipBatteryDrive(bool value) => Vehicle.BatteryDrive = value;

    private void FlipAirConditioning(bool value) => Vehicle.AirConditioning = value;

    private async Task Save()
    {
        if (Vehicle.Id == Guid.Empty)
        {
            await VehicleFacade.CreateAsync(Vehicle);
        }
        else
        {
            await VehicleFacade.UpdateAsync(Vehicle);
        }
        NavigationManager.NavigateTo("/admin/vozidla");
    }
}