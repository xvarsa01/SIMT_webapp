using Simt.Common.Models;

namespace Simt.Web.BL.Facades
{
    public class VehicleFacade(IVehicleApiClient apiClient) : FacadeBase<VehicleDetailModel, VehicleListModel, VehicleDetailModel>
    {
        public override async Task<List<VehicleListModel>> GetAllAsync()
        {
            var vehicles = await apiClient.Vehicle_GetAllAsync();
            return (List<VehicleListModel>)vehicles;
        }
        
        public override async Task<VehicleDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.Vehicle_GetByIdAsync(id);
        }
        
        public override async Task<VehicleDetailModel> CreateAsync(VehicleDetailModel data)
        {
            return await apiClient.Vehicle_CreateAsync(data);
        }
    
        public override async Task<VehicleDetailModel>UpdateAsync(VehicleDetailModel data)
        {
            return await apiClient.Vehicle_UpdateAsync(data);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await apiClient.Vehicle_DeleteAsync(id);
        }

        public async Task<List<VehicleListModel>> GetAllBusesAsync()
        {
            var vehicles = await apiClient.Vehicle_GetAllBusesAsync();
            return (List<VehicleListModel>)vehicles;
        }
        public async Task<List<VehicleListModel>> GetAllTrolleybusesAsync()
        {
            var vehicles = await apiClient.Vehicle_GetAllTrolleybusesAsync();
            return (List<VehicleListModel>)vehicles;
        }
        public async Task<List<VehicleListModel>> GetAllTramsAsync()
        {
            var vehicles = await apiClient.Vehicle_GetAllTramsAsync();
            return (List<VehicleListModel>)vehicles;
        }
    }
}