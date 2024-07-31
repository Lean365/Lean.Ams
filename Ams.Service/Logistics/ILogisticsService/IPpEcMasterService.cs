using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 主设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:35:09
    /// </summary>
    public interface IPpEcMasterService : IBaseService<PpEcMaster>
    {
        /// <summary>
        /// 获取主设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterDto> GetList(PpEcMasterQueryDto parm);

        /// <summary>
        /// 获取主设变信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMaster GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 主设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMaster AddPpEcMaster(PpEcMaster parm);

        /// <summary>
        /// 更新
        /// 主设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMaster(PpEcMaster parm);


        /// <summary>
        /// 批量导入
        /// 主设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMaster(List<PpEcMaster> list);

        /// <summary>
        /// 导出
        /// 主设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterDto> ExportList(PpEcMasterQueryDto parm);
    }
}
