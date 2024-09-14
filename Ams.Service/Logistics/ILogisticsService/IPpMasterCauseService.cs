using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 原因类别
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:44:02
    /// </summary>
    public interface IPpMasterCauseService : IBaseService<PpMasterCause>
    {
        /// <summary>
        /// 获取原因类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpMasterCauseDto> GetList(PpMasterCauseQueryDto parm);

        /// <summary>
        /// 获取原因类别信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpMasterCause GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpMasterCause AddPpMasterCause(PpMasterCause parm);

        /// <summary>
        /// 更新
        /// 原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpMasterCause(PpMasterCause parm);


        /// <summary>
        /// 批量导入
        /// 原因类别
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpMasterCause(List<PpMasterCause> list);

        /// <summary>
        /// 导出
        /// 原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpMasterCauseDto> ExportList(PpMasterCauseQueryDto parm);
    }
}
