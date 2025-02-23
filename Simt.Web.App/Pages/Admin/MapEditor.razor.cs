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
    private int _numberOfCreatedLines;
    
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

    private void SelectLine(Guid lineId)
    {
        NavigationManager.NavigateTo($"/lineEditor/{lineId}");
    }
    private async Task CreateNewLine(Guid mapId)
    {
        _numberOfCreatedLines++;
        var lineNumber = $"NOVA {_numberOfCreatedLines}";
        
        LineCreationModel createdModel= LineCreationModel.EmptyCreation with{MapId = mapId, LineNumber = lineNumber };
        await LineFacade.CreateAsync(createdModel);
        
        LineListModel createdModelList = LineListModel.Empty with{LineNumber = lineNumber, Id = createdModel.Id};
        LineList.Add(createdModelList);
        
        // Update MapLists with a new reference so Blazor detects the change
        MapLists = MapLists.Select(m =>
            m.Id == mapId ? m with { LinesCount = m.LinesCount + 1 } : m).ToList();
        
        StateHasChanged();
    }

    private void ChangePublic(bool value)
    {
        if (MapDetailModel != null) MapDetailModel.Public = value;
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