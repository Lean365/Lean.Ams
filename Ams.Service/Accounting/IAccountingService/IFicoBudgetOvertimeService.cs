using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 加班预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/16 13:38:01
    /// </summary>
    public interface IFicoBudgetOvertimeService : IBaseService<FicoBudgetOvertime>
    {
        /// <summary>
        /// 获取加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetOvertimeDto> GetList(FicoBudgetOvertimeQueryDto parm);

        /// <summary>
        /// 获取加班预算信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoBudgetOvertime GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetOvertime AddFicoBudgetOvertime(FicoBudgetOvertime parm);

        /// <summary>
        /// 更新
        /// 加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetOvertime(FicoBudgetOvertime parm);


        /// <summary>
        /// 批量导入
        /// 加班预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetOvertime(List<FicoBudgetOvertime> list);

        /// <summary>
        /// 导出
        /// 加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetOvertimeDto> ExportList(FicoBudgetOvertimeQueryDto parm);
    }
}
