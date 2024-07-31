using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 修理日报slv
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:03:40
    /// </summary>
    public interface IPpRepairPcbaSlvService : IBaseService<PpRepairPcbaSlv>
    {
        /// <summary>
        /// 获取修理日报slv列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairPcbaSlvDto> GetList(PpRepairPcbaSlvQueryDto parm);

        /// <summary>
        /// 获取修理日报slv信息
        /// </summary>
        /// <param name="PdrSfId"></param>
        /// <returns></returns>
        PpRepairPcbaSlv GetInfo(long PdrSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 修理日报slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpRepairPcbaSlv AddPpRepairPcbaSlv(PpRepairPcbaSlv parm);

        /// <summary>
        /// 更新
        /// 修理日报slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpRepairPcbaSlv(PpRepairPcbaSlv parm);


        /// <summary>
        /// 批量导入
        /// 修理日报slv
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpRepairPcbaSlv(List<PpRepairPcbaSlv> list);

        /// <summary>
        /// 导出
        /// 修理日报slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairPcbaSlvDto> ExportList(PpRepairPcbaSlvQueryDto parm);
    }
}
