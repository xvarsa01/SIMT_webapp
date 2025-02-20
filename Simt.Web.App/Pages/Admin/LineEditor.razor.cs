using System.Diagnostics;
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
    private bool _showDeleteModal;
    
    [Inject]
    public LineFacade LineFacade { get; set; } = null!;
    [Inject]
    public RouteFacade RouteFacade { get; set; } = null!;
    [Inject]
    public MapFacade MapFacade { get; set; } = null!;
    [Inject]
    public PlatformFacade PlatformFacade { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; init; } = null!;
    
    private LineDetailModel? LineDetailModel { get; set; }
    private List<RouteDetailModel> RouteDetailsList { get; set; } = new();
    private List<MapListModel> Maps { get; set; } = new();
    private List<PlatformListModel> Platforms { get; set; } = new();
    
    protected override async Task OnParametersSetAsync()
    {
        if (Guid.TryParse(LineIdString, out Guid parsedLineId))
        {
            _lineIdGuid = parsedLineId;
            LineDetailModel = await LineFacade.GetByIdAsync(_lineIdGuid);
            foreach (var route in LineDetailModel.Routes)
            {
                var routeDetail = await RouteFacade.GetByIdAsync(route.Id);
                RouteDetailsList.Add(routeDetail);
            }
            RouteDetailsList = RouteDetailsList.OrderBy(p => p.RouteCode).ToList();

            Maps = await MapFacade.GetAllAsync();
            Platforms = (await PlatformFacade.GetAllAsync())
                .OrderBy(p => p.PlatformName).ToList();
        }
        else
        {
            _notFound = true;
        }
    }

    private async Task Save()
    {
        Debug.Assert(LineDetailModel != null, nameof(LineDetailModel) + " != null");
        await LineFacade.UpdateAsync(LineDetailModel);
        foreach (var route in RouteDetailsList)
        {
            await RouteFacade.UpdateAsync(route with {Stops = default!});
        }
        NavigationManager.NavigateTo($"/admin/mapy");
    }

    private void DeleteClicked()
    {
        _showDeleteModal = true;
    }
    private async Task DeleteLine()
    {
        _showDeleteModal = false;
        await LineFacade.DeleteAsync(_lineIdGuid);
        NavigationManager.NavigateTo($"/admin/mapy");
    }

    private async Task DeleteRoute(Guid routeId)
    {
        await RouteFacade.DeleteAsync(routeId);
        
        var routeToRemoveDetail = RouteDetailsList.FirstOrDefault(r => r.Id == routeId);
        if (routeToRemoveDetail != null)
        {
            RouteDetailsList.Remove(routeToRemoveDetail);
        }
        var routeToRemoveList = LineDetailModel?.Routes.FirstOrDefault(r => r.Id == routeId);
        if (routeToRemoveList != null)
        {
            LineDetailModel?.Routes.Remove(routeToRemoveList);
        }
        StateHasChanged();
    }

    private void CancelDelete()
    {
        _showDeleteModal = false;
    }

    private async Task CreateNewRoute()
    {
        string routeCode = GetNextRouteCode();
        Guid startPlatformId = Platforms.First().Id;
        Guid finalPlatformId = Platforms.First().Id;
        
        Debug.Assert(LineDetailModel != null, nameof(LineDetailModel) + " != null");    
        RouteCreationModel routeCreationModel = RouteCreationModel.EmptyCreation with
            {RouteCode = routeCode, LineId = LineDetailModel.Id, StartPlatformId = startPlatformId, FinalPlatformId = finalPlatformId};
        Console.WriteLine(routeCreationModel);
        await RouteFacade.CreateAsync(routeCreationModel);
        
        RouteDetailModel routeDetailModel = RouteDetailModel.Empty with
            {RouteCode = routeCode, LineId = LineDetailModel.Id, Id = routeCreationModel.Id, StartPlatformId = startPlatformId, FinalPlatformId = finalPlatformId};
        RouteDetailsList.Add(routeDetailModel);
        
        RouteListModel routeListModel = RouteListModel.Empty with
            {RouteCode = routeCode, LineId = LineDetailModel.Id, Id = routeCreationModel.Id, StartPlatformId = startPlatformId, FinalPlatformId = finalPlatformId};
        LineDetailModel.Routes.Add(routeListModel);
        
        StateHasChanged();
    }
    
    private string GetNextRouteCode()
    {
        List<RouteDetailModel> routes = RouteDetailsList;
        if (routes.Count == 0)
            return "A"; // Default starting point

        string lastCode = routes.Max(r => r.RouteCode)!.ToUpper();
        return IncrementString(lastCode);
    }

    private static string IncrementString(string input)
    {
        char[] chars = input.ToCharArray();
        int i = chars.Length - 1;

        while (i >= 0)
        {
            if (chars[i] < 'Z')
            {
                chars[i]++;
                return new string(chars);
            }
            chars[i] = 'A'; // Reset to 'A' and move left
            i--;
        }
        // If all characters were 'Z', prepend 'A'
        return 'A' + new string(chars);
    }
}