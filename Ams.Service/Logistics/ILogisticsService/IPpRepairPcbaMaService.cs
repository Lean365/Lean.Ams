using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 修理日报ma
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:04:48
    /// </summary>
    public interface IPpRepairPcbaMaService : IBaseService<PpRepairPcbaMa>
    {
        /// <summary>
        /// 获取修理日报ma列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairPcbaMaDto> GetList(PpRepairPcbaMaQueryDto parm);

        /// <summary>
        /// 获取修理日报ma信息
        /// </summary>
        /// <param name="PdrSfId"></param>
        /// <returns></returns>
        PpRepairPcbaMa GetInfo(long PdrSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 修理日报ma
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpRepairPcbaMa AddPpRepairPcbaMa(PpRepairPcbaMa parm);

        /// <summary>
        /// 更新
        /// 修理日报ma
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpRepairPcbaMa(PpRepairPcbaMa parm);


        /// <summary>
        /// 批量导入
        /// 修理日报ma
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpRepairPcbaMa(List<PpRepairPcbaMa> list);

        /// <summary>
        /// 导出
        /// 修理日报ma
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairPcbaMaDto> ExportList(PpRepairPcbaMaQueryDto parm);
    }
}
