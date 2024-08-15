using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 培训
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:23:27
    /// </summary>
    public interface IRoutineEhrTrainingMaService : IBaseService<RoutineEhrTrainingMa>
    {
        /// <summary>
        /// 获取培训列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrTrainingMaDto> GetList(RoutineEhrTrainingMaQueryDto parm);

        /// <summary>
        /// 获取培训信息
        /// </summary>
        /// <param name="EpSfId"></param>
        /// <returns></returns>
        RoutineEhrTrainingMa GetInfo(long EpSfId);
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
        RoutineEhrTrainingMa AddRoutineEhrTrainingMa(RoutineEhrTrainingMa parm);

        /// <summary>
        /// 更新
        /// 培训
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrTrainingMa(RoutineEhrTrainingMa parm);


        /// <summary>
        /// 批量导入
        /// 培训
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrTrainingMa(List<RoutineEhrTrainingMa> list);

        /// <summary>
        /// 导出
        /// 培训
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrTrainingMaDto> ExportList(RoutineEhrTrainingMaQueryDto parm);
    }
}
