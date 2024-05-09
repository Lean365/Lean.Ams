using Ams.Model;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 定时任务
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface ITasksQzService : IBaseService<TasksQz>
    {
        PagedInfo<TasksQz> SelectTaskList(TasksQzQueryDto parm);

        //TasksQz GetId(object id);
        int AddTasks(TasksQz parm);

        int UpdateTasks(TasksQz parm);
    }
}