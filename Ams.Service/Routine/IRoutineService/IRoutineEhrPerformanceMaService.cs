using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 绩效
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:21:08
    /// </summary>
    public interface IRoutineEhrPerformanceMaService : IBaseService<RoutineEhrPerformanceMa>
    {
        /// <summary>
        /// 获取绩效列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrPerformanceMaDto> GetList(RoutineEhrPerformanceMaQueryDto parm);

        /// <summary>
        /// 获取绩效信息
        /// </summary>
        /// <param name="EpSfId"></param>
        /// <returns></returns>
        RoutineEhrPerformanceMa GetInfo(long EpSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 绩效
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrPerformanceMa AddRoutineEhrPerformanceMa(RoutineEhrPerformanceMa parm);

        /// <summary>
        /// 更新
        /// 绩效
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrPerformanceMa(RoutineEhrPerformanceMa parm);


        /// <summary>
        /// 批量导入
        /// 绩效
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrPerformanceMa(List<RoutineEhrPerformanceMa> list);

        /// <summary>
        /// 导出
        /// 绩效
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrPerformanceMaDto> ExportList(RoutineEhrPerformanceMaQueryDto parm);
    }
}
