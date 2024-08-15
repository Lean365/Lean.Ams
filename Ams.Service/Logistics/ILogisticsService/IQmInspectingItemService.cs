using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 检测项目
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:07:59
    /// </summary>
    public interface IQmInspectingItemService : IBaseService<QmInspectingItem>
    {
        /// <summary>
        /// 获取检测项目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmInspectingItemDto> GetList(QmInspectingItemQueryDto parm);

        /// <summary>
        /// 获取检测项目信息
        /// </summary>
        /// <param name="QminsItemSfId"></param>
        /// <returns></returns>
        QmInspectingItem GetInfo(long QminsItemSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 检测项目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmInspectingItem AddQmInspectingItem(QmInspectingItem parm);

        /// <summary>
        /// 更新
        /// 检测项目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmInspectingItem(QmInspectingItem parm);


        /// <summary>
        /// 批量导入
        /// 检测项目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmInspectingItem(List<QmInspectingItem> list);

        /// <summary>
        /// 导出
        /// 检测项目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmInspectingItemDto> ExportList(QmInspectingItemQueryDto parm);
    }
}
