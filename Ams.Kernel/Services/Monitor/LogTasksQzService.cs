using Ams.Infrastructure.Attribute;
using Ams.Kernel.Services.IService.Monitor;
using Ams.Kernel.Services.IService.Routine;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 任务日志
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient, ServiceType = typeof(ILogTasksQzService))]
    public class LogTasksQzService : BaseService<LogTasksQz>, ILogTasksQzService
    {
        private ITasksQzService _tasksQzService;

        public LogTasksQzService(ITasksQzService tasksQzService)
        {
            _tasksQzService = tasksQzService;
        }

        public async Task<LogTasksQz> AddTaskLog(string jobId, LogTasksQz logModel)
        {
            //获取任务信息
            var model = await _tasksQzService.GetSingleAsync(f => f.ID == jobId);

            if (model != null)
            {
                logModel.JobId = jobId;
                logModel.JobName = model.Name;
                logModel.JobGroup = model.JobGroup;
                logModel.CreateTime = DateTime.Now;
            }

            await InsertAsync(logModel);
            return logModel;
        }
    }
}