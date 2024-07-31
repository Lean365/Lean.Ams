using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 组立不良slv
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 11:58:58
    /// </summary>
    public interface IPpRepairAssySlvService : IBaseService<PpRepairAssySlv>
    {
        /// <summary>
        /// 获取组立不良slv列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairAssySlvDto> GetList(PpRepairAssySlvQueryDto parm);

        /// <summary>
        /// 获取组立不良slv信息
        /// </summary>
        /// <param name="PpdSfId"></param>
        /// <returns></returns>
        PpRepairAssySlv GetInfo(long PpdSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 组立不良slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpRepairAssySlv AddPpRepairAssySlv(PpRepairAssySlv parm);

        /// <summary>
        /// 更新
        /// 组立不良slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpRepairAssySlv(PpRepairAssySlv parm);


        /// <summary>
        /// 批量导入
        /// 组立不良slv
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpRepairAssySlv(List<PpRepairAssySlv> list);

        /// <summary>
        /// 导出
        /// 组立不良slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairAssySlvDto> ExportList(PpRepairAssySlvQueryDto parm);
    }
}
