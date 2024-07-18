namespace Ams.Service.IService.Routine
{
    public interface ITasksQzService : IBaseService<TasksQz>
    {
        PagedInfo<TasksQz> SelectTaskList(TasksQzQueryDto parm);

        //SysTasksQz GetId(object id);
        int AddTasks(TasksQz parm);

        int UpdateTasks(TasksQz parm);
    }
}