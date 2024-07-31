using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 制二OPH从表
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:07:20
    /// </summary>
    public interface IPpOutputPcbaSlaveService : IBaseService<PpOutputPcbaSlave>
    {
        /// <summary>
        /// 获取制二OPH从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputPcbaSlaveDto> GetList(PpOutputPcbaSlaveQueryDto parm);

        /// <summary>
        /// 获取制二OPH从表信息
        /// </summary>
        /// <param name="PosSfId"></param>
        /// <returns></returns>
        PpOutputPcbaSlave GetInfo(long PosSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 制二OPH从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputPcbaSlave AddPpOutputPcbaSlave(PpOutputPcbaSlave parm);

        /// <summary>
        /// 更新
        /// 制二OPH从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputPcbaSlave(PpOutputPcbaSlave parm);


        /// <summary>
        /// 批量导入
        /// 制二OPH从表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputPcbaSlave(List<PpOutputPcbaSlave> list);

        /// <summary>
        /// 导出
        /// 制二OPH从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputPcbaSlaveDto> ExportList(PpOutputPcbaSlaveQueryDto parm);
    }
}
