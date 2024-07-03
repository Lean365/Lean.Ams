using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 操作日志
    /// API控制器
    /// @author Lean365(Davis.Ching)
    /// @date 2022-01-11
    /// </summary>
    [Verify]
    [Route("/monitor/oper")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class OperlogController : BaseController
    {
        private IOperLogService sysOperLogService;

        public OperlogController(IOperLogService sysOperLogService)
        {
            this.sysOperLogService = sysOperLogService;
        }

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="sysOperLog"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult OperList([FromQuery] OperLogQueryDto sysOperLog)
        {
            sysOperLog.OperName = !HttpContext.IsAdmin() ? HttpContext.GetName() : sysOperLog.OperName;
            var list = sysOperLogService.SelectOperLogList(sysOperLog);

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
            if (!HttpContext.IsAdmin())
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            long[] operIdss = Tools.SpitLongArrary(operIds);
            return SUCCESS(sysOperLogService.DeleteOperLogByIds(operIdss));
        }

        /// <summary>
        /// 清空操作日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空操作日志", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "monitor:operlog:delete")]
        [HttpDelete("clean")]
        public IActionResult ClearOperLog()
        {
            if (!HttpContext.IsAdmin())
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, "操作失败");
            }
            sysOperLogService.CleanOperLog();

            return SUCCESS(1);
        }

        /// <summary>
        /// 导出操作日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "操作日志", BusinessType = BusinessType.EXPORT)]
        [ActionPermissionFilter(Permission = "monitor:operlog:export")]
        [HttpGet("export")]
        public IActionResult Export([FromQuery] OperLogQueryDto sysOperLog)
        {
            sysOperLog.PageSize = 100000;
            var list = sysOperLogService.SelectOperLogList(sysOperLog);
            var result = ExportExcelMini(list.Result, "操作日志", "操作日志");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}