using Simt.Common.Models;

namespace Simt.Web.BL.Facades
{
    public class RouteFacade(IRouteApiClient apiClient) : FacadeBase<RouteDetailModel, RouteListModel, RouteCreationModel>
    {
        public override async Task<List<RouteListModel>> GetAllAsync()
        {
            var routes = await apiClient.Route_GetAllAsync();
            return (List<RouteListModel>)routes;
        }

        public override async Task<RouteDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.Route_GetByIdAsync(id);
        }
    
        public override async Task<RouteDetailModel> CreateAsync(RouteCreationModel data)
        {
            return await apiClient.Route_CreateAsync(data);
        }
    
        public override async Task<RouteDetailModel>UpdateAsync(RouteCreationModel data)
        {
            return await apiClient.Route_UpdateAsync(data);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await apiClient.Route_DeleteAsync(id);
        }
    }
}