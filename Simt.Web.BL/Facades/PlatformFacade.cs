using Simt.Common.Models;

namespace Simt.Web.BL.Facades
{
    public class PlatformFacade(IPlatformApiClient apiClient) : FacadeBase<PlatformDetailModel, PlatformListModel, PlatformCreationModel>
    {
        public override async Task<List<PlatformListModel>> GetAllAsync()
        {
            var platforms = await apiClient.Platform_GetAllAsync();
            return (List<PlatformListModel>)platforms;
        }

        public override async Task<PlatformDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.Platform_GetByIdAsync(id);
        }
    
        public override async Task<PlatformDetailModel> CreateAsync(PlatformCreationModel data)
        {
            return await apiClient.Platform_CreateAsync(data);
        }
    
        public override async Task<PlatformDetailModel>UpdateAsync(PlatformCreationModel data)
        {
            return await apiClient.Platform_UpdateAsync(data);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await apiClient.Platform_DeleteAsync(id);
        }
    }
}