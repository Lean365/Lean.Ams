using Ams.Model.Logistics.Dto;

namespace Ams.Statistics.Logistics.IService
{
    /// <summary>
    /// 业务层接口
    /// service接口
    /// </summary>
    public interface IAssyDefectStatiService : IBaseService<PpDefectAssyMa>
    {
        /// <summary>
        /// 本月组立不良台数
        /// </summary>
        /// <returns></returns>
        int GetMonthlyPoorQty(PpDefectAssyMaQueryDto parm);

        /// <summary>
        /// 按月统计组立不良报表
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthPoor(PpDefectAssyMaQueryDto parm);

        /// <summary>
        /// 导出月度组立不良报表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportListMonthPoor(PpDefectAssyMaQueryDto parm);

        /// <summary>
        /// 按月，班组统计组立不良--柱状图
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthlyPoorBar(PpDefectAssyMaQueryDto parm);
    }
}