namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 登录日志
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("monitor/loginlog")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LoginLogController : BaseController
    {
        private ILoginLogService LoginLogService;

        public LoginLogController(ILoginLogService LoginLogService)
        {
            this.LoginLogService = LoginLogService;
        }

        /// <summary>
        /// 查询登录日志
        /// </summary>
        /// <param name="LoginLogDto"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult LoignLogList([FromQuery] LoginLog LoginLogDto, [FromQuery] PagerInfo pagerInfo)
        {
            var list = LoginLogService.GetLoginLog(LoginLogDto, pagerInfo);

            return SUCCESS(list);
        }

        /// <summary>
        /// 清空登录日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空登录日志", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "monitor:loginlog:clean")]
        [HttpDelete("clean")]
        public IActionResult CleanLoginInfo()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            LoginLogService.TruncateLogininfo();
            return SUCCESS(1);
        }

        /// <summary>
        /// </summary>
        /// <param name="infoIds"></param>
        /// <returns></returns>
        [Log(Title = "删除登录日志", BusinessType = BusinessType.DELETE)]
        [HttpDelete("{infoIds}")]
        [ActionPermissionFilter(Permission = "monitor:loginlog:delete")]
        public IActionResult Remove(string infoIds)
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            long[] infoIdss = Tools.SpitLongArrary(infoIds);
            return SUCCESS(LoginLogService.DeleteloginlogByIds(infoIdss));
        }

        /// <summary>
        /// 登录日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "登录日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:loginlog:export")]
        public IActionResult Export([FromQuery] LoginLog logininfoDto)
        {
            logininfoDto.BeginTime = DateTimeHelper.GetBeginTime(logininfoDto.BeginTime, -1);
            logininfoDto.EndTime = DateTimeHelper.GetBeginTime(logininfoDto.EndTime, 1);
            var exp = Expressionable.Create<LoginLog>()
                .And(it => it.LoginTime >= logininfoDto.BeginTime && it.LoginTime <= logininfoDto.EndTime);

            var list = LoginLogService.Queryable().Where(exp.ToExpression())
                .ToList();

            string sFileName = ExportExcel(list, "loginlog", "登录日志");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

        /// <summary>
        /// 查询登录日志统计
        /// </summary>
        /// <returns></returns>
        [HttpGet("statiLoginLog")]
        [ActionPermissionFilter(Permission = "common")]
        public IActionResult QueryStatiLoginLog()
        {
            var list = LoginLogService.GetStatiLoginlog();
            var categories = list.Select(x => x.Date.ToString("dd日")).ToList();
            var numList = list.Select(x => x.Num).ToList();
            return SUCCESS(new { categories, numList });
        }
    }
}