namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 任务日志
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface ILogTasksQzService : IBaseService<LogTasksQz>
    {
        /// <summary>
        /// 记录任务执行日志
        /// </summary>
        /// <returns></returns>
        //public int AddTaskLog(string jobId);
        Task<LogTasksQz> AddTaskLog(string jobId, LogTasksQz tasksLog);
    }
}