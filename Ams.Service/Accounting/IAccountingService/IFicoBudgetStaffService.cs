using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 人员预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/16 13:50:58
    /// </summary>
    public interface IFicoBudgetStaffService : IBaseService<FicoBudgetStaff>
    {
        /// <summary>
        /// 获取人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetStaffDto> GetList(FicoBudgetStaffQueryDto parm);

        /// <summary>
        /// 获取人员预算信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoBudgetStaff GetInfo(long Id);
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
        FicoBudgetStaff AddFicoBudgetStaff(FicoBudgetStaff parm);

        /// <summary>
        /// 更新
        /// 人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetStaff(FicoBudgetStaff parm);


        /// <summary>
        /// 批量导入
        /// 人员预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetStaff(List<FicoBudgetStaff> list);

        /// <summary>
        /// 导出
        /// 人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetStaffDto> ExportList(FicoBudgetStaffQueryDto parm);
    }
}
