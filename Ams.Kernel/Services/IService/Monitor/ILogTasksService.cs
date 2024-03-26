using Ams.Kernel.Model.Monitor;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 任务日志
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
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