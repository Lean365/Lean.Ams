using Ams.Model;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 系统访问记录
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("/monitor/login")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LogLoginController : BaseController
    {
        private ISysLoginService _SysLoginService;

        public LogLoginController(ISysLoginService SysLoginService)
        {
            this._SysLoginService = SysLoginService;
        }

        /// <summary>
        /// 查询登录日志
        /// </summary>
        /// <param name="SysLoginDto"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult LoignLogList([FromQuery] LogLogin SysLoginDto, [FromQuery] PagerInfo pagerInfo)
        {
            var list = _SysLoginService.GetLoginLog(SysLoginDto, pagerInfo);

            return SUCCESS(list);
        }

        /// <summary>
        /// 清空登录日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空登录日志", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "monitor:login:clean")]
        [HttpDelete("clean")]
        public IActionResult CleanLoginInfo()
        {
            if (!HttpContext.IsAdmin())
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            _SysLoginService.TruncateLogininfo();
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
            return SUCCESS(_SysLoginService.DeleteLogininforByIds(infoIdss));
        }

        /// <summary>
        /// 登录日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "登录日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:login:export")]
        public IActionResult Export([FromQuery] LogLogin logininfoDto)
        {
            logininfoDto.BeginTime = DateTimeHelper.GetBeginTime(logininfoDto.BeginTime, -1);
            logininfoDto.EndTime = DateTimeHelper.GetBeginTime(logininfoDto.EndTime, 1);
            var exp = Expressionable.Create<LogLogin>()
                .And(it => it.LoginTime >= logininfoDto.BeginTime && it.LoginTime <= logininfoDto.EndTime);

            var list = _SysLoginService.Queryable().Where(exp.ToExpression())
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
            var list = _SysLoginService.GetStatiLoginlog();
            var categories = list.Select(x => x.Date.ToString("dd日")).ToList();
            var numList = list.Select(x => x.Num).ToList();
            return SUCCESS(new { categories, numList });
        }
    }
}