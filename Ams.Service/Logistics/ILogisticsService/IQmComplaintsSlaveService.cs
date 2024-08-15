using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 从客诉管理
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:58
    /// </summary>
    public interface IQmComplaintsSlaveService : IBaseService<QmComplaintsSlave>
    {
        /// <summary>
        /// 获取从客诉管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmComplaintsSlaveDto> GetList(QmComplaintsSlaveQueryDto parm);

        /// <summary>
        /// 获取从客诉管理信息
        /// </summary>
        /// <param name="QmcsSfId"></param>
        /// <returns></returns>
        QmComplaintsSlave GetInfo(long QmcsSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 从客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmComplaintsSlave AddQmComplaintsSlave(QmComplaintsSlave parm);

        /// <summary>
        /// 更新
        /// 从客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmComplaintsSlave(QmComplaintsSlave parm);


        /// <summary>
        /// 批量导入
        /// 从客诉管理
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmComplaintsSlave(List<QmComplaintsSlave> list);

        /// <summary>
        /// 导出
        /// 从客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmComplaintsSlaveDto> ExportList(QmComplaintsSlaveQueryDto parm);
    }
}
