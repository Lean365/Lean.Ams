using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// oph主表
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:16:45)
    /// </summary>
    public interface IOutputMasterService : IBaseService<OutputMaster>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<OutputMasterDto> GetList(OutputMasterQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="PomSfid"></param>
        /// <returns></returns>
        OutputMaster GetInfo(long PomSfid);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        OutputMaster AddOutputMaster(OutputMaster parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateOutputMaster(OutputMaster parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportOutputMaster(List<OutputMaster> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<OutputMasterDto> ExportList(OutputMasterQueryDto parm);
    }
}
