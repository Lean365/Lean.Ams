using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Ams.WebApi.Extensions;
using Ams.Kernel.Filters;
using Ams.Model;
using Ams.Infrastructure.Helper;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Model.Monitor;
using Ams.Kernel.Services.IService.Monitor;
namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 访问记录
    /// API控制器
    /// @Author: (Lean365:Davis.Cheng)
    /// @Date: (2023-12-15)
    /// </summary>
    [Verify]
    [Route("/monitor/loglogin")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LogLoginController : BaseController
    {
        private ILogLoginService LogLoginService;

        public LogLoginController(ILogLoginService LogLoginService)
        {
            this.LogLoginService = LogLoginService;
        }

        /// <summary>
        /// 查询登录日志
        /// </summary>
        /// <param name="LogLoginDto"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult LoignLogList([FromQuery] LogLogin LogLoginDto, [FromQuery] PagerInfo pagerInfo)
        {
            var list = LogLoginService.GetLoginLog(LogLoginDto, pagerInfo);

            return SUCCESS(list);
        }

        /// <summary>
        /// 清空登录日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空登录日志", BusinessType= BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "monitor:loglogin:truncate")]
        [HttpDelete("clean")]
        public IActionResult CleanLoginInfo()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            LogLoginService.TruncateLogininfo();
            return SUCCESS(1);
        }

        /// <summary>
        /// </summary>
        /// <param name="infoIds"></param>
        /// <returns></returns>
        [Log(Title = "删除登录日志", BusinessType = BusinessType.DELETE)]
        [HttpDelete("{infoIds}")]
        [ActionPermissionFilter(Permission = "monitor:loglogin:delete")]
        public IActionResult Remove(string infoIds)
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            long[] infoIdss = Tools.SpitLongArrary(infoIds);
            return SUCCESS(LogLoginService.DeletelogloginByIds(infoIdss));
        }

        /// <summary>
        /// 登录日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "登录日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:loglogin:export")]
        public IActionResult Export([FromQuery] LogLogin logininfoDto)
        {
            logininfoDto.BeginTime = DateTimeHelper.GetBeginTime(logininfoDto.BeginTime, -1);
            logininfoDto.EndTime = DateTimeHelper.GetBeginTime(logininfoDto.EndTime, 1);
            var exp = Expressionable.Create<LogLogin>()
                .And(it => it.LoginTime >= logininfoDto.BeginTime && it.LoginTime <= logininfoDto.EndTime);

            var list = LogLoginService.Queryable().Where(exp.ToExpression())
                .ToList();

            string sFileName = ExportExcel(list, "loginlog", "登录日志");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }
    }
}
