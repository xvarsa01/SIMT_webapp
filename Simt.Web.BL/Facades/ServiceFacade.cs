using Simt.Common.Models;

namespace Simt.Web.BL.Facades
{
    public class ServiceFacade(IServiceApiClient apiClient) : FacadeBase<ServiceDetailModel, ServiceListModel, ServiceDetailModel>
    {
        public override async Task<List<ServiceListModel>> GetAllAsync()
        {
            var services = await apiClient.Service_GetAllAsync();
            return (List<ServiceListModel>)services;
        }
        
        public async Task<List<ServiceDetailModel>> GetAllActiveAsync()
        {
            var services = await apiClient.Service_GetAllActiveAsync();
            return (List<ServiceDetailModel>)services;
        }
        
        public async Task<List<ServiceDetailModel>> GetAllForPlayerAsync(Guid id,int pageNumber, int pageSize)
        {
            var services = await apiClient.Service_GetAllForPlayerAsync(id,pageNumber,pageSize);
            return (List<ServiceDetailModel>)services;
        }

        public override async Task<ServiceDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.Service_GetByIdAsync(id);
        }
    
        public override async Task<ServiceDetailModel> CreateAsync(ServiceDetailModel data)
        {
            return await apiClient.Service_CreateAsync(data);
        }
    
        public override async Task<ServiceDetailModel>UpdateAsync(ServiceDetailModel data)
        {
            return await apiClient.Service_UpdateAsync(data);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await apiClient.Service_DeleteAsync(id);
        }
    }
}