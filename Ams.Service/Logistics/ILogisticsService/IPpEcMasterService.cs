using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/14 8:48:00
    /// </summary>
    public interface IPpEcMasterService : IBaseService<PpEcMaster>
    {
        /// <summary>
        /// 获取设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterDto> GetList(PpEcMasterQueryDto parm);

        /// <summary>
        /// 获取设变信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpEcMaster GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMaster AddPpEcMaster(PpEcMaster parm);

        /// <summary>
        /// 更新
        /// 设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMaster(PpEcMaster parm);


        /// <summary>
        /// 批量导入
        /// 设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMaster(List<PpEcMaster> list);

        /// <summary>
        /// 导出
        /// 设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterDto> ExportList(PpEcMasterQueryDto parm);
    }
}
