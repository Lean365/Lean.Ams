using Ams.Model.Logistics.Dto;

namespace Ams.Statistics.Logistics.IService
{
    /// <summary>
    /// 业务层接口
    /// service接口
    /// </summary>
    public interface IPcbaOutputStatiService : IBaseService<PpOutputPcbaMa>
    {
        /// <summary>
        /// 查找当前表中最大ID
        /// </summary>
        /// <returns></returns>
        string GetMaxSfId();

        /// <summary>
        /// 本月OPH台数
        /// </summary>
        /// <returns></returns>
        int GetMonthlyOutputQty(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 按月统计OPH报表
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 导出月度OPH报表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListMonthOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 按月，班组统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthLineOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 导出月度OPH-班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListMonthLineOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 按月，机种统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthModelOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 月度OPH-机种
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListMonthModelOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 按年统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 导出年度OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListYearOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 按年，班组统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearLineOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 导出年度OPH-班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListYearLineOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 按年，机种统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearModelOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 导出年度OPH-机种
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListYearModelOutput(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 按月，班组统计OPH--柱状图
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthLineOutputBar(PpOutputPcbaMaQueryDto parm);

        /// <summary>
        /// 当月，班组统计OPH--柱状图
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListCurrentMonthLineOutputBar(PpOutputPcbaMaQueryDto parm);
    }
}