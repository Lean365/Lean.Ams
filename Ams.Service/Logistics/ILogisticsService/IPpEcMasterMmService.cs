using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 部管
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 16:02:20
    /// </summary>
    public interface IPpEcMasterMmService : IBaseService<PpEcMasterMm>
    {
        /// <summary>
        /// 获取部管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterMmDto> GetList(PpEcMasterMmQueryDto parm);

        /// <summary>
        /// 获取部管信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMasterMm GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 部管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMasterMm AddPpEcMasterMm(PpEcMasterMm parm);

        /// <summary>
        /// 更新
        /// 部管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMasterMm(PpEcMasterMm parm);


        /// <summary>
        /// 批量导入
        /// 部管
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMasterMm(List<PpEcMasterMm> list);

        /// <summary>
        /// 导出
        /// 部管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterMmDto> ExportList(PpEcMasterMmQueryDto parm);
    }
}
