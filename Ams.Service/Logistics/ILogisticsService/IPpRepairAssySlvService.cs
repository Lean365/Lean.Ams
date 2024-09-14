using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 不良明细
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:50
    /// </summary>
    public interface IPpRepairAssySlvService : IBaseService<PpRepairAssySlv>
    {
        /// <summary>
        /// 获取不良明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairAssySlvDto> GetList(PpRepairAssySlvQueryDto parm);

        /// <summary>
        /// 获取不良明细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpRepairAssySlv GetInfo(long Id);
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
        PpRepairAssySlv AddPpRepairAssySlv(PpRepairAssySlv parm);

        /// <summary>
        /// 更新
        /// 不良明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpRepairAssySlv(PpRepairAssySlv parm);


        /// <summary>
        /// 批量导入
        /// 不良明细
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpRepairAssySlv(List<PpRepairAssySlv> list);

        /// <summary>
        /// 导出
        /// 不良明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairAssySlvDto> ExportList(PpRepairAssySlvQueryDto parm);
    }
}
