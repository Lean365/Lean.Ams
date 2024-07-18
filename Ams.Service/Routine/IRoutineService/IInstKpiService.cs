using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// KPI
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:44:18
    /// </summary>
    public interface IInstKpiService : IBaseService<InstKpi>
    {
        /// <summary>
        /// 获取KPI列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstKpiDto> GetList(InstKpiQueryDto parm);

        /// <summary>
        /// 获取KPI信息
        /// </summary>
        /// <param name="IkSFID"></param>
        /// <returns></returns>
        InstKpi GetInfo(long IkSFID);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// KPI
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        InstKpi AddInstKpi(InstKpi parm);

        /// <summary>
        /// 更新
        /// KPI
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateInstKpi(InstKpi parm);


        /// <summary>
        /// 批量导入
        /// KPI
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportInstKpi(List<InstKpi> list);

        /// <summary>
        /// 导出
        /// KPI
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstKpiDto> ExportList(InstKpiQueryDto parm);
    }
}
