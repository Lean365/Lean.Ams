namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 任务日志
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("monitor/taskqz/log")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class TasksQzLogController : BaseController
    {
        private readonly ITasksQzLogService TasksQzLogService;

        public TasksQzLogController(ITasksQzLogService TasksQzLogService)
        {
            this.TasksQzLogService = TasksQzLogService;
        }

        /// <summary>
        /// 查询任务日志
        /// </summary>
        /// <param name="queryDto"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult GetList([FromQuery] PagerInfo pager, [FromQuery] TasksQzLogQueryDto queryDto)
        {
            queryDto.BeginTime = DateTimeHelper.GetBeginTime(queryDto.BeginTime, -7);
            queryDto.EndTime = DateTimeHelper.GetBeginTime(queryDto.EndTime, 7);

            var predicate = Expressionable.Create<TasksQzLog>().And(it => it.CreateTime >= queryDto.BeginTime && it.CreateTime <= queryDto.EndTime);
            predicate = predicate.AndIF(queryDto.JobName.IfNotEmpty(), m => m.JobName.Contains(queryDto.JobName));
            predicate = predicate.AndIF(queryDto.JobGroup.IfNotEmpty(), m => m.JobGroup == queryDto.JobGroup);
            predicate = predicate.AndIF(queryDto.IsStated.ToString().IfNotEmpty(), m => m.IsStated == queryDto.IsStated);
            predicate = predicate.AndIF(queryDto.JobId.IfNotEmpty(), m => m.JobId == queryDto.JobId);

            var response = TasksQzLogService.GetPages(predicate.ToExpression(), pager, m => m.CreateTime, OrderByType.Desc);

            return SUCCESS(response, TIME_FORMAT_FULL);
        }

        /// <summary>
        /// 删除定时任务调用日志
        /// </summary>
        /// <param name="jobIds"></param>
        /// <returns></returns>
        [HttpDelete("{jobIds}")]
        [ActionPermissionFilter(Permission = "monitor:taskqzlog:delete")]
        [Log(Title = "删除任务日志", BusinessType = BusinessType.DELETE)]
        public IActionResult Delete(string jobIds)
        {
            long[] jobIdArr = Tools.SpitLongArrary(jobIds);

            int result = TasksQzLogService.Delete(jobIdArr);

            return ToResponse(result);
        }

        /// <summary>
        /// 清空任务日志
        /// </summary>
        /// <returns></returns>
        [HttpDelete("clean")]
        [ActionPermissionFilter(Permission = "monitor:taskqzlog:clean")]
        [Log(Title = "清空任务日志", BusinessType = BusinessType.CLEAN)]
        public IActionResult Clean()
        {
            TasksQzLogService.DeleteTable();
            return SUCCESS(1);
        }

        /// <summary>
        /// 定时任务日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "定时任务日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:taskqzlog:export")]
        public IActionResult Export()
        {
            var list = TasksQzLogService.GetAll();

            string sFileName = ExportExcel(list, "taskqzlog", "定时任务日志");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }
    }
}