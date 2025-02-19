using Simt.Common.Models;

namespace Simt.Web.BL.Facades
{
    public class StopFacade(IStopApiClient apiClient) : FacadeBase<StopDetailModel, StopListModel, StopCreationModel>
    {
        public override async Task<List<StopListModel>> GetAllAsync()
        {
            var stops = await apiClient.Stop_GetAllAsync();
            return (List<StopListModel>)stops;
        }
        public async Task<List<LineListModel>> GetAllLinesForStopByIdAsync(Guid id)
        {
            var stops = await apiClient.Stop_GetAllLinesForStopByIdAsync(id);
            return (List<LineListModel>)stops;
        }
        
        public override async Task<StopDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.Stop_GetByIdAsync(id);
        }
        
        public override async Task<StopDetailModel> CreateAsync(StopCreationModel data)
        {
            return await apiClient.Stop_CreateAsync(data);
        }
    
        public override async Task<StopDetailModel>UpdateAsync(StopCreationModel data)
        {
            return await apiClient.Stop_UpdateAsync(data);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await apiClient.Stop_DeleteAsync(id);
        }
    }
}