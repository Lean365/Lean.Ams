using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// oph主表
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/29 8:56:11
    /// </summary>
    public interface IPpOutputMasterService : IBaseService<PpOutputMaster>
    {
        /// <summary>
        /// 获取oph主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputMasterDto> GetList(PpOutputMasterQueryDto parm);

        /// <summary>
        /// 获取oph主表信息
        /// </summary>
        /// <param name="PomSfid"></param>
        /// <returns></returns>
        PpOutputMaster GetInfo(long PomSfid);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);


        /// <summary>
        /// 新增
        /// oph主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputMaster AddPpOutputMaster(PpOutputMaster parm);
        /// <summary>
        /// 更新
        /// oph主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputMaster(PpOutputMaster parm);

        /// <summary>
        /// 批量导入
        /// oph主表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputMaster(List<PpOutputMaster> list);

        /// <summary>
        /// 导出
        /// oph主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputMasterDto> ExportList(PpOutputMasterQueryDto parm);
    }
}
