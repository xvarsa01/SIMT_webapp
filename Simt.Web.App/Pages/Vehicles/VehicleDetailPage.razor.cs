using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages.Vehicles;

public partial class VehicleDetailPage : ComponentBase
{
    [Parameter]
    public required string Id { get; init; }

    private Guid _parsedVehicleId;
    
    [Inject]
    public VehicleFacade VehicleFacade { get; set; } = null!;
    
    private VehicleDetailModel? Vehicle { get; set; }

    private bool _found = false;

    protected override async Task OnInitializedAsync()
    {
        if (Guid.TryParse(Id, out Guid guid))
        {
            _parsedVehicleId = guid;
            {
                try
                {
                    Vehicle = await VehicleFacade.GetByIdAsync(_parsedVehicleId);
                    if (Vehicle is null)
                    {
                        Console.WriteLine($"Player profile for '{Vehicle}' not found.");
                    }
                    else
                    {
                        _found = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while loading the profile: {ex.Message}");
                }
            }
            await base.OnInitializedAsync();
        }
    }
}