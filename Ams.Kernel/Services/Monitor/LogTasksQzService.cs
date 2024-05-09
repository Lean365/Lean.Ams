using Ams.Infrastructure.Attribute;
using Ams.Kernel.Services.IService.Monitor;
using Ams.Kernel.Services.IService.Routine;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 任务日志
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
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
            var httpContext = App.HttpContext;
            logModel.Create_by = HttpContextExtension.GetName(httpContext); //获取当前登录用户
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