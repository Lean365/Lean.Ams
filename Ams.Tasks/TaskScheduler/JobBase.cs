using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Ams.Common;
using Ams.Infrastructure;
using Ams.Model.Monitor;
using Ams.Model.Routine;
using Ams.Service.Monitor.IMonitorService;
using Ams.Service.Routine.IRoutineService;
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
        public async Task<TasksQzLog> ExecuteJob(IJobExecutionContext context, Func<Task> job)
        {
            double elapsed = 0;
            int status = 0;
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
                status = 1;
                logMsg = $"Job Run Fail，Exception：{ex.Message}";
                WxNoticeHelper.SendMsg("任务执行出错", logMsg);
            }

            var logModel = new TasksQzLog()
            {
                Elapsed = elapsed,
                IsStatus = status,
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
        public async Task<TasksQzLog> ExecuteJob(IJobExecutionContext context, Func<Task<string>> job)
        {
            double elapsed = 0;
            int status = 0;
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
                status = 1;
                logMsg = $"Job Run Fail，Exception：{ex.Message}";
                WxNoticeHelper.SendMsg("任务执行出错", logMsg);
            }

            var logModel = new TasksQzLog()
            {
                Elapsed = elapsed,
                IsStatus = status,
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
        protected async Task RecordTaskLog(IJobExecutionContext context, TasksQzLog logModel)
        {
            var tasksLogService = (ITasksQzLogService)App.GetRequiredService(typeof(ITasksQzLogService));
            var taskQzService = (ITasksQzService)App.GetRequiredService(typeof(ITasksQzService));

            // 可以直接获取 JobDetail 的值
            IJobDetail job = context.JobDetail;

            logModel.InvokeTarget = job.JobType.FullName;
            logModel = await tasksLogService.AddTaskLog(job.Key.Name, logModel);
            //成功后执行次数+1
            if (logModel.IsStatus == 0)
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