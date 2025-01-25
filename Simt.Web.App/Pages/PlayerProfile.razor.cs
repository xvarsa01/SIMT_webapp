using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages;

public partial class PlayerProfile : ComponentBase
{
    [Parameter]
    public required string Nick { get; init; }
    
    [Inject]
    public PlayerFacade PlayerFacade { get; set; } = null!;
    [Inject]
    public ServiceFacade ServiceFacade { get; set; } = null!;
    
    private PlayerDetailModel? Player { get; set; }
    private List<ServiceDetailModel> ServicesOfPlayer { get; set; } = new();
    private const int CurrentPageSize = 1;
    private int _pageNumber = 0;

    private bool _found = false;
    
    protected override async Task OnInitializedAsync()
    {
        if (Nick != string.Empty)
        {
            try
            {
                Player = await PlayerFacade.GetByNickAsync(Nick);
                if (Player is null)
                {
                    Console.WriteLine($"Player profile for '{Nick}' not found.");
                }
                else
                {
                    _found = true;
                    ServicesOfPlayer = await ServiceFacade.GetAllForPlayerAsync(Player.Id, _pageNumber, CurrentPageSize);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the profile: {ex.Message}");
            }
        }
        await base.OnInitializedAsync();
    }

    private async Task LoadMoreServices()
    {
        try
        {
            _pageNumber++;
            var newServices = await ServiceFacade.GetAllForPlayerAsync(Player!.Id, _pageNumber, CurrentPageSize);
            ServicesOfPlayer.AddRange(newServices);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load more services: {ex.Message}");
        }
    }
}