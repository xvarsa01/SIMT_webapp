using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages;

public partial class PlayerSearch : ComponentBase
{
    [Inject]
    public PlayerFacade PlayerFacade { get; set; } = null!;
    
    [Inject]
    public NavigationManager NavigationManager { get; init; } = null!;
    
    private List<PlayerListModel> SearchedPlayers {get; set;} = new List<PlayerListModel>();

    private void OpenProfile(string nick)
    {
        NavigationManager.NavigateTo($"/profil/{nick}");
    }
    private async Task OnSearchChange(ChangeEventArgs args)
    {
        var value = args?.Value?.ToString();
        if (!string.IsNullOrEmpty(value) && value.Length >= 3)
        {
            SearchedPlayers = await PlayerFacade.GetAllSearchedAsync(value);
        }
        else
        {
            SearchedPlayers.Clear();
        }
    }
}