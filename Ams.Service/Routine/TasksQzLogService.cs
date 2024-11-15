﻿namespace Ams.Service.Routine
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
                logModel.Create_by = HttpContextExtension.GetName(App.HttpContext);
                logModel.Create_time = DateTime.Now;
            }

            await InsertAsync(logModel);
            return logModel;
        }
    }
}