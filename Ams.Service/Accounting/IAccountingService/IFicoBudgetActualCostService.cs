using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 预算实际明细
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:42:06
    /// </summary>
    public interface IFicoBudgetActualCostService : IBaseService<FicoBudgetActualCost>
    {
        /// <summary>
        /// 获取预算实际明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetActualCostDto> GetList(FicoBudgetActualCostQueryDto parm);

        /// <summary>
        /// 获取预算实际明细信息
        /// </summary>
        /// <param name="FbSFID"></param>
        /// <returns></returns>
        FicoBudgetActualCost GetInfo(long FbSFID);


        /// <summary>
        /// 批量导入
        /// 预算实际明细
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetActualCost(List<FicoBudgetActualCost> list);

        /// <summary>
        /// 导出
        /// 预算实际明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetActualCostDto> ExportList(FicoBudgetActualCostQueryDto parm);
    }
}
