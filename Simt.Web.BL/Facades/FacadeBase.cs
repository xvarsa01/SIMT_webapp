using System.Globalization;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Web.BL.Facades
{
    public abstract class FacadeBase<TDetailModel, TListModel>
        where TDetailModel : ModelBase
    {
        public abstract Task<List<TListModel>> GetAllAsync();
        public abstract Task<TDetailModel> GetByIdAsync(Guid id);
        public abstract Task CreateAsync(TDetailModel model);
        public abstract Task UpdateAsync(TDetailModel model);
        public abstract Task DeleteAsync(Guid id);
    }
}