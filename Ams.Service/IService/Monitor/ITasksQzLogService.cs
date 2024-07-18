namespace Ams.Service.IService.Monitor
{
    public interface ITasksQzLogService : IBaseService<TasksQzLog>
    {
        /// <summary>
        /// 记录任务执行日志
        /// </summary>
        /// <returns></returns>
        //public int AddTaskLog(string jobId);
        Task<TasksQzLog> AddTaskLog(string jobId, TasksQzLog tasksLog);
    }
}