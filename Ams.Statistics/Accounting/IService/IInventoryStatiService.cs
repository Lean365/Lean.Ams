using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;

namespace Ams.Statistics.Accounting.IService
{
    /// <summary>
    /// 物料
    /// 业务层接口
    /// </summary>
    public interface IInventoryStatiService : IBaseService<FicoMonthlyInventory>
    {
        /// <summary>
        /// 月度存货金额
        /// </summary>
        /// <returns></returns>
        decimal GetMonthlyInventoryAmount(FicoMonthlyInventoryQueryDto parm);
    }
}