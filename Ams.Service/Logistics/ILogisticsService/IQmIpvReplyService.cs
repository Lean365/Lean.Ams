using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 分析对策
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:44:05
    /// </summary>
    public interface IQmIpvReplyService : IBaseService<QmIpvReply>
    {
        /// <summary>
        /// 获取分析对策列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmIpvReplyDto> GetList(QmIpvReplyQueryDto parm);

        /// <summary>
        /// 获取分析对策信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmIpvReply GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 分析对策
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmIpvReply AddQmIpvReply(QmIpvReply parm);

        /// <summary>
        /// 更新
        /// 分析对策
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmIpvReply(QmIpvReply parm);


        /// <summary>
        /// 批量导入
        /// 分析对策
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmIpvReply(List<QmIpvReply> list);

        /// <summary>
        /// 导出
        /// 分析对策
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmIpvReplyDto> ExportList(QmIpvReplyQueryDto parm);
    }
}
