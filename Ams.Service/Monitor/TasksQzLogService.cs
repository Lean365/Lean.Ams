using Ams.Infrastructure.Attribute;
using Ams.Service.Monitor.IMonitorService;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Monitor
{
    /// <summary>
    /// 任务日志
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient, ServiceType = typeof(ITasksQzLogService))]
    public class TasksQzLogService : BaseService<TasksQzLog>, ITasksQzLogService
    {
        private ITasksQzService _tasksQzService;

        public TasksQzLogService(ITasksQzService tasksQzService)
        {
            _tasksQzService = tasksQzService;
        }

        public async Task<TasksQzLog> AddTaskLog(string jobId, TasksQzLog logModel)
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