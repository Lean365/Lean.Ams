using Ams.Model.Routine;
using Ams.Model.Routine.Dto;

namespace Ams.Statistics.Routine
{
    /// <summary>
    /// 人员管理
    /// 业务层接口
    /// </summary>
    public interface IEmployeeStatiService : IBaseService<RoutineEhrEmployee>
    {
        /// <summary>
        /// 工号自动生成
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic GetMaxWorkNumber(RoutineEhrEmployeeQueryDto parm);
    }
}