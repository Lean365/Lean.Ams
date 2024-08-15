using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 受检
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:15
    /// </summary>
    public interface IPpEcMasterIqcService : IBaseService<PpEcMasterIqc>
    {
        /// <summary>
        /// 获取受检列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterIqcDto> GetList(PpEcMasterIqcQueryDto parm);

        /// <summary>
        /// 获取受检信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMasterIqc GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 受检
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMasterIqc AddPpEcMasterIqc(PpEcMasterIqc parm);

        /// <summary>
        /// 更新
        /// 受检
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMasterIqc(PpEcMasterIqc parm);


        /// <summary>
        /// 批量导入
        /// 受检
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMasterIqc(List<PpEcMasterIqc> list);

        /// <summary>
        /// 导出
        /// 受检
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterIqcDto> ExportList(PpEcMasterIqcQueryDto parm);
    }
}
