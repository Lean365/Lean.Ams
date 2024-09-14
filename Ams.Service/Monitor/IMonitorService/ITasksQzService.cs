using Ams.Service;

namespace Ams.Service.Monitor.IMonitorService
{
    public interface ITasksQzService : IBaseService<TasksQz>
    {
        PagedInfo<TasksQz> SelectTaskList(TasksQzQueryDto parm);

        //SysTasksQz GetId(object id);
        int AddTasks(TasksQz parm);

        int UpdateTasks(TasksQz parm);
    }
}