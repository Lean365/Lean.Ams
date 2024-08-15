using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 组立
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:43:00
    /// </summary>
    public interface IPpEcSlaveAssyService : IBaseService<PpEcSlaveAssy>
    {
        /// <summary>
        /// 获取组立列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveAssyDto> GetList(PpEcSlaveAssyQueryDto parm);

        /// <summary>
        /// 获取组立信息
        /// </summary>
        /// <param name="AssySfId"></param>
        /// <returns></returns>
        PpEcSlaveAssy GetInfo(long AssySfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 组立
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlaveAssy AddPpEcSlaveAssy(PpEcSlaveAssy parm);

        /// <summary>
        /// 更新
        /// 组立
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlaveAssy(PpEcSlaveAssy parm);


        /// <summary>
        /// 批量导入
        /// 组立
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlaveAssy(List<PpEcSlaveAssy> list);

        /// <summary>
        /// 导出
        /// 组立
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveAssyDto> ExportList(PpEcSlaveAssyQueryDto parm);
    }
}
