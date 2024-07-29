using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 预算实际明细
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:40:38
    /// </summary>
    public interface IFicoBudgetActualContService : IBaseService<FicoBudgetActualCont>
    {
        /// <summary>
        /// 获取预算实际明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetActualContDto> GetList(FicoBudgetActualContQueryDto parm);

        /// <summary>
        /// 获取预算实际明细信息
        /// </summary>
        /// <param name="FbSfid"></param>
        /// <returns></returns>
        FicoBudgetActualCont GetInfo(long FbSfid);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 预算实际明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetActualCont AddFicoBudgetActualCont(FicoBudgetActualCont parm);

        /// <summary>
        /// 更新
        /// 预算实际明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetActualCont(FicoBudgetActualCont parm);


        /// <summary>
        /// 批量导入
        /// 预算实际明细
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetActualCont(List<FicoBudgetActualCont> list);

        /// <summary>
        /// 导出
        /// 预算实际明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetActualContDto> ExportList(FicoBudgetActualContQueryDto parm);
    }
}
