using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 薪资
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:32:33
    /// </summary>
    public interface IRoutineEhrPayrollService : IBaseService<RoutineEhrPayroll>
    {
        /// <summary>
        /// 获取薪资列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrPayrollDto> GetList(RoutineEhrPayrollQueryDto parm);

        /// <summary>
        /// 获取薪资信息
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        RoutineEhrPayroll GetInfo(long EeSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 薪资
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrPayroll AddRoutineEhrPayroll(RoutineEhrPayroll parm);

        /// <summary>
        /// 更新
        /// 薪资
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrPayroll(RoutineEhrPayroll parm);


        /// <summary>
        /// 批量导入
        /// 薪资
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrPayroll(List<RoutineEhrPayroll> list);

        /// <summary>
        /// 导出
        /// 薪资
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrPayrollDto> ExportList(RoutineEhrPayrollQueryDto parm);
    }
}
