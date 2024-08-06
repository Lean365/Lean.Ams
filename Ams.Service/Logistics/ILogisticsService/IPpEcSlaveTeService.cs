using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// Te设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:03
    /// </summary>
    public interface IPpEcSlaveTeService : IBaseService<PpEcSlaveTe>
    {
        /// <summary>
        /// 获取Te设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveTeDto> GetList(PpEcSlaveTeQueryDto parm);

        /// <summary>
        /// 获取Te设变信息
        /// </summary>
        /// <param name="TeSfId"></param>
        /// <returns></returns>
        PpEcSlaveTe GetInfo(long TeSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// Te设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlaveTe AddPpEcSlaveTe(PpEcSlaveTe parm);

        /// <summary>
        /// 更新
        /// Te设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlaveTe(PpEcSlaveTe parm);


        /// <summary>
        /// 批量导入
        /// Te设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlaveTe(List<PpEcSlaveTe> list);

        /// <summary>
        /// 导出
        /// Te设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveTeDto> ExportList(PpEcSlaveTeQueryDto parm);
    }
}
