using Ams.Kernel;
using Ams.Model.Dto;
using Ams.Model;
using Ams.Model.Logistics;

namespace Ams.Report.Logistics.pp
{
    /// <summary>
    /// 业务层接口
    /// </summary>
    public interface IInstructionService : IBaseService<Order>
    {
        /// <summary>
        /// 查找当前表中最大ID
        /// </summary>
        /// <returns></returns>
      dynamic   QueryMaxSfid(string Type );

        /// <summary>
        /// 按类型生成订单号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic QueryOrderNum(OrderQueryDto parm);
    }
}
