using Simt.Common.Models;

namespace Simt.Web.BL.Facades
{
    public class LineFacade(ILineApiClient apiClient) : FacadeBase<LineDetailModel, LineListModel>
    {
        public override async Task<List<LineListModel>> GetAllAsync()
        {
            var lines = await apiClient.Line_GetAllAsync();
            return (List<LineListModel>)lines;
        }
        
        public override async Task<LineDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.Line_GetByIdAsync(id);
        }
        
        public override async Task<LineDetailModel> CreateAsync(LineDetailModel data)
        {
            return await apiClient.Line_CreateAsync(data);
        }
    
        public override async Task<LineDetailModel>UpdateAsync(LineDetailModel data)
        {
            return await apiClient.Line_UpdateAsync(data);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await apiClient.Line_DeleteAsync(id);
        }
        
        public async Task<List<LineListModel>> Line_GetAllByMapAsync(Guid mapId)
        {
            var lines = await apiClient.Line_GetAllByMapAsync(mapId);
            return (List<LineListModel>)lines;
        }
    }
}