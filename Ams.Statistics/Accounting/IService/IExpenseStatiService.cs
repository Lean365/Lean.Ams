using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;

namespace Ams.Statistics.Accounting.IService
{
    /// <summary>
    /// 成本
    /// 业务层接口
    /// </summary>
    public interface IExpenseStatiService : IBaseService<FicoBudgetActualCont>
    {
        /// <summary>
        /// 生产成本
        /// </summary>
        /// <returns></returns>
        decimal GetMonthlyProductionCost(FicoBudgetActualContQueryDto parm);
    }
}