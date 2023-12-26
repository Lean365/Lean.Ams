using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Filters;
using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Model.Dto.Monitor;
using Ams.Kernel.Services.IService.Monitor;
namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 操作日志
    /// API控制器
    /// @Author: (Lean365:Davis.Cheng)
    /// @Date: (2023-12-15)
    /// </summary>
    [Verify]
    [Route("/monitor/operlog")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LogOperController : BaseController
    {
        private ILogOperService LogOperService;

        public LogOperController(ILogOperService LogOperService)
        {
            this.LogOperService = LogOperService;
        }

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="LogOper"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult OperList([FromQuery] LogOperQueryDto LogOper)
        {
            LogOper.OperName = !HttpContextExtension.IsAdmin(HttpContext) ? HttpContextExtension.GetName(HttpContext) : LogOper.OperName;
            var list = LogOperService.SelectOperLogList(LogOper);

            return SUCCESS(list);
        }

        /// <summary>
        /// 删除操作日志
        /// </summary>
        /// <param name="operIds"></param>
        /// <returns></returns>
        [Log(Title = "操作日志", BusinessType = BusinessType.DELETE)]
        [ActionPermissionFilter(Permission = "monitor:operlog:delete")]
        [HttpDelete("{operIds}")]
        public IActionResult Remove(string operIds)
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            long[] operIdss = Tools.SpitLongArrary(operIds);
            return SUCCESS(LogOperService.DeleteOperLogByIds(operIdss));
        }

        /// <summary>
        /// 清空操作日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空操作日志", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "monitor:operlog:truncate")]
        [HttpDelete("clean")]
        public IActionResult ClearOperLog()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.CUSTOM_ERROR,"操作失败");
            }
            LogOperService.CleanOperLog();

            return SUCCESS(1);
        }

        /// <summary>
        /// 导出操作日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "操作日志", BusinessType = BusinessType.EXPORT)]
        [ActionPermissionFilter(Permission = "monitor:operlog:export")]
        [HttpGet("export")]
        public IActionResult Export([FromQuery] LogOperQueryDto LogOper)
        {
            LogOper.PageSize = 100000;
            var list = LogOperService.SelectOperLogList(LogOper);
            var result = ExportExcelMini(list.Result, "操作日志", "操作日志");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}
