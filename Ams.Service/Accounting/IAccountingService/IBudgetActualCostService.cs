using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 预算实际明细
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 10:41:09)
    /// </summary>
    public interface IBudgetActualCostService : IBaseService<BudgetActualCost>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<BudgetActualCostDto> GetList(BudgetActualCostQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="FbSFID"></param>
        /// <returns></returns>
        BudgetActualCost GetInfo(long FbSFID);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        BudgetActualCost AddBudgetActualCost(BudgetActualCost parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateBudgetActualCost(BudgetActualCost parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportBudgetActualCost(List<BudgetActualCost> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<BudgetActualCostDto> ExportList(BudgetActualCostQueryDto parm);
    }
}
