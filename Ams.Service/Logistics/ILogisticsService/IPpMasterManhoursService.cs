using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 标准工时
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:31:00
    /// </summary>
    public interface IPpMasterManhoursService : IBaseService<PpMasterManhours>
    {
        /// <summary>
        /// 获取标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpMasterManhoursDto> GetList(PpMasterManhoursQueryDto parm);

        /// <summary>
        /// 获取标准工时信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpMasterManhours GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 标准工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpMasterManhours AddPpMasterManhours(PpMasterManhours parm);

        /// <summary>
        /// 更新
        /// 标准工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpMasterManhours(PpMasterManhours parm);


        /// <summary>
        /// 批量导入
        /// 标准工时
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpMasterManhours(List<PpMasterManhours> list);

        /// <summary>
        /// 导出
        /// 标准工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpMasterManhoursDto> ExportList(PpMasterManhoursQueryDto parm);
    }
}
