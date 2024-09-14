using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// QC客诉
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:13:49
    /// </summary>
    public interface IQmComplaintsQcService : IBaseService<QmComplaintsQc>
    {
        /// <summary>
        /// 获取QC客诉列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmComplaintsQcDto> GetList(QmComplaintsQcQueryDto parm);

        /// <summary>
        /// 获取QC客诉信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmComplaintsQc GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// QC客诉
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmComplaintsQc AddQmComplaintsQc(QmComplaintsQc parm);

        /// <summary>
        /// 更新
        /// QC客诉
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmComplaintsQc(QmComplaintsQc parm);


        /// <summary>
        /// 批量导入
        /// QC客诉
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmComplaintsQc(List<QmComplaintsQc> list);

        /// <summary>
        /// 导出
        /// QC客诉
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmComplaintsQcDto> ExportList(QmComplaintsQcQueryDto parm);
    }
}
