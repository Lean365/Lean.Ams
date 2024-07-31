using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 不合格联络
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:53
    /// </summary>
    public interface IQmUnqualifiedContactletterService : IBaseService<QmUnqualifiedContactletter>
    {
        /// <summary>
        /// 获取不合格联络列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmUnqualifiedContactletterDto> GetList(QmUnqualifiedContactletterQueryDto parm);

        /// <summary>
        /// 获取不合格联络信息
        /// </summary>
        /// <param name="QucdSfId"></param>
        /// <returns></returns>
        QmUnqualifiedContactletter GetInfo(long QucdSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 不合格联络
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmUnqualifiedContactletter AddQmUnqualifiedContactletter(QmUnqualifiedContactletter parm);

        /// <summary>
        /// 更新
        /// 不合格联络
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmUnqualifiedContactletter(QmUnqualifiedContactletter parm);


        /// <summary>
        /// 批量导入
        /// 不合格联络
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmUnqualifiedContactletter(List<QmUnqualifiedContactletter> list);

        /// <summary>
        /// 导出
        /// 不合格联络
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmUnqualifiedContactletterDto> ExportList(QmUnqualifiedContactletterQueryDto parm);
    }
}
