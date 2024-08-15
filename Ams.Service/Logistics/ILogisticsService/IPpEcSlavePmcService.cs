using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// Pmc设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:45:42
    /// </summary>
    public interface IPpEcSlavePmcService : IBaseService<PpEcSlavePmc>
    {
        /// <summary>
        /// 获取Pmc设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlavePmcDto> GetList(PpEcSlavePmcQueryDto parm);

        /// <summary>
        /// 获取Pmc设变信息
        /// </summary>
        /// <param name="PmcSfId"></param>
        /// <returns></returns>
        PpEcSlavePmc GetInfo(long PmcSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// Pmc设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlavePmc AddPpEcSlavePmc(PpEcSlavePmc parm);

        /// <summary>
        /// 更新
        /// Pmc设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlavePmc(PpEcSlavePmc parm);


        /// <summary>
        /// 批量导入
        /// Pmc设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlavePmc(List<PpEcSlavePmc> list);

        /// <summary>
        /// 导出
        /// Pmc设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlavePmcDto> ExportList(PpEcSlavePmcQueryDto parm);
    }
}
