using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 组立不良ma
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:00:50
    /// </summary>
    public interface IPpRepairAssyMaService : IBaseService<PpRepairAssyMa>
    {
        /// <summary>
        /// 获取组立不良ma列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairAssyMaDto> GetList(PpRepairAssyMaQueryDto parm);

        /// <summary>
        /// 获取组立不良ma信息
        /// </summary>
        /// <param name="PpdSfId"></param>
        /// <returns></returns>
        PpRepairAssyMa GetInfo(long PpdSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 组立不良ma
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpRepairAssyMa AddPpRepairAssyMa(PpRepairAssyMa parm);

        /// <summary>
        /// 更新
        /// 组立不良ma
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpRepairAssyMa(PpRepairAssyMa parm);


        /// <summary>
        /// 批量导入
        /// 组立不良ma
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpRepairAssyMa(List<PpRepairAssyMa> list);

        /// <summary>
        /// 导出
        /// 组立不良ma
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpRepairAssyMaDto> ExportList(PpRepairAssyMaQueryDto parm);
    }
}
