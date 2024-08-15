using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 费用预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:29
    /// </summary>
    public interface IFicoBudgetExpenseSlvService : IBaseService<FicoBudgetExpenseSlv>
    {
        /// <summary>
        /// 获取费用预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetExpenseSlvDto> GetList(FicoBudgetExpenseSlvQueryDto parm);

        /// <summary>
        /// 获取费用预算信息
        /// </summary>
        /// <param name="FbesSfId"></param>
        /// <returns></returns>
        FicoBudgetExpenseSlv GetInfo(long FbesSfId);
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
        FicoBudgetExpenseSlv AddFicoBudgetExpenseSlv(FicoBudgetExpenseSlv parm);

        /// <summary>
        /// 更新
        /// 费用预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetExpenseSlv(FicoBudgetExpenseSlv parm);


        /// <summary>
        /// 批量导入
        /// 费用预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetExpenseSlv(List<FicoBudgetExpenseSlv> list);

        /// <summary>
        /// 导出
        /// 费用预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetExpenseSlvDto> ExportList(FicoBudgetExpenseSlvQueryDto parm);
    }
}
