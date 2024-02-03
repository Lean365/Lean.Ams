using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 生产工单
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 9:49:40)
    /// </summary>
    public interface IOrderService : IBaseService<Order>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<OrderDto> GetList(OrderQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="MoSFID"></param>
        /// <returns></returns>
        Order GetInfo(long MoSFID);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Order AddOrder(Order parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateOrder(Order parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportOrder(List<Order> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<OrderDto> ExportList(OrderQueryDto parm);
    }
}
