using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 人员预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:30:08
    /// </summary>
    public interface IFicoBudgetStaffMaService : IBaseService<FicoBudgetStaffMa>
    {
        /// <summary>
        /// 获取人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetStaffMaDto> GetList(FicoBudgetStaffMaQueryDto parm);

        /// <summary>
        /// 获取人员预算信息
        /// </summary>
        /// <param name="FbsSfId"></param>
        /// <returns></returns>
        FicoBudgetStaffMa GetInfo(long FbsSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetStaffMa AddFicoBudgetStaffMa(FicoBudgetStaffMa parm);

        /// <summary>
        /// 更新
        /// 人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetStaffMa(FicoBudgetStaffMa parm);


        /// <summary>
        /// 批量导入
        /// 人员预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetStaffMa(List<FicoBudgetStaffMa> list);

        /// <summary>
        /// 导出
        /// 人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetStaffMaDto> ExportList(FicoBudgetStaffMaQueryDto parm);
    }
}
