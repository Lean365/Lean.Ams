using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 检查日报slv
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:22
    /// </summary>
    public interface IPpInspPcbaSlvService : IBaseService<PpInspPcbaSlv>
    {
        /// <summary>
        /// 获取检查日报slv列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpInspPcbaSlvDto> GetList(PpInspPcbaSlvQueryDto parm);

        /// <summary>
        /// 获取检查日报slv信息
        /// </summary>
        /// <param name="PdiSfId"></param>
        /// <returns></returns>
        PpInspPcbaSlv GetInfo(long PdiSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 检查日报slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpInspPcbaSlv AddPpInspPcbaSlv(PpInspPcbaSlv parm);

        /// <summary>
        /// 更新
        /// 检查日报slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpInspPcbaSlv(PpInspPcbaSlv parm);


        /// <summary>
        /// 批量导入
        /// 检查日报slv
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpInspPcbaSlv(List<PpInspPcbaSlv> list);

        /// <summary>
        /// 导出
        /// 检查日报slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpInspPcbaSlvDto> ExportList(PpInspPcbaSlvQueryDto parm);
    }
}
