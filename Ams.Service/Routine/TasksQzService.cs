using Ams.Service.IService.Monitor;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 定时任务
    /// </summary>
    [AppService(ServiceType = typeof(ITasksQzService), ServiceLifetime = LifeTime.Transient)]
    public class TasksQzService : BaseService<Model.Routine.TasksQz>, ITasksQzService
    {
        /// <summary>
        /// 查询任务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<Model.Routine.TasksQz> SelectTaskList(TasksQueryDto parm)
        {
            var predicate = Expressionable.Create<Model.Routine.TasksQz>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QueryText),
                m => m.Name.Contains(parm.QueryText) ||
                m.JobGroup.Contains(parm.QueryText) ||
                m.AssemblyName.Contains(parm.QueryText));
            predicate.AndIF(parm.TaskType != null, m => m.TaskType == parm.TaskType);
            predicate.AndIF(parm.IsStart != null, m => m.IsStart == parm.IsStart);

            return Queryable().Where(predicate.ToExpression())
                .ToPage(parm);
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddTasks(Model.Routine.TasksQz parm)
        {
            parm.IsStart = 0;

            SetAssembleName(parm);

            return Add(parm);
        }

        private void SetAssembleName(Model.Routine.TasksQz parm)
        {
            if (parm.ApiUrl.IfNotEmpty() && parm.TaskType == 2)
            {
                parm.AssemblyName = "Ams.Tasks";
                parm.ClassName = "TaskScheduler.Job_HttpRequest";
            }

            if (parm.SqlText.IfNotEmpty() && parm.TaskType == 3)
            {
                parm.AssemblyName = "Ams.Tasks";
                parm.ClassName = "TaskScheduler.Job_SqlExecute";
            }
        }

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateTasks(Model.Routine.TasksQz parm)
        {
            SetAssembleName(parm);

            return Update(f => f.ID == parm.ID, f => new Model.Routine.TasksQz
            {
                ID = parm.ID,
                Name = parm.Name,
                JobGroup = parm.JobGroup,
                Cron = parm.Cron,
                AssemblyName = parm.AssemblyName,
                ClassName = parm.ClassName,
                Remark = parm.Remark,
                TriggerType = parm.TriggerType,
                IntervalSecond = parm.IntervalSecond,
                JobParams = parm.JobParams,
                Update_time = DateTime.Now,
                BeginTime = parm.BeginTime,
                EndTime = parm.EndTime,
                TaskType = parm.TaskType,
                ApiUrl = parm.ApiUrl,
                SqlText = parm.SqlText,
                RequestMethod = parm.RequestMethod,
            });
        }
    }
}