using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// PCBA OPH
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:18:45
    /// </summary>
    public interface IPpOutputPcbaMaService : IBaseService<PpOutputPcbaMa>
    {
        /// <summary>
        /// 获取PCBA OPH列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputPcbaMaDto> GetList(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 获取PCBA OPH信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpOutputPcbaMa GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// PCBA OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputPcbaMa AddPpOutputPcbaMa(PpOutputPcbaMa parm);

        /// <summary>
        /// 更新
        /// PCBA OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputPcbaMa(PpOutputPcbaMa parm);


        /// <summary>
        /// 批量导入
        /// PCBA OPH
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputPcbaMa(List<PpOutputPcbaMa> list);

        /// <summary>
        /// 导出
        /// PCBA OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputPcbaMaDto> ExportList(PpOutputPcbaMaQueryDto parm);
    }
}
