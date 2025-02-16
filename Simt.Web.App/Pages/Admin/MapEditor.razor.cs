using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages.Admin;

public partial class MapEditor : ComponentBase
{
    [Inject]
    public MapFacade MapFacade { get; set; } = null!;
    [Inject]
    public LineFacade LineFacade { get; set; } = null!;
        
    [Inject]
    public NavigationManager NavigationManager { get; init; } = null!;

    private List<MapListModel> MapLists { get; set; } = new();
    private List<LineListModel> LineList { get; set; } = new();
    private MapDetailModel? MapDetailModel { get; set; }
    private bool _loading = true;
    
    protected override async Task OnInitializedAsync()
    {
        MapLists = await MapFacade.GetAllAsync();
        _loading = false;
    }
    
    private async Task SelectMap(Guid id)
    {
        MapDetailModel = await MapFacade.GetByIdAsync(id);
        LineList = await LineFacade.Line_GetAllByMapAsync(id);

        // Update URL without full page reload
        var newUrl = $"/admin/mapy/?idMapy={id}";
        NavigationManager.NavigateTo(newUrl, forceLoad: false);
    }

    private async Task GetLinesForMap(Guid mapId)
    {
        LineList = await LineFacade.Line_GetAllByMapAsync(mapId);
    }
    
    private async Task SelectLine(Guid lineId)
    {
        NavigationManager.NavigateTo("", forceLoad: false);
        //TODO
    }
    private async Task CreateNewLine(Guid mapId)
    {
        NavigationManager.NavigateTo("", forceLoad: false);
        //TODO
    }

    private void ChangePublic()
    {
        if (MapDetailModel != null) MapDetailModel.Public = !MapDetailModel.Public;
    }

    private async Task Save()
    {
        if (MapDetailModel != null)
        {
            MapDetailModel.LastChangeTime = DateTime.Now;
            await MapFacade.UpdateAsync(MapDetailModel);
            MapDetailModel = null;
        }
    }
}