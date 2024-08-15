using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 制技
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:21
    /// </summary>
    public interface IPpEcMasterPeService : IBaseService<PpEcMasterPe>
    {
        /// <summary>
        /// 获取制技列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterPeDto> GetList(PpEcMasterPeQueryDto parm);

        /// <summary>
        /// 获取制技信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMasterPe GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 制技
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMasterPe AddPpEcMasterPe(PpEcMasterPe parm);

        /// <summary>
        /// 更新
        /// 制技
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMasterPe(PpEcMasterPe parm);


        /// <summary>
        /// 批量导入
        /// 制技
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMasterPe(List<PpEcMasterPe> list);

        /// <summary>
        /// 导出
        /// 制技
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterPeDto> ExportList(PpEcMasterPeQueryDto parm);
    }
}
