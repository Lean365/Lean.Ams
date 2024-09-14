using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 修理
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:10:27
    /// </summary>
    public interface IPpRepairPcbaMaService : IBaseService<PpRepairPcbaMa>
    {
        /// <summary>
        /// 获取修理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairPcbaMaDto> GetList(PpRepairPcbaMaQueryDto parm);

        /// <summary>
        /// 获取修理信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpRepairPcbaMa GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 修理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpRepairPcbaMa AddPpRepairPcbaMa(PpRepairPcbaMa parm);

        /// <summary>
        /// 更新
        /// 修理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpRepairPcbaMa(PpRepairPcbaMa parm);


        /// <summary>
        /// 批量导入
        /// 修理
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpRepairPcbaMa(List<PpRepairPcbaMa> list);

        /// <summary>
        /// 导出
        /// 修理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairPcbaMaDto> ExportList(PpRepairPcbaMaQueryDto parm);
    }
}
