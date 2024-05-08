using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 验证码记录
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("monitor/sms")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LogSmsController : BaseController
    {
        /// <summary>
        /// 验证码记录接口
        /// </summary>
        private readonly ILogSmsService _LogSmsService;

        public LogSmsController(ILogSmsService LogSmsService)
        {
            _LogSmsService = LogSmsService;
        }

        /// <summary>
        /// 查询验证码记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "monitor:sms:list")]
        public IActionResult QueryLogSms([FromQuery] LogSmsQueryDto parm)
        {
            var response = _LogSmsService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除验证码记录
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "monitor:sms:delete")]
        [Log(Title = "验证码记录", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteLogSms(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _LogSmsService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出验证码记录
        /// </summary>
        /// <returns></returns>
        [Log(Title = "验证码记录", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:sms:export")]
        public IActionResult Export([FromQuery] LogSmsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _LogSmsService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "验证码记录", "验证码记录");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}