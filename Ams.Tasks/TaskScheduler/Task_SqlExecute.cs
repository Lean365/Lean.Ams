using System.Threading.Tasks;
using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.CustomExceptions;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Services.IService.Routine;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using SqlSugar.IOC;

namespace Ams.Tasks.TaskScheduler
{
    /// <summary>
    /// 系统监控
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(Task_SqlExecute), ServiceLifetime = LifeTime.Scoped)]
    public class Task_SqlExecute : TaskBase, IJob
    {
        private readonly ITasksQzService tasksQzService;
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Task_SqlExecute(ITasksQzService tasksQzService)
        {
            this.tasksQzService = tasksQzService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await ExecuteJob(context, async () => await Run(context));
        }

        public async Task Run(IJobExecutionContext context)
        {
            AbstractTrigger trigger = (context as JobExecutionContextImpl).Trigger as AbstractTrigger;

            var info = await tasksQzService.GetByIdAsync(trigger.JobName);

            if (info != null && info.SqlText.IsNotEmpty())
            {
                var result = DbScoped.SugarScope.Ado.ExecuteCommandWithGo(info.SqlText);
                logger.Info($"任务【{info.Name}】sql请求执行结果=" + result);
            }
            else
            {
                throw new CustomException($"任务{trigger?.JobName}执行失败，任务不存在");
            }
        }
    }
}