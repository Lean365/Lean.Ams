using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Ams.Kernel.Filters;
using Ams.Model;
using Ams.Infrastructure.Helper;
using Ams.Kernel.Model.Monitor;
using Ams.Kernel.Model.Dto.Monitor;
using Ams.Kernel.Services.IService.Monitor;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 任务日志
    /// API控制器
    /// @Author: (Lean365:Davis.Cheng)
    /// @Date: (2023-12-15)
    /// </summary>
    [Verify]
    [Route("/monitor/logtasks")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LogTasksQzController : BaseController
    {
        private readonly ILogTasksQzService LogTasksQzService;

        public LogTasksQzController(ILogTasksQzService LogTasksQzService)
        {
            this.LogTasksQzService = LogTasksQzService;
        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="queryDto"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult GetList([FromQuery] PagerInfo pager, [FromQuery] LogTasksQzQueryDto queryDto)
        {
            queryDto.BeginTime = DateTimeHelper.GetBeginTime(queryDto.BeginTime, -7);
            queryDto.EndTime = DateTimeHelper.GetBeginTime(queryDto.EndTime, 7);

            var predicate = Expressionable.Create<LogTasks>().And(it => it.Create_time >= queryDto.BeginTime && it.Create_time <= queryDto.EndTime);
            predicate = predicate.AndIF(queryDto.JobName.IfNotEmpty(), m => m.JobName.Contains(queryDto.JobName));
            predicate = predicate.AndIF(queryDto.JobGroup.IfNotEmpty(), m => m.JobGroup == queryDto.JobGroup);
            predicate = predicate.AndIF(queryDto.IsState.ToString().IfNotEmpty(), m => m.IsState == queryDto.IsState);
            predicate = predicate.AndIF(queryDto.JobId.IfNotEmpty(), m => m.JobId == queryDto.JobId);

            var response = LogTasksQzService.GetPages(predicate.ToExpression(), pager, m => m.Create_time, OrderByType.Desc);

            return SUCCESS(response, TIME_FORMAT_YYYMMDD);
        }

        /// <summary>
        /// 删除定时任务调用日志
        /// </summary>
        /// <param name="jobIds"></param>
        /// <returns></returns>
        [HttpDelete("{jobIds}")]
        [ActionPermissionFilter(Permission = "monitor:logtasks:delete")]
        [Log(Title = "删除任务日志", BusinessType = BusinessType.DELETE)]
        public IActionResult Delete(string jobIds)
        {
            long[] jobIdArr = Tools.SpitLongArrary(jobIds);

            int result = LogTasksQzService.Delete(jobIdArr);

            return ToResponse(result);
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <returns></returns>
        [HttpDelete("clean")]
        [ActionPermissionFilter(Permission = "monitor:logtasks:truncate")]
        [Log(Title = "清空任务日志", BusinessType = BusinessType.CLEAN)]
        public IActionResult Clean()
        {
            LogTasksQzService.DeleteTable();
            return SUCCESS(1);
        }

        /// <summary>
        /// 定时任务日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "定时任务日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:logtasks:export")]
        public IActionResult Export()
        {
            var list = LogTasksQzService.GetAll();

            string sFileName = ExportExcel(list, "LogTasks", "定时任务日志", "export/log");
            return SUCCESS(new { path = "/export/log/" + sFileName, fileName = sFileName });
        }
    }
}
