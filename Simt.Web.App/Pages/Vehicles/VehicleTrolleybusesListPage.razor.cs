using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages.Vehicles;

public partial class VehicleTrolleybusesListPage : ComponentBase
{
    [Inject]
    public VehicleFacade VehicleFacade { get; set; } = null!;
    
    [Inject]
    public NavigationManager NavigationManager { get; init; } = null!;
    
    private List<VehicleListModel> TrolleybusesList {get; set;} = new();
    
    protected override async Task OnInitializedAsync()
    {
        TrolleybusesList = await VehicleFacade.GetAllTrolleybusesAsync();
        await base.OnInitializedAsync();
    }
    
    private void OpenDetail(Guid id)
    {
        NavigationManager.NavigateTo($"/vozidla/{id}");
    }
    
    // TODO switch method after API function that returns tram detail from number + operator
    // private void OpenDetail(string number, string @operator)
    // {
    //     NavigationManager.NavigateTo($"/vozidla/{number}_{@operator}");
    // }
}