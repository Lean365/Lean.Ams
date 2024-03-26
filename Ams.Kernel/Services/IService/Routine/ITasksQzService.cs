using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;
using Ams.Model;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 计划任务
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public interface ITasksQzService : IBaseService<TasksQz>
    {
        PagedInfo<TasksQz> SelectTaskList(TasksQzQueryDto parm);

        //SysTasksQz GetId(object id);
        int AddTasks(TasksQz parm);

        int UpdateTasks(TasksQz parm);
    }
}