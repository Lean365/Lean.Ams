using System.Threading.Tasks;
using Ams.Infrastructure.Attribute;
using Ams.Kernel.Model.System;
using Quartz;
using SqlSugar.IOC;

namespace Ams.Tasks.TaskScheduler
{
    /// <summary>
    /// 系统监控
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(Task_SyncTest), ServiceLifetime = LifeTime.Scoped)]
    public class Task_SyncTest : TaskBase, IJob
    {
        //private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public async Task Execute(IJobExecutionContext context)
        {
            await ExecuteJob(context, Run);
        }

        /// <summary>
        /// 任务使用中注意：所有方法都需要使用异步，并且不能少了await
        /// </summary>
        /// <returns></returns>
        public async Task Run()
        {
            await Task.Delay(1);
            //TODO 业务逻辑
            var db = DbScoped.SugarScope;
            var info = await db.Queryable<SysDept>().FirstAsync();

            //其他库操作
            //var db2 = DbScoped.SugarScope.GetConnectionScope(2);
            System.Console.WriteLine("job test");
        }
    }
}