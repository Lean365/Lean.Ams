namespace Ams.Service.IService.Monitor
{
    /// <summary>
    /// 任务执行日志服务接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
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