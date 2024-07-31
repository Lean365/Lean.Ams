using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 主客诉管理
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:33:20
    /// </summary>
    public interface IQmComplaintsMasterService : IBaseService<QmComplaintsMaster>
    {
        /// <summary>
        /// 获取主客诉管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmComplaintsMasterDto> GetList(QmComplaintsMasterQueryDto parm);

        /// <summary>
        /// 获取主客诉管理信息
        /// </summary>
        /// <param name="QmcmSfId"></param>
        /// <returns></returns>
        QmComplaintsMaster GetInfo(long QmcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 主客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmComplaintsMaster AddQmComplaintsMaster(QmComplaintsMaster parm);

        /// <summary>
        /// 更新
        /// 主客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmComplaintsMaster(QmComplaintsMaster parm);


        /// <summary>
        /// 批量导入
        /// 主客诉管理
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmComplaintsMaster(List<QmComplaintsMaster> list);

        /// <summary>
        /// 导出
        /// 主客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmComplaintsMasterDto> ExportList(QmComplaintsMasterQueryDto parm);
    }
}
