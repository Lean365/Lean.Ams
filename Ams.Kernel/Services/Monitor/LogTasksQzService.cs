using Ams.Infrastructure.Attribute;
using Ams.Kernel.Model.Monitor;
using Ams.Kernel.Services.IService.Monitor;
using Ams.Kernel.Services.IService.Routine;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 任务日志
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    [AppService(ServiceLifetime = LifeTime.Transient, ServiceType = typeof(ILogTasksQzService))]
    public class LogTasksQzService : BaseService<LogTasks>, ILogTasksQzService
    {
        private ITasksQzService _tasksQzService;

        public LogTasksQzService(ITasksQzService tasksQzService)
        {
            _tasksQzService = tasksQzService;
        }

        public async Task<LogTasks> AddTaskLog(string jobId, LogTasks logModel)
        {
            //获取任务信息
            var model = await _tasksQzService.GetSingleAsync(f => f.ID == jobId);

            if (model != null)
            {
                logModel.JobId = jobId;
                logModel.JobName = model.Name;
                logModel.JobGroup = model.JobGroup;
                logModel.Create_time = DateTime.Now;
            }

            await InsertAsync(logModel);
            return logModel;
        }
    }
}