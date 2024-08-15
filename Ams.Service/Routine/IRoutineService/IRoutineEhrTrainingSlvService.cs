using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 培训
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:22:49
    /// </summary>
    public interface IRoutineEhrTrainingSlvService : IBaseService<RoutineEhrTrainingSlv>
    {
        /// <summary>
        /// 获取培训列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrTrainingSlvDto> GetList(RoutineEhrTrainingSlvQueryDto parm);

        /// <summary>
        /// 获取培训信息
        /// </summary>
        /// <param name="EpSfId"></param>
        /// <returns></returns>
        RoutineEhrTrainingSlv GetInfo(long EpSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 培训
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrTrainingSlv AddRoutineEhrTrainingSlv(RoutineEhrTrainingSlv parm);

        /// <summary>
        /// 更新
        /// 培训
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrTrainingSlv(RoutineEhrTrainingSlv parm);


        /// <summary>
        /// 批量导入
        /// 培训
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrTrainingSlv(List<RoutineEhrTrainingSlv> list);

        /// <summary>
        /// 导出
        /// 培训
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrTrainingSlvDto> ExportList(RoutineEhrTrainingSlvQueryDto parm);
    }
}
