using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 主客诉管理
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 17:38:17)
    /// </summary>
    public interface IComplaintsMasterService : IBaseService<ComplaintsMaster>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<ComplaintsMasterDto> GetList(ComplaintsMasterQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="QmcmSFID"></param>
        /// <returns></returns>
        ComplaintsMaster GetInfo(long QmcmSFID);

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
        ComplaintsMaster AddComplaintsMaster(ComplaintsMaster parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateComplaintsMaster(ComplaintsMaster parm);


        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<ComplaintsMasterDto> ExportList(ComplaintsMasterQueryDto parm);
    }
}
