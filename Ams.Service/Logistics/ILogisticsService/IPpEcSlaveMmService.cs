using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// Mm设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:14
    /// </summary>
    public interface IPpEcSlaveMmService : IBaseService<PpEcSlaveMm>
    {
        /// <summary>
        /// 获取Mm设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveMmDto> GetList(PpEcSlaveMmQueryDto parm);

        /// <summary>
        /// 获取Mm设变信息
        /// </summary>
        /// <param name="MmSfId"></param>
        /// <returns></returns>
        PpEcSlaveMm GetInfo(long MmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// Mm设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlaveMm AddPpEcSlaveMm(PpEcSlaveMm parm);

        /// <summary>
        /// 更新
        /// Mm设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlaveMm(PpEcSlaveMm parm);


        /// <summary>
        /// 批量导入
        /// Mm设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlaveMm(List<PpEcSlaveMm> list);

        /// <summary>
        /// 导出
        /// Mm设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveMmDto> ExportList(PpEcSlaveMmQueryDto parm);
    }
}
