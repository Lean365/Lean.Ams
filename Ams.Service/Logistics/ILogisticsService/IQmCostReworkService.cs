using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 返工改修
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:26
    /// </summary>
    public interface IQmCostReworkService : IBaseService<QmCostRework>
    {
        /// <summary>
        /// 获取返工改修列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCostReworkDto> GetList(QmCostReworkQueryDto parm);

        /// <summary>
        /// 获取返工改修信息
        /// </summary>
        /// <param name="QcrdSfId"></param>
        /// <returns></returns>
        QmCostRework GetInfo(long QcrdSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 返工改修
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmCostRework AddQmCostRework(QmCostRework parm);

        /// <summary>
        /// 更新
        /// 返工改修
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmCostRework(QmCostRework parm);


        /// <summary>
        /// 批量导入
        /// 返工改修
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmCostRework(List<QmCostRework> list);

        /// <summary>
        /// 导出
        /// 返工改修
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCostReworkDto> ExportList(QmCostReworkQueryDto parm);
    }
}
