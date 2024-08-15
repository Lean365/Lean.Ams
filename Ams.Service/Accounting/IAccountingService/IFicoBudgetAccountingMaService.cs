using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 预算科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/7 8:08:11
    /// </summary>
    public interface IFicoBudgetAccountingMaService : IBaseService<FicoBudgetAccountingMa>
    {
        /// <summary>
        /// 获取预算科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAccountingMaDto> GetList(FicoBudgetAccountingMaQueryDto parm);

        /// <summary>
        /// 获取预算科目信息
        /// </summary>
        /// <param name="FbasSfId"></param>
        /// <returns></returns>
        FicoBudgetAccountingMa GetInfo(long FbasSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetAccountingMa AddFicoBudgetAccountingMa(FicoBudgetAccountingMa parm);

        /// <summary>
        /// 更新
        /// 预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetAccountingMa(FicoBudgetAccountingMa parm);


        /// <summary>
        /// 批量导入
        /// 预算科目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetAccountingMa(List<FicoBudgetAccountingMa> list);

        /// <summary>
        /// 导出
        /// 预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAccountingMaDto> ExportList(FicoBudgetAccountingMaQueryDto parm);
    }
}
