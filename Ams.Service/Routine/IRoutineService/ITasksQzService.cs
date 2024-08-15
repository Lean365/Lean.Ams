using Ams.Model.Routine.Dto;

namespace Ams.Service.Routine.IRoutineService
{
    public interface ITasksQzService : IBaseService<TasksQz>
    {
        PagedInfo<TasksQz> SelectTaskList(TasksQzQueryDto parm);

        //SysTasksQz GetId(object id);
        int AddTasks(TasksQz parm);

        int UpdateTasks(TasksQz parm);
    }
}