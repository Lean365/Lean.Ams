using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 从设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:30:08
    /// </summary>
    public interface IPpEcSlaveService : IBaseService<PpEcSlave>
    {
        /// <summary>
        /// 获取从设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveDto> GetList(PpEcSlaveQueryDto parm);

        /// <summary>
        /// 获取从设变信息
        /// </summary>
        /// <param name="EcsSfId"></param>
        /// <returns></returns>
        PpEcSlave GetInfo(long EcsSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 从设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlave AddPpEcSlave(PpEcSlave parm);

        /// <summary>
        /// 更新
        /// 从设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlave(PpEcSlave parm);


        /// <summary>
        /// 批量导入
        /// 从设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlave(List<PpEcSlave> list);

        /// <summary>
        /// 导出
        /// 从设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveDto> ExportList(PpEcSlaveQueryDto parm);
    }
}
