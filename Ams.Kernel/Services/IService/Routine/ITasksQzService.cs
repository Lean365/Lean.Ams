using Ams.Model;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;

namespace Ams.Kernel.Services.IService.Routine
{
    public interface ITasksQzService : IBaseService<TasksQz>
    {
        PagedInfo<TasksQz> SelectTaskList(TasksQzQueryDto parm);
        //SysTasksQz GetId(object id);
        int AddTasks(TasksQz parm);
        int UpdateTasks(TasksQz parm);
    }
}
