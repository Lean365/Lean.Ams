using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 不良
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:33:52
    /// </summary>
    public interface IPpRepairAssyMaService : IBaseService<PpRepairAssyMa>
    {
        /// <summary>
        /// 获取不良列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairAssyMaDto> GetList(PpRepairAssyMaQueryDto parm);

        /// <summary>
        /// 获取不良信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpRepairAssyMa GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpRepairAssyMa AddPpRepairAssyMa(PpRepairAssyMa parm);

        /// <summary>
        /// 更新
        /// 不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpRepairAssyMa(PpRepairAssyMa parm);


        /// <summary>
        /// 批量导入
        /// 不良
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpRepairAssyMa(List<PpRepairAssyMa> list);

        /// <summary>
        /// 导出
        /// 不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairAssyMaDto> ExportList(PpRepairAssyMaQueryDto parm);
    }
}
