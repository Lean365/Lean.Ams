using Ams.Model.System;
using Ams.Model.System.Dto;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 任务计划
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface ITasksQzService : IBaseService<TasksQz>
    {
        PagedInfo<TasksQz> SelectTaskList(TasksQzQueryDto parm);

        //TasksQz GetId(object id);
        int AddTasks(TasksQz parm);

        int UpdateTasks(TasksQz parm);
    }
}