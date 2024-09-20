using Ams.Model.Logistics.Dto;

namespace Ams.Statistics.Logistics.IService
{
    /// <summary>
    /// 业务层接口
    /// service接口
    /// </summary>
    public interface IOutputStatiService : IBaseService<PpOutputAssyMa>
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
        int GetMonthlyOutputQty(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 按月统计OPH报表
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 导出月度OPH报表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListMonthOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 按月，班组统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthLineOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 导出月度OPH-班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListMonthLineOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 按月，机种统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthModelOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 月度OPH-机种
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListMonthModelOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 按年统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 导出年度OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListYearOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 按年，班组统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearLineOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 导出年度OPH-班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListYearLineOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 按年，机种统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearModelOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 导出年度OPH-机种
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListYearModelOutput(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 按月，班组统计OPH--柱状图
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthLineOutputBar(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 当月，班组统计OPH--柱状图
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListCurrentMonthLineOutputBar(PpOutputAssyMaQueryDto parm);
    }
}