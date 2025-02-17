using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages.Admin;

public partial class LineEditor : ComponentBase
{
    [Parameter]
    public string LineIdString { get; set; } = null!;

    private Guid _lineIdGuid;
    private bool _notFound;
    
    [Inject]
    public LineFacade LineFacade { get; set; } = null!;
    [Inject]
    public MapFacade MapFacade { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; init; } = null!;
    
    private LineDetailModel? LineDetailModel { get; set; }
    private List<MapListModel> Maps { get; set; } = new();
    
    protected override async Task OnParametersSetAsync()
    {
        if (Guid.TryParse(LineIdString, out Guid parsedLineId))
        {
            _lineIdGuid = parsedLineId;
            LineDetailModel = await LineFacade.GetByIdAsync(_lineIdGuid);
            Maps = await MapFacade.GetAllAsync();
        }
        else
        {
            _notFound = true;
        }
    }

    private async Task Save()
    {
        await LineFacade.UpdateAsync(LineDetailModel);
        NavigationManager.NavigateTo($"/admin/mapy");
    }

    private async Task Delete()
    {
        await LineFacade.DeleteAsync(_lineIdGuid);
        NavigationManager.NavigateTo($"/admin/mapy");
    }
}