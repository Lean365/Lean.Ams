using Ams.Model;
using Ams.Model.Systems;


namespace Ams.Service.IService.Monitor
{
    public interface ITasksQzService : IBaseService<Model.Routine.TasksQz>
    {
        PagedInfo<Model.Routine.TasksQz> SelectTaskList(TasksQueryDto parm);
        //SysTasksQz GetId(object id);
        int AddTasks(Model.Routine.TasksQz parm);
        int UpdateTasks(Model.Routine.TasksQz parm);
    }
}
