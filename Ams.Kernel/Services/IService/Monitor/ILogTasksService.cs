using Ams.Kernel.Model.Monitor;

namespace Ams.Kernel.Services.IService.Monitor
{
    public interface ILogTasksQzService : IBaseService<LogTasks>
    {
        /// <summary>
        /// 记录任务执行日志
        /// </summary>
        /// <returns></returns>
        //public int AddTaskLog(string jobId);
        Task<LogTasks> AddTaskLog(string jobId, LogTasks LogTasks);
    }
}
