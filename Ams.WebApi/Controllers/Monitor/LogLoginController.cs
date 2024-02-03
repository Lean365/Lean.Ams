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

            return SUCCESS(list, TIME_FORMAT_YYYMMDD);
        }

        /// <summary>
        /// 清空登录日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空登录日志", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "monitor:loglogin:truncate")]
        [HttpDelete("clean")]
        public IActionResult CleanLogList()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            LogLoginService.TruncateLogLogin();
            return SUCCESS(1);
        }

        /// <summary>
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [Log(Title = "删除登录日志", BusinessType = BusinessType.DELETE)]
        [HttpDelete("{infoIds}")]
        [ActionPermissionFilter(Permission = "monitor:loglogin:delete")]
        public IActionResult Remove(string ids)
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            long[] idArr = Tools.SpitLongArrary(ids);
            return SUCCESS(LogLoginService.DeleteLogLoginByIds(idArr));
        }

        /// <summary>
        /// 登录日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "登录日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:loglogin:export")]
        public IActionResult Export([FromQuery] LogLogin LogLoginDto)
        {
            LogLoginDto.BeginTime = DateTimeHelper.GetBeginTime(LogLoginDto.BeginTime, -1);
            LogLoginDto.EndTime = DateTimeHelper.GetBeginTime(LogLoginDto.EndTime, 1);
            var exp = Expressionable.Create<LogLogin>()
                .And(it => it.LoginTime >= LogLoginDto.BeginTime && it.LoginTime <= LogLoginDto.EndTime);

            var list = LogLoginService.Queryable().Where(exp.ToExpression())
                .ToList();

            string sFileName = ExportExcel(list, "LogLogin", "登录日志", "export/log");
            return SUCCESS(new { path = "/export/log/" + sFileName, fileName = sFileName });
        }

        /// <summary>
        /// 查询登录日志统计
        /// </summary>
        /// <returns></returns>
        [HttpGet("statiLogLogin")]
        [ActionPermissionFilter(Permission = "monitor:loglogin:list")]
        public IActionResult QueryStatiLogLogin()
        {
            var list = LogLoginService.GetStatiLogLogin();
            var categories = list.Select(x => x.Date.ToString("dd日")).ToList();
            var numList = list.Select(x => x.Num).ToList();
            return SUCCESS(new { categories, numList });
        }
    }
}
