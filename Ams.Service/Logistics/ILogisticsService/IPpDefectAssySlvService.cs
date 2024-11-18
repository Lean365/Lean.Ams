using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 不良明细
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:18:57
    /// </summary>
    public interface IPpDefectAssySlvService : IBaseService<PpDefectAssySlv>
    {
        /// <summary>
        /// 获取不良明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpDefectAssySlvDto> GetList(PpDefectAssySlvQueryDto parm);

        /// <summary>
        /// 获取不良明细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpDefectAssySlv GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 不良明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpDefectAssySlv AddPpDefectAssySlv(PpDefectAssySlv parm);

        /// <summary>
        /// 更新
        /// 不良明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpDefectAssySlv(PpDefectAssySlv parm);


        /// <summary>
        /// 批量导入
        /// 不良明细
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpDefectAssySlv(List<PpDefectAssySlv> list);

        /// <summary>
        /// 导出
        /// 不良明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpDefectAssySlvDto> ExportList(PpDefectAssySlvQueryDto parm);
    }
}
