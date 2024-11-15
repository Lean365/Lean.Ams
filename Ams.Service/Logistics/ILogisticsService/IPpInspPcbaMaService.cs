using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 检查
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:26:18
    /// </summary>
    public interface IPpInspPcbaMaService : IBaseService<PpInspPcbaMa>
    {
        /// <summary>
        /// 获取检查列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpInspPcbaMaDto> GetList(PpInspPcbaMaQueryDto parm);

        /// <summary>
        /// 获取检查信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpInspPcbaMa GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 检查
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpInspPcbaMa AddPpInspPcbaMa(PpInspPcbaMa parm);

        /// <summary>
        /// 更新
        /// 检查
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpInspPcbaMa(PpInspPcbaMa parm);


        /// <summary>
        /// 批量导入
        /// 检查
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpInspPcbaMa(List<PpInspPcbaMa> list);

        /// <summary>
        /// 导出
        /// 检查
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpInspPcbaMaDto> ExportList(PpInspPcbaMaQueryDto parm);
    }
}
