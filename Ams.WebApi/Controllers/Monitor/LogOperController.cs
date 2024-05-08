using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 操作日志记录
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("/monitor/oper")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LogOperController : BaseController
    {
        private ILogOperService _LogOperService;

        public LogOperController(ILogOperService LogOperService)
        {
            this._LogOperService = LogOperService;
        }

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="LogOper"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult OperList([FromQuery] LogOperQueryDto LogOper)
        {
            LogOper.OperName = !HttpContext.IsAdmin() ? HttpContext.GetName() : LogOper.OperName;
            var list = _LogOperService.SelectOperLogList(LogOper);

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
            return SUCCESS(_LogOperService.DeleteOperLogByIds(operIdss));
        }

        /// <summary>
        /// 清空操作日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空操作日志", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "monitor:oper:clean")]
        [HttpDelete("clean")]
        public IActionResult ClearOperLog()
        {
            if (!HttpContext.IsAdmin())
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, "操作失败");
            }
            _LogOperService.CleanOperLog();

            return SUCCESS(1);
        }

        /// <summary>
        /// 导出操作日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "操作日志", BusinessType = BusinessType.EXPORT)]
        [ActionPermissionFilter(Permission = "monitor:oper:export")]
        [HttpGet("export")]
        public IActionResult Export([FromQuery] LogOperQueryDto LogOper)
        {
            LogOper.PageSize = 100000;
            var list = _LogOperService.SelectOperLogList(LogOper);
            var result = ExportExcelMini(list.Result, "操作日志", "操作日志");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}