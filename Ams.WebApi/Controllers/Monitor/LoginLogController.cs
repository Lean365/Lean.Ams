using Ams.Model.Monitor.Dto;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 登录日志
    /// API控制器
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    [Verify]
    [Route("/monitor/login")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LoginLogController : BaseController
    {
        private ISysLoginService sysLoginService;

        public LoginLogController(ISysLoginService sysLoginService)
        {
            this.sysLoginService = sysLoginService;
        }

        /// <summary>
        /// 查询登录日志
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "monitor:login:list")]
        public IActionResult LoignLogList([FromQuery] LoginLogQueryDto param)
        {
            var list = sysLoginService.GetLoginLog(param);

            return SUCCESS(list);
        }

        /// <summary>
        /// 查询我的登录日志
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet("mylist")]
        public IActionResult QueryMyLoignLogList([FromQuery] LoginLogQueryDto param)
        {
            param.UserId = HttpContext.GetUId();
            var list = sysLoginService.GetLoginLog(param);

            return SUCCESS(list);
        }

        /// <summary>
        /// 清空登录日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空登录日志", BusinessType = BusinessType.EMPTY)]
        [ActionPermissionFilter(Permission = "monitor:login:empty")]
        [HttpDelete("clean")]
        public IActionResult CleanLoginInfo()
        {
            if (!HttpContext.IsAdmin())
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            sysLoginService.TruncateLogininfo();
            return SUCCESS(1);
        }

        /// <summary>
        /// </summary>
        /// <param name="infoIds"></param>
        /// <returns></returns>
        [Log(Title = "删除登录日志", BusinessType = BusinessType.DELETE)]
        [HttpDelete("{infoIds}")]
        [ActionPermissionFilter(Permission = "monitor:login:delete")]
        public IActionResult Remove(string infoIds)
        {
            if (!HttpContext.IsAdmin())
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            long[] infoIdss = Tools.SpitLongArrary(infoIds);
            return SUCCESS(sysLoginService.DeleteLogininforByIds(infoIdss));
        }

        /// <summary>
        /// 登录日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "登录日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:login:export")]
        public IActionResult Export([FromQuery] LoginLog logininfoDto)
        {
            logininfoDto.BeginTime = DateTimeHelper.GetBeginTime(logininfoDto.BeginTime, -1);
            logininfoDto.EndTime = DateTimeHelper.GetBeginTime(logininfoDto.EndTime, 1);
            var exp = Expressionable.Create<LoginLog>()
                .And(it => it.LoginTime >= logininfoDto.BeginTime && it.LoginTime <= logininfoDto.EndTime);

            var list = sysLoginService.Queryable().Where(exp.ToExpression())
                .ToList();

            string sFileName = ExportExcel(list, "loginlog", "登录日志");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

        /// <summary>
        /// 查询登录日志统计
        /// </summary>
        /// <returns></returns>
        [HttpGet("statiLoginLog")]
        [ActionPermissionFilter(Permission = "monitor:login:read")]
        public IActionResult QueryStatiLoginLog()
        {
            var list = sysLoginService.GetStatiLoginlog();
            var categories = list.Select(x => x.Date.ToString("dd日")).ToList();
            var numList = list.Select(x => x.Num).ToList();
            return SUCCESS(new { categories, numList });
        }
    }
}