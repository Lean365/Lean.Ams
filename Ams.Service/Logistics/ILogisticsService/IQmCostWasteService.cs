using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 废弃部品
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:57
    /// </summary>
    public interface IQmCostWasteService : IBaseService<QmCostWaste>
    {
        /// <summary>
        /// 获取废弃部品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCostWasteDto> GetList(QmCostWasteQueryDto parm);

        /// <summary>
        /// 获取废弃部品信息
        /// </summary>
        /// <param name="QcwdSfId"></param>
        /// <returns></returns>
        QmCostWaste GetInfo(long QcwdSfId);
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
        QmCostWaste AddQmCostWaste(QmCostWaste parm);

        /// <summary>
        /// 更新
        /// 废弃部品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmCostWaste(QmCostWaste parm);


        /// <summary>
        /// 批量导入
        /// 废弃部品
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmCostWaste(List<QmCostWaste> list);

        /// <summary>
        /// 导出
        /// 废弃部品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCostWasteDto> ExportList(QmCostWasteQueryDto parm);
    }
}
