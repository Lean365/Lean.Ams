using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 废弃部品
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/18 8:30:51
    /// </summary>
    public interface IQmCostDiscardService : IBaseService<QmCostDiscard>
    {
        /// <summary>
        /// 获取废弃部品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCostDiscardDto> GetList(QmCostDiscardQueryDto parm);

        /// <summary>
        /// 获取废弃部品信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmCostDiscard GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 废弃部品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmCostDiscard AddQmCostDiscard(QmCostDiscard parm);

        /// <summary>
        /// 更新
        /// 废弃部品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmCostDiscard(QmCostDiscard parm);


        /// <summary>
        /// 批量导入
        /// 废弃部品
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmCostDiscard(List<QmCostDiscard> list);

        /// <summary>
        /// 导出
        /// 废弃部品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCostDiscardDto> ExportList(QmCostDiscardQueryDto parm);
    }
}
