using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 制一
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:10
    /// </summary>
    public interface IPpEcMasterAssyService : IBaseService<PpEcMasterAssy>
    {
        /// <summary>
        /// 获取制一列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterAssyDto> GetList(PpEcMasterAssyQueryDto parm);

        /// <summary>
        /// 获取制一信息
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        PpEcMasterAssy GetInfo(long EcmSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 制一
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcMasterAssy AddPpEcMasterAssy(PpEcMasterAssy parm);

        /// <summary>
        /// 更新
        /// 制一
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcMasterAssy(PpEcMasterAssy parm);


        /// <summary>
        /// 批量导入
        /// 制一
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcMasterAssy(List<PpEcMasterAssy> list);

        /// <summary>
        /// 导出
        /// 制一
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcMasterAssyDto> ExportList(PpEcMasterAssyQueryDto parm);
    }
}
