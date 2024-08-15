using Ams.Model;
using Ams.Model.Monitor.Dto;
using Ams.Service.Monitor.IMonitorService;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 任务日志
    /// API控制器
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    [Verify]
    [Route("/monitor/tasksqz")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class TasksQzLogController : BaseController
    {
        private readonly ITasksQzLogService tasksLogService;

        public TasksQzLogController(ITasksQzLogService tasksLogService)
        {
            this.tasksLogService = tasksLogService;
        }

        /// <summary>
        /// 查询日志
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
            predicate = predicate.AndIF(queryDto.IsStatus.ToString().IfNotEmpty(), m => m.IsStatus == queryDto.IsStatus);
            predicate = predicate.AndIF(queryDto.JobId.IfNotEmpty(), m => m.JobId == queryDto.JobId);

            var response = tasksLogService.GetPages(predicate.ToExpression(), pager, m => m.CreateTime, OrderByType.Desc);

            return SUCCESS(response, TIME_FORMAT_FULL);
        }

        /// <summary>
        /// 删除定时任务调用日志
        /// </summary>
        /// <param name="jobIds"></param>
        /// <returns></returns>
        [HttpDelete("{jobIds}")]
        [ActionPermissionFilter(Permission = "monitor:tasksqz:delete")]
        [Log(Title = "删除任务日志", BusinessType = BusinessType.DELETE)]
        public IActionResult Delete(string jobIds)
        {
            long[] jobIdArr = Tools.SpitLongArrary(jobIds);

            int result = tasksLogService.Delete(jobIdArr);

            return ToResponse(result);
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <returns></returns>
        [HttpDelete("clean")]
        [ActionPermissionFilter(Permission = "monitor:tasksqz:empty")]
        [Log(Title = "清空任务日志", BusinessType = BusinessType.EMPTY)]
        public IActionResult Clean()
        {
            tasksLogService.DeleteTable();
            return SUCCESS(1);
        }

        /// <summary>
        /// 定时任务日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "任务日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:tasksqz:export")]
        public IActionResult Export()
        {
            var list = tasksLogService.GetAll();

            string sFileName = ExportExcel(list, "TasksQzLog", "任务日志");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }
    }
}