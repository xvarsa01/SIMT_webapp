using Simt.Common.Models;

namespace Simt.Web.BL.Facades
{
    public class PlayerFacade(IPlayerApiClient apiClient) : FacadeBase<PlayerDetailModel, PlayerListModel>
    {
        public override async Task<List<PlayerListModel>> GetAllAsync()
        {
            var players = await apiClient.Player_GetAllAsync();
            return (List<PlayerListModel>)players;
        }
        
        public async Task<List<PlayerListModel>> GetAllSearchedAsync(string searchTerm)
        {
            var players = await apiClient.Player_GetAllSearchedAsync(searchTerm);
            return (List<PlayerListModel>)players;
        }

        public override async Task<PlayerDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.Player_GetByIdAsync(id);
        }
        
        public async Task<PlayerDetailModel> GetByNickAsync(string nick)
        {
            return await apiClient.Player_GetByNickAsync(nick);
        }
    
        public override async Task<PlayerDetailModel> CreateAsync(PlayerDetailModel data)
        {
            return await apiClient.Player_CreateAsync(data);
        }
    
        public override async Task<PlayerDetailModel>UpdateAsync(PlayerDetailModel data)
        {
            return await apiClient.Player_UpdateAsync(data);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await apiClient.Player_DeleteAsync(id);
        }
    }
}