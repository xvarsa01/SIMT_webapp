using System.Globalization;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Web.BL.Facades
{
    public abstract class FacadeBase<TDetailModel, TListModel, TCreationModel>
        where TDetailModel : ModelBase
    {
        public abstract Task<List<TListModel>> GetAllAsync();
        public abstract Task<TDetailModel> GetByIdAsync(Guid id);
        public abstract Task CreateAsync(TCreationModel model);
        public abstract Task UpdateAsync(TCreationModel model);
        public abstract Task DeleteAsync(Guid id);
    }
}