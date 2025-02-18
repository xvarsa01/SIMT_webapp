using Simt.Common.Models;

namespace Simt.Web.BL.Facades
{
    public class MapFacade(IMapApiClient apiClient) : FacadeBase<MapDetailModel, MapListModel, MapDetailModel>
    {
        public override async Task<List<MapListModel>> GetAllAsync()
        {
            var maps = await apiClient.Map_GetAllAsync();
            return (List<MapListModel>)maps;
        }
        
        public override async Task<MapDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.Map_GetByIdAsync(id);
        }
        
        public override async Task<MapDetailModel> CreateAsync(MapDetailModel data)
        {
            return await apiClient.Map_CreateAsync(data);
        }
    
        public override async Task<MapDetailModel>UpdateAsync(MapDetailModel data)
        {
            return await apiClient.Map_UpdateAsync(data);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await apiClient.Map_DeleteAsync(id);
        }
    }
}