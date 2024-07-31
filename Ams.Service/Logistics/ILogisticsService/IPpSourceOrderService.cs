using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 源订单
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:14
    /// </summary>
    public interface IPpSourceOrderService : IBaseService<PpSourceOrder>
    {
        /// <summary>
        /// 获取源订单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceOrderDto> GetList(PpSourceOrderQueryDto parm);

        /// <summary>
        /// 获取源订单信息
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        PpSourceOrder GetInfo(long SfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 源订单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpSourceOrder AddPpSourceOrder(PpSourceOrder parm);

        /// <summary>
        /// 更新
        /// 源订单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpSourceOrder(PpSourceOrder parm);


        /// <summary>
        /// 批量导入
        /// 源订单
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpSourceOrder(List<PpSourceOrder> list);

        /// <summary>
        /// 导出
        /// 源订单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceOrderDto> ExportList(PpSourceOrderQueryDto parm);
    }
}
