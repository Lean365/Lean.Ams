using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 技术
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 16:05:58
    /// </summary>
    public interface IPpEcMasterTeService : IBaseService<PpEcMasterTe>
    {
        /// <summary>
        /// 获取技术列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterTeDto> GetList(PpEcMasterTeQueryDto parm);

        /// <summary>
        /// 获取技术信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMasterTe GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 技术
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMasterTe AddPpEcMasterTe(PpEcMasterTe parm);

        /// <summary>
        /// 更新
        /// 技术
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMasterTe(PpEcMasterTe parm);


        /// <summary>
        /// 批量导入
        /// 技术
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMasterTe(List<PpEcMasterTe> list);

        /// <summary>
        /// 导出
        /// 技术
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterTeDto> ExportList(PpEcMasterTeQueryDto parm);
    }
}
