using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages.Admin;

public partial class VehicleEditor : ComponentBase
{
    [Inject]
    public VehicleFacade VehicleFacade { get; set; } = null!;

    private List<VehicleListModel> VehicleList { get; set; } = new();
    private List<string> AllManufacturers { get; set; } = new();
    private List<string> AllTypes { get; set; } = new();
    private List<string> AllOperators { get; set; } = new();
    
    private string selectedManufacturer = "";
    private string selectedType = "";
    private string selectedOperator = "";
    
    protected override async Task OnInitializedAsync()
    {
        VehicleList = await VehicleFacade.GetAllAsync();
    }
    
    private void CreateNewVehicle()
    {
        
    }

    private void EditVehicle(Guid vehicleId)
    {
        
    }

    private void DeleteVehicle(Guid vehicleId)
    {
        
    }
}