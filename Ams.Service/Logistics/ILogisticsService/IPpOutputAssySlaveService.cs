using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 制一OPH从表
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:07:23
    /// </summary>
    public interface IPpOutputAssySlaveService : IBaseService<PpOutputAssySlave>
    {
        /// <summary>
        /// 获取制一OPH从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputAssySlaveDto> GetList(PpOutputAssySlaveQueryDto parm);

        /// <summary>
        /// 获取制一OPH从表信息
        /// </summary>
        /// <param name="PosSfId"></param>
        /// <returns></returns>
        PpOutputAssySlave GetInfo(long PosSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 制一OPH从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputAssySlave AddPpOutputAssySlave(PpOutputAssySlave parm);

        /// <summary>
        /// 更新
        /// 制一OPH从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputAssySlave(PpOutputAssySlave parm);


        /// <summary>
        /// 批量导入
        /// 制一OPH从表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputAssySlave(List<PpOutputAssySlave> list);

        /// <summary>
        /// 导出
        /// 制一OPH从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputAssySlaveDto> ExportList(PpOutputAssySlaveQueryDto parm);
    }
}
