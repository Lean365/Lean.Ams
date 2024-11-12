using Ams.Model.Logistics.Dto;

namespace Ams.Statistics.Logistics.IService
{
    /// <summary>
    /// ec
    /// 业务层接口
    /// </summary>
    public interface IEcStatiService : IBaseService<PpEcSlave>
    {
        /// <summary>
        /// ec点数统计
        /// </summary>
        /// <returns></returns>
        int GetEcCount(PpEcSlaveQueryDto parm);

        /// <summary>
        /// 按月统计ec点数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthlyEc(PpEcSlaveQueryDto parm);

        /// <summary>
        /// 按月，按月统计ec--柱状图
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthlyEcBar(PpEcSlaveQueryDto parm);
    }
}