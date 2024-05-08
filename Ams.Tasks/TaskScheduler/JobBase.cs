using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Ams.Common;
using Ams.Infrastructure.Apps;
using Ams.Kernel.Model.Monitor;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Services.IService.Monitor;
using Ams.Kernel.Services.IService.Routine;
using NLog;
using Quartz;

namespace Ams.Tasks
{
    public class JobBase
    {
        /// <summary>
        /// 日志接口
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 执行指定任务
        /// </summary>
        /// <param name="context">作业上下文</param>
        /// <param name="job">业务逻辑方法</param>
        public async Task<LogTasksQz> ExecuteJob(IJobExecutionContext context, Func<Task> job)
        {
            double elapsed = 0;
            int isStated = 0;
            string logMsg;
            try
            {
                //var s = context.Trigger.Key.Name;
                //记录Job时间
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //执行任务
                await job();
                stopwatch.Stop();
                elapsed = stopwatch.Elapsed.TotalMilliseconds;
                logMsg = "success";
            }
            catch (Exception ex)
            {
                JobExecutionException e2 = new(ex)
                {
                    //true  是立即重新执行任务
                    RefireImmediately = true
                };
                isStated = 1;
                logMsg = $"Job Run Fail，Exception：{ex.Message}";
                WxNoticeHelper.SendMsg("任务执行出错", logMsg);
            }

            var logModel = new LogTasksQz()
            {
                Elapsed = elapsed,
                IsStated = isStated,
                JobMessage = logMsg
            };

            await RecordTaskLog(context, logModel);
            return logModel;
        }

        /// <summary>
        /// 执行指定任务（接收返回结果）
        /// </summary>
        /// <param name="context">作业上下文</param>
        /// <param name="job">业务逻辑方法</param>
        public async Task<LogTasksQz> ExecuteJob(IJobExecutionContext context, Func<Task<string>> job)
        {
            double elapsed = 0;
            int isStated = 0;
            string logMsg;
            try
            {
                //var s = context.Trigger.Key.Name;
                //记录Job时间
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //执行任，并返回结果
                string result = await job();
                stopwatch.Stop();
                elapsed = stopwatch.Elapsed.TotalMilliseconds;
                logMsg = result.Length <= 2000 ? result : result.Substring(0, 2000);
            }
            catch (Exception ex)
            {
                JobExecutionException e2 = new(ex)
                {
                    //true  是立即重新执行任务
                    RefireImmediately = true
                };
                isStated = 1;
                logMsg = $"Job Run Fail，Exception：{ex.Message}";
                WxNoticeHelper.SendMsg("任务执行出错", logMsg);
            }

            var logModel = new LogTasksQz()
            {
                Elapsed = elapsed,
                IsStated = isStated,
                JobMessage = logMsg
            };

            await RecordTaskLog(context, logModel);
            return logModel;
        }

        /// <summary>
        /// 记录到日志
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logModel"></param>
        protected async Task RecordTaskLog(IJobExecutionContext context, LogTasksQz logModel)
        {
            var tasksLogService = (ILogTasksQzService)App.GetRequiredService(typeof(ILogTasksQzService));
            var taskQzService = (ITasksQzService)App.GetRequiredService(typeof(ITasksQzService));

            // 可以直接获取 JobDetail 的值
            IJobDetail job = context.JobDetail;

            logModel.InvokeTarget = job.JobType.FullName;
            logModel = await tasksLogService.AddTaskLog(job.Key.Name, logModel);
            //成功后执行次数+1
            if (logModel.IsStated == 0)
            {
                await taskQzService.UpdateAsync(f => new TasksQz()
                {
                    RunTimes = f.RunTimes + 1,
                    LastRunTime = DateTime.Now
                }, f => f.ID == job.Key.Name);
            }
            logger.Info($"执行任务【{job.Key.Name}|{logModel.JobName}】结果={logModel.JobMessage}");
        }
    }
}