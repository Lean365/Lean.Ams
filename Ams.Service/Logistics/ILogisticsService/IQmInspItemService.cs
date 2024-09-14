using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 检测项目
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:48:49
    /// </summary>
    public interface IQmInspItemService : IBaseService<QmInspItem>
    {
        /// <summary>
        /// 获取检测项目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmInspItemDto> GetList(QmInspItemQueryDto parm);

        /// <summary>
        /// 获取检测项目信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmInspItem GetInfo(long Id);
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
        QmInspItem AddQmInspItem(QmInspItem parm);

        /// <summary>
        /// 更新
        /// 检测项目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmInspItem(QmInspItem parm);


        /// <summary>
        /// 批量导入
        /// 检测项目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmInspItem(List<QmInspItem> list);

        /// <summary>
        /// 导出
        /// 检测项目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmInspItemDto> ExportList(QmInspItemQueryDto parm);
    }
}
