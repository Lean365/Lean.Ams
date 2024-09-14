using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 费用预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:57:41
    /// </summary>
    public interface IFicoBudgetExpenseService : IBaseService<FicoBudgetExpense>
    {
        /// <summary>
        /// 获取费用预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetExpenseDto> GetList(FicoBudgetExpenseQueryDto parm);

        /// <summary>
        /// 获取费用预算信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoBudgetExpense GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 费用预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetExpense AddFicoBudgetExpense(FicoBudgetExpense parm);

        /// <summary>
        /// 更新
        /// 费用预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetExpense(FicoBudgetExpense parm);


        /// <summary>
        /// 批量导入
        /// 费用预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetExpense(List<FicoBudgetExpense> list);

        /// <summary>
        /// 导出
        /// 费用预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetExpenseDto> ExportList(FicoBudgetExpenseQueryDto parm);
    }
}
