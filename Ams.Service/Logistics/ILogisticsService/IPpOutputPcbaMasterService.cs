using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 制二OPH主表
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 9:31:22
    /// </summary>
    public interface IPpOutputPcbaMasterService : IBaseService<PpOutputPcbaMaster>
    {
        /// <summary>
        /// 获取制二OPH主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputPcbaMasterDto> GetList(PpOutputPcbaMasterQueryDto parm);

        /// <summary>
        /// 获取制二OPH主表信息
        /// </summary>
        /// <param name="PomSfid"></param>
        /// <returns></returns>
        PpOutputPcbaMaster GetInfo(long PomSfid);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 制二OPH主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputPcbaMaster AddPpOutputPcbaMaster(PpOutputPcbaMaster parm);

        /// <summary>
        /// 更新
        /// 制二OPH主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputPcbaMaster(PpOutputPcbaMaster parm);


        /// <summary>
        /// 批量导入
        /// 制二OPH主表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputPcbaMaster(List<PpOutputPcbaMaster> list);

        /// <summary>
        /// 导出
        /// 制二OPH主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputPcbaMasterDto> ExportList(PpOutputPcbaMasterQueryDto parm);
    }
}
