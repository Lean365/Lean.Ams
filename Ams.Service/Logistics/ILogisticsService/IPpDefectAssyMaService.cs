using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 不良
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:09
    /// </summary>
    public interface IPpDefectAssyMaService : IBaseService<PpDefectAssyMa>
    {
        /// <summary>
        /// 获取不良列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpDefectAssyMaDto> GetList(PpDefectAssyMaQueryDto parm);

        /// <summary>
        /// 获取不良信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpDefectAssyMa GetInfo(long Id);
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
        PpDefectAssyMa AddPpDefectAssyMa(PpDefectAssyMa parm);

        /// <summary>
        /// 更新
        /// 不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpDefectAssyMa(PpDefectAssyMa parm);


        /// <summary>
        /// 批量导入
        /// 不良
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpDefectAssyMa(List<PpDefectAssyMa> list);

        /// <summary>
        /// 导出
        /// 不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpDefectAssyMaDto> ExportList(PpDefectAssyMaQueryDto parm);
    }
}
