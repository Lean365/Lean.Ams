using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 人员预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:59
    /// </summary>
    public interface IFicoBudgetStaffSlvService : IBaseService<FicoBudgetStaffSlv>
    {
        /// <summary>
        /// 获取人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetStaffSlvDto> GetList(FicoBudgetStaffSlvQueryDto parm);

        /// <summary>
        /// 获取人员预算信息
        /// </summary>
        /// <param name="FbssSfId"></param>
        /// <returns></returns>
        FicoBudgetStaffSlv GetInfo(long FbssSfId);
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
        FicoBudgetStaffSlv AddFicoBudgetStaffSlv(FicoBudgetStaffSlv parm);

        /// <summary>
        /// 更新
        /// 人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetStaffSlv(FicoBudgetStaffSlv parm);


        /// <summary>
        /// 批量导入
        /// 人员预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetStaffSlv(List<FicoBudgetStaffSlv> list);

        /// <summary>
        /// 导出
        /// 人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetStaffSlvDto> ExportList(FicoBudgetStaffSlvQueryDto parm);
    }
}
