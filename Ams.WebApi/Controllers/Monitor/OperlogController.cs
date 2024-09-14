namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 操作日志记录
    /// </summary>
    [Verify]
    [Route("/monitor/oper")]
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
            OperLog.OperName = !HttpContext.IsAdmin() ? HttpContext.GetName() : OperLog.OperName;
            var list = OperLogService.SelectOperLogList(OperLog);

            return SUCCESS(list);
        }

        /// <summary>
        /// 删除操作日志
        /// </summary>
        /// <param name="operIds"></param>
        /// <returns></returns>
        [Log(Title = "操作日志", BusinessType = BusinessType.DELETE)]
        [ActionPermissionFilter(Permission = "monitor:oper:delete")]
        [HttpDelete("{operIds}")]
        public IActionResult Remove(string operIds)
        {
            if (!HttpContext.IsAdmin())
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
        [Log(Title = "清空操作日志", BusinessType = BusinessType.EMPTY)]
        [ActionPermissionFilter(Permission = "monitor:oper:empty")]
        [HttpDelete("clean")]
        public IActionResult ClearOperLog()
        {
            if (!HttpContext.IsAdmin())
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
        [ActionPermissionFilter(Permission = "monitor:oper:export")]
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