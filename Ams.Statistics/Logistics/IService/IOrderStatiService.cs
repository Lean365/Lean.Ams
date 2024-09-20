using Ams.Model.Logistics.Dto;

namespace Ams.Statistics.Logistics.IService
{
    /// <summary>
    /// 业务层接口
    /// </summary>
    public interface IOrderStatiService : IBaseService<PpMasterProdorder>
    {
        /// <summary>
        /// 查找当前表中最大ID
        /// </summary>
        /// <returns></returns>
        dynamic GetMaxOrderNumber(string Type);

        /// <summary>
        /// 按类型生成订单号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic GetNewOrderNumber(PpMasterProdorderQueryDto parm);
    }
}