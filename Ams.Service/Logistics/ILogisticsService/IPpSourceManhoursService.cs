using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 源工时
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:39:17
    /// </summary>
    public interface IPpSourceManhoursService : IBaseService<PpSourceManhours>
    {
        /// <summary>
        /// 获取源工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceManhoursDto> GetList(PpSourceManhoursQueryDto parm);

        /// <summary>
        /// 获取源工时信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpSourceManhours GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 源工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpSourceManhours AddPpSourceManhours(PpSourceManhours parm);

        /// <summary>
        /// 更新
        /// 源工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpSourceManhours(PpSourceManhours parm);


        /// <summary>
        /// 批量导入
        /// 源工时
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpSourceManhours(List<PpSourceManhours> list);

        /// <summary>
        /// 导出
        /// 源工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceManhoursDto> ExportList(PpSourceManhoursQueryDto parm);
    }
}
