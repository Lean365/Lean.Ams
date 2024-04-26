namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 操作日志
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("monitor/operlog")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class OperLogController : BaseController
    {
        private IOperLogService OperLogService;

        public OperLogController(IOperLogService OperLogService)
        {
            this.OperLogService = OperLogService;
        }

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="OperLog"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult OperList([FromQuery] OperLogQueryDto OperLog)
        {
            OperLog.OperName = !HttpContextExtension.IsAdmin(HttpContext) ? HttpContextExtension.GetName(HttpContext) : OperLog.OperName;
            var list = OperLogService.SelectOperLogList(OperLog);

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
            return SUCCESS(OperLogService.DeleteOperLogByIds(operIdss));
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
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, "操作失败");
            }
            OperLogService.CleanOperLog();

            return SUCCESS(1);
        }

        /// <summary>
        /// 导出操作日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "操作日志", BusinessType = BusinessType.EXPORT)]
        [ActionPermissionFilter(Permission = "monitor:operlog:export")]
        [HttpGet("export")]
        public IActionResult Export([FromQuery] OperLogQueryDto OperLog)
        {
            OperLog.PageSize = 100000;
            var list = OperLogService.SelectOperLogList(OperLog);
            var result = ExportExcelMini(list.Result, "操作日志", "操作日志");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}