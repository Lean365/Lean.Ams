using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 考勤
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:26:15
    /// </summary>
    public interface IRoutineEhrAttendanceService : IBaseService<RoutineEhrAttendance>
    {
        /// <summary>
        /// 获取考勤列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrAttendanceDto> GetList(RoutineEhrAttendanceQueryDto parm);

        /// <summary>
        /// 获取考勤信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        RoutineEhrAttendance GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 考勤
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrAttendance AddRoutineEhrAttendance(RoutineEhrAttendance parm);

        /// <summary>
        /// 更新
        /// 考勤
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrAttendance(RoutineEhrAttendance parm);


        /// <summary>
        /// 批量导入
        /// 考勤
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrAttendance(List<RoutineEhrAttendance> list);

        /// <summary>
        /// 导出
        /// 考勤
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrAttendanceDto> ExportList(RoutineEhrAttendanceQueryDto parm);
    }
}
