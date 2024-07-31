using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 标准工时
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:04:58
    /// </summary>
    public interface IPpManhoursService : IBaseService<PpManhours>
    {
        /// <summary>
        /// 获取标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpManhoursDto> GetList(PpManhoursQueryDto parm);

        /// <summary>
        /// 获取标准工时信息
        /// </summary>
        /// <param name="MhSfId"></param>
        /// <returns></returns>
        PpManhours GetInfo(long MhSfId);
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
        PpManhours AddPpManhours(PpManhours parm);

        /// <summary>
        /// 更新
        /// 标准工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpManhours(PpManhours parm);


        /// <summary>
        /// 批量导入
        /// 标准工时
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpManhours(List<PpManhours> list);

        /// <summary>
        /// 导出
        /// 标准工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpManhoursDto> ExportList(PpManhoursQueryDto parm);
    }
}
