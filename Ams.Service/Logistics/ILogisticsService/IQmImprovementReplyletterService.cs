using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 分析对策
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:55
    /// </summary>
    public interface IQmImprovementReplyletterService : IBaseService<QmImprovementReplyletter>
    {
        /// <summary>
        /// 获取分析对策列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmImprovementReplyletterDto> GetList(QmImprovementReplyletterQueryDto parm);

        /// <summary>
        /// 获取分析对策信息
        /// </summary>
        /// <param name="QirdSfId"></param>
        /// <returns></returns>
        QmImprovementReplyletter GetInfo(long QirdSfId);
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
        QmImprovementReplyletter AddQmImprovementReplyletter(QmImprovementReplyletter parm);

        /// <summary>
        /// 更新
        /// 分析对策
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmImprovementReplyletter(QmImprovementReplyletter parm);


        /// <summary>
        /// 批量导入
        /// 分析对策
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmImprovementReplyletter(List<QmImprovementReplyletter> list);

        /// <summary>
        /// 导出
        /// 分析对策
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmImprovementReplyletterDto> ExportList(QmImprovementReplyletterQueryDto parm);
    }
}
