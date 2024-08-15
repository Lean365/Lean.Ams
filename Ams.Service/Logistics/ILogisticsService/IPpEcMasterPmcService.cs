using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 生管
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:28
    /// </summary>
    public interface IPpEcMasterPmcService : IBaseService<PpEcMasterPmc>
    {
        /// <summary>
        /// 获取生管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterPmcDto> GetList(PpEcMasterPmcQueryDto parm);

        /// <summary>
        /// 获取生管信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMasterPmc GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 生管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMasterPmc AddPpEcMasterPmc(PpEcMasterPmc parm);

        /// <summary>
        /// 更新
        /// 生管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMasterPmc(PpEcMasterPmc parm);


        /// <summary>
        /// 批量导入
        /// 生管
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMasterPmc(List<PpEcMasterPmc> list);

        /// <summary>
        /// 导出
        /// 生管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterPmcDto> ExportList(PpEcMasterPmcQueryDto parm);
    }
}
