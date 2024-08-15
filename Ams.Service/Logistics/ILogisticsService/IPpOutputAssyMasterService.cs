using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 制一OPH主表
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:23
    /// </summary>
    public interface IPpOutputAssyMasterService : IBaseService<PpOutputAssyMaster>
    {
        /// <summary>
        /// 获取制一OPH主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputAssyMasterDto> GetList(PpOutputAssyMasterQueryDto parm);

        /// <summary>
        /// 获取制一OPH主表信息
        /// </summary>
        /// <param name="PomSfId"></param>
        /// <returns></returns>
        PpOutputAssyMaster GetInfo(long PomSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 制一OPH主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputAssyMaster AddPpOutputAssyMaster(PpOutputAssyMaster parm);

        /// <summary>
        /// 更新
        /// 制一OPH主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputAssyMaster(PpOutputAssyMaster parm);


        /// <summary>
        /// 批量导入
        /// 制一OPH主表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputAssyMaster(List<PpOutputAssyMaster> list);

        /// <summary>
        /// 导出
        /// 制一OPH主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputAssyMasterDto> ExportList(PpOutputAssyMasterQueryDto parm);
    }
}
