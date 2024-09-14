using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 实际对比
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 14:38:54
    /// </summary>
    public interface IFicoBudgetActualContService : IBaseService<FicoBudgetActualCont>
    {
        /// <summary>
        /// 获取实际对比列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetActualContDto> GetList(FicoBudgetActualContQueryDto parm);

        /// <summary>
        /// 获取实际对比信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoBudgetActualCont GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 实际对比
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetActualCont AddFicoBudgetActualCont(FicoBudgetActualCont parm);

        /// <summary>
        /// 更新
        /// 实际对比
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetActualCont(FicoBudgetActualCont parm);


        /// <summary>
        /// 批量导入
        /// 实际对比
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetActualCont(List<FicoBudgetActualCont> list);

        /// <summary>
        /// 导出
        /// 实际对比
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetActualContDto> ExportList(FicoBudgetActualContQueryDto parm);
    }
}
