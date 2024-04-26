using System;
using System.Threading.Tasks;
using Ams.Infrastructure;
using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.CustomExceptions;
using Ams.Model.System;
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
    [AppService(ServiceType = typeof(Task_HttpRequest), ServiceLifetime = LifeTime.Scoped)]
    internal class Task_HttpRequest : TaskBase, IJob
    {
        //private readonly ITasksQzService tasksQzService;
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        //public Job_HttpRequest(ITasksQzService tasksQzService)
        //{
        //    this.tasksQzService = tasksQzService;
        //}
        public async Task Execute(IJobExecutionContext context)
        {
            await ExecuteJob(context, async () => await Run(context));
        }

        public async Task Run(IJobExecutionContext context)
        {
            AbstractTrigger trigger = (context as JobExecutionContextImpl).Trigger as AbstractTrigger;
            //var info = await tasksQzService.CopyNew().GetByIdAsync(trigger.JobName);
            var info = await DbScoped.SugarScope.CopyNew()
                .Queryable<TasksQz>()
                .FirstAsync(f => f.ID == trigger.JobName) ?? throw new CustomException($"任务{trigger?.JobName}网络请求执行失败，任务不存在");
            string result;
            if (info.RequestMethod != null && info.RequestMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                result = await HttpHelper.HttpPostAsync(info.ApiUrl, info.JobParams);
            }
            else
            {
                var url = info.ApiUrl;
                if (url.IndexOf("?") > -1)
                {
                    url += "&" + info.JobParams;
                }
                else
                {
                    url += "?" + info.JobParams;
                }
                result = await HttpHelper.HttpGetAsync(url);
            }

            logger.Info($"任务【{info.Name}】网络请求执行结果=" + result);
        }
    }
}