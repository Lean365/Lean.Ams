using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 加班预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:06:46
    /// </summary>
    public interface IFicoBudgetOvertimeSlvService : IBaseService<FicoBudgetOvertimeSlv>
    {
        /// <summary>
        /// 获取加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetOvertimeSlvDto> GetList(FicoBudgetOvertimeSlvQueryDto parm);

        /// <summary>
        /// 获取加班预算信息
        /// </summary>
        /// <param name="FbosSfId"></param>
        /// <returns></returns>
        FicoBudgetOvertimeSlv GetInfo(long FbosSfId);
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
        FicoBudgetOvertimeSlv AddFicoBudgetOvertimeSlv(FicoBudgetOvertimeSlv parm);

        /// <summary>
        /// 更新
        /// 加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetOvertimeSlv(FicoBudgetOvertimeSlv parm);


        /// <summary>
        /// 批量导入
        /// 加班预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetOvertimeSlv(List<FicoBudgetOvertimeSlv> list);

        /// <summary>
        /// 导出
        /// 加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetOvertimeSlvDto> ExportList(FicoBudgetOvertimeSlvQueryDto parm);
    }
}
