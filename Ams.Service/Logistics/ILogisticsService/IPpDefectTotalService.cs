using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 不良统计
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:12
    /// </summary>
    public interface IPpDefectTotalService : IBaseService<PpDefectTotal>
    {
        /// <summary>
        /// 获取不良统计列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpDefectTotalDto> GetList(PpDefectTotalQueryDto parm);

        /// <summary>
        /// 获取不良统计信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpDefectTotal GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 不良统计
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpDefectTotal AddPpDefectTotal(PpDefectTotal parm);

        /// <summary>
        /// 更新
        /// 不良统计
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpDefectTotal(PpDefectTotal parm);


        /// <summary>
        /// 批量导入
        /// 不良统计
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpDefectTotal(List<PpDefectTotal> list);

        /// <summary>
        /// 导出
        /// 不良统计
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpDefectTotalDto> ExportList(PpDefectTotalQueryDto parm);
    }
}
