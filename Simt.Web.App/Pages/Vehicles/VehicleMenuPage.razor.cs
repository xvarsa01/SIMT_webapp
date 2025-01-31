using Microsoft.AspNetCore.Components;

namespace Simt.Web.App.Pages.Vehicles;

public partial class VehicleMenuPage : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; init; } = null!;
    
    private void OpenBuses()
    {
        NavigationManager.NavigateTo($"/vozidla/autobusy");
    }
    private void OpenTrolleybuses()
    {
        NavigationManager.NavigateTo($"/vozidla/trolejbusy");
    }
    
    private void OpenTrams()
    {
        NavigationManager.NavigateTo($"/vozidla/tramvaje");
    }
}