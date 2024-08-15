using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 制二
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:18
    /// </summary>
    public interface IPpEcMasterPcbaService : IBaseService<PpEcMasterPcba>
    {
        /// <summary>
        /// 获取制二列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterPcbaDto> GetList(PpEcMasterPcbaQueryDto parm);

        /// <summary>
        /// 获取制二信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMasterPcba GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 制二
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMasterPcba AddPpEcMasterPcba(PpEcMasterPcba parm);

        /// <summary>
        /// 更新
        /// 制二
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMasterPcba(PpEcMasterPcba parm);


        /// <summary>
        /// 批量导入
        /// 制二
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMasterPcba(List<PpEcMasterPcba> list);

        /// <summary>
        /// 导出
        /// 制二
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterPcbaDto> ExportList(PpEcMasterPcbaQueryDto parm);
    }
}
