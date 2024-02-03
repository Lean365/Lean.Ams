using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 从客诉管理
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 17:05:54)
    /// </summary>
    public interface IComplaintsSlaveService : IBaseService<ComplaintsSlave>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<ComplaintsSlaveDto> GetList(ComplaintsSlaveQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="QmcsSFID"></param>
        /// <returns></returns>
        ComplaintsSlave GetInfo(long QmcsSFID);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        ComplaintsSlave AddComplaintsSlave(ComplaintsSlave parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateComplaintsSlave(ComplaintsSlave parm);


        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<ComplaintsSlaveDto> ExportList(ComplaintsSlaveQueryDto parm);
    }
}
