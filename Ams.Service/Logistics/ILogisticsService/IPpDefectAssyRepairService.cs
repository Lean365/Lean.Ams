using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 制一不良
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 14:30:29
    /// </summary>
    public interface IPpDefectAssyRepairService : IBaseService<PpDefectAssyRepair>
    {
        /// <summary>
        /// 获取制一不良列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpDefectAssyRepairDto> GetList(PpDefectAssyRepairQueryDto parm);

        /// <summary>
        /// 获取制一不良信息
        /// </summary>
        /// <param name="PpdSfid"></param>
        /// <returns></returns>
        PpDefectAssyRepair GetInfo(long PpdSfid);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 制一不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpDefectAssyRepair AddPpDefectAssyRepair(PpDefectAssyRepair parm);

        /// <summary>
        /// 更新
        /// 制一不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpDefectAssyRepair(PpDefectAssyRepair parm);


        /// <summary>
        /// 批量导入
        /// 制一不良
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpDefectAssyRepair(List<PpDefectAssyRepair> list);

        /// <summary>
        /// 导出
        /// 制一不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpDefectAssyRepairDto> ExportList(PpDefectAssyRepairQueryDto parm);
    }
}
