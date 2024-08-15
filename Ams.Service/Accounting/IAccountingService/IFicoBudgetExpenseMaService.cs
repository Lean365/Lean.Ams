using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 费用预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:31:03
    /// </summary>
    public interface IFicoBudgetExpenseMaService : IBaseService<FicoBudgetExpenseMa>
    {
        /// <summary>
        /// 获取费用预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetExpenseMaDto> GetList(FicoBudgetExpenseMaQueryDto parm);

        /// <summary>
        /// 获取费用预算信息
        /// </summary>
        /// <param name="FbeSfId"></param>
        /// <returns></returns>
        FicoBudgetExpenseMa GetInfo(long FbeSfId);
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
        FicoBudgetExpenseMa AddFicoBudgetExpenseMa(FicoBudgetExpenseMa parm);

        /// <summary>
        /// 更新
        /// 费用预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetExpenseMa(FicoBudgetExpenseMa parm);


        /// <summary>
        /// 批量导入
        /// 费用预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetExpenseMa(List<FicoBudgetExpenseMa> list);

        /// <summary>
        /// 导出
        /// 费用预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetExpenseMaDto> ExportList(FicoBudgetExpenseMaQueryDto parm);
    }
}
