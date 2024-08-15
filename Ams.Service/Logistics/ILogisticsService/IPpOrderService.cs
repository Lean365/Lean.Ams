using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 生产工单
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:07:48
    /// </summary>
    public interface IPpOrderService : IBaseService<PpOrder>
    {
        /// <summary>
        /// 获取生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOrderDto> GetList(PpOrderQueryDto parm);

        /// <summary>
        /// 获取生产工单信息
        /// </summary>
        /// <param name="MoSfId"></param>
        /// <returns></returns>
        PpOrder GetInfo(long MoSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOrder AddPpOrder(PpOrder parm);

        /// <summary>
        /// 更新
        /// 生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOrder(PpOrder parm);


        /// <summary>
        /// 批量导入
        /// 生产工单
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOrder(List<PpOrder> list);

        /// <summary>
        /// 导出
        /// 生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOrderDto> ExportList(PpOrderQueryDto parm);
    }
}
