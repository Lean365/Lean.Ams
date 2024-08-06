using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// Iqc设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:59
    /// </summary>
    public interface IPpEcSlaveIqcService : IBaseService<PpEcSlaveIqc>
    {
        /// <summary>
        /// 获取Iqc设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveIqcDto> GetList(PpEcSlaveIqcQueryDto parm);

        /// <summary>
        /// 获取Iqc设变信息
        /// </summary>
        /// <param name="IqcSfId"></param>
        /// <returns></returns>
        PpEcSlaveIqc GetInfo(long IqcSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// Iqc设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlaveIqc AddPpEcSlaveIqc(PpEcSlaveIqc parm);

        /// <summary>
        /// 更新
        /// Iqc设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlaveIqc(PpEcSlaveIqc parm);


        /// <summary>
        /// 批量导入
        /// Iqc设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlaveIqc(List<PpEcSlaveIqc> list);

        /// <summary>
        /// 导出
        /// Iqc设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveIqcDto> ExportList(PpEcSlaveIqcQueryDto parm);
    }
}
