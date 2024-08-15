using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 采购
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:25
    /// </summary>
    public interface IPpEcMasterPurService : IBaseService<PpEcMasterPur>
    {
        /// <summary>
        /// 获取采购列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterPurDto> GetList(PpEcMasterPurQueryDto parm);

        /// <summary>
        /// 获取采购信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMasterPur GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 采购
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMasterPur AddPpEcMasterPur(PpEcMasterPur parm);

        /// <summary>
        /// 更新
        /// 采购
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMasterPur(PpEcMasterPur parm);


        /// <summary>
        /// 批量导入
        /// 采购
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMasterPur(List<PpEcMasterPur> list);

        /// <summary>
        /// 导出
        /// 采购
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterPurDto> ExportList(PpEcMasterPurQueryDto parm);
    }
}
