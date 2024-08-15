using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// Pcba设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:40:40
    /// </summary>
    public interface IPpEcSlavePcbaService : IBaseService<PpEcSlavePcba>
    {
        /// <summary>
        /// 获取Pcba设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlavePcbaDto> GetList(PpEcSlavePcbaQueryDto parm);

        /// <summary>
        /// 获取Pcba设变信息
        /// </summary>
        /// <param name="PcbaSfId"></param>
        /// <returns></returns>
        PpEcSlavePcba GetInfo(long PcbaSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// Pcba设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlavePcba AddPpEcSlavePcba(PpEcSlavePcba parm);

        /// <summary>
        /// 更新
        /// Pcba设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlavePcba(PpEcSlavePcba parm);


        /// <summary>
        /// 批量导入
        /// Pcba设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlavePcba(List<PpEcSlavePcba> list);

        /// <summary>
        /// 导出
        /// Pcba设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlavePcbaDto> ExportList(PpEcSlavePcbaQueryDto parm);
    }
}
