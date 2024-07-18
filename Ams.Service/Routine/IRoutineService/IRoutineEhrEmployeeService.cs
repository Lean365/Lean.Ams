using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 人事信息
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:48:53
    /// </summary>
    public interface IRoutineEhrEmployeeService : IBaseService<RoutineEhrEmployee>
    {
        /// <summary>
        /// 获取人事信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrEmployeeDto> GetList(RoutineEhrEmployeeQueryDto parm);

        /// <summary>
        /// 获取人事信息信息
        /// </summary>
        /// <param name="EeSFID"></param>
        /// <returns></returns>
        RoutineEhrEmployee GetInfo(long EeSFID);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 人事信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrEmployee AddRoutineEhrEmployee(RoutineEhrEmployee parm);

        /// <summary>
        /// 更新
        /// 人事信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrEmployee(RoutineEhrEmployee parm);


        /// <summary>
        /// 批量导入
        /// 人事信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrEmployee(List<RoutineEhrEmployee> list);

        /// <summary>
        /// 导出
        /// 人事信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrEmployeeDto> ExportList(RoutineEhrEmployeeQueryDto parm);
    }
}
