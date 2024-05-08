using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;
using Ams.Model;

namespace Ams.Kernel.Services.IService.Routine
{
    public interface ITasksQzService : IBaseService<TasksQz>
    {
        PagedInfo<TasksQz> SelectTaskList(TasksQzQueryDto parm);
        //TasksQz GetId(object id);
        int AddTasks(TasksQz parm);
        int UpdateTasks(TasksQz parm);
    }
}
