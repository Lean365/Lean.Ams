using Ams.Model.System;

namespace Ams.Kernel.Services.IService.Monitor
{
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
