using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 品管
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:42:29
    /// </summary>
    public interface IPpEcSlaveFqcService : IBaseService<PpEcSlaveFqc>
    {
        /// <summary>
        /// 获取品管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveFqcDto> GetList(PpEcSlaveFqcQueryDto parm);

        /// <summary>
        /// 获取品管信息
        /// </summary>
        /// <param name="FqcSfId"></param>
        /// <returns></returns>
        PpEcSlaveFqc GetInfo(long FqcSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 品管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlaveFqc AddPpEcSlaveFqc(PpEcSlaveFqc parm);

        /// <summary>
        /// 更新
        /// 品管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlaveFqc(PpEcSlaveFqc parm);


        /// <summary>
        /// 批量导入
        /// 品管
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlaveFqc(List<PpEcSlaveFqc> list);

        /// <summary>
        /// 导出
        /// 品管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlaveFqcDto> ExportList(PpEcSlaveFqcQueryDto parm);
    }
}
