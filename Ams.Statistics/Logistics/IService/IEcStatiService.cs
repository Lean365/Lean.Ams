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

        ///// <summary>
        ///// ec点数统计
        ///// </summary>
        ///// <param name="parm"></param>
        ///// <returns></returns>
        //int GetEcCount(PpEcMasterQueryDto parm);
    }
}