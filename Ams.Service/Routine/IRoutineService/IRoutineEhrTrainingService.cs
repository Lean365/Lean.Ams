using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 培训
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 8:56:48
    /// </summary>
    public interface IRoutineEhrTrainingService : IBaseService<RoutineEhrTraining>
    {
        /// <summary>
        /// 获取培训列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrTrainingDto> GetList(RoutineEhrTrainingQueryDto parm);

        /// <summary>
        /// 获取培训信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        RoutineEhrTraining GetInfo(long Id);
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
        RoutineEhrTraining AddRoutineEhrTraining(RoutineEhrTraining parm);

        /// <summary>
        /// 更新
        /// 培训
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrTraining(RoutineEhrTraining parm);


        /// <summary>
        /// 批量导入
        /// 培训
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrTraining(List<RoutineEhrTraining> list);

        /// <summary>
        /// 导出
        /// 培训
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrTrainingDto> ExportList(RoutineEhrTrainingQueryDto parm);
    }
}
