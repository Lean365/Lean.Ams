using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 品管
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:12
    /// </summary>
    public interface IPpEcMasterFqcService : IBaseService<PpEcMasterFqc>
    {
        /// <summary>
        /// 获取品管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterFqcDto> GetList(PpEcMasterFqcQueryDto parm);

        /// <summary>
        /// 获取品管信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMasterFqc GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 品管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMasterFqc AddPpEcMasterFqc(PpEcMasterFqc parm);

        /// <summary>
        /// 更新
        /// 品管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMasterFqc(PpEcMasterFqc parm);


        /// <summary>
        /// 批量导入
        /// 品管
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMasterFqc(List<PpEcMasterFqc> list);

        /// <summary>
        /// 导出
        /// 品管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterFqcDto> ExportList(PpEcMasterFqcQueryDto parm);
    }
}
