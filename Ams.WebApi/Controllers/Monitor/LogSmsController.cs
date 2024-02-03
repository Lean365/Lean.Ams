using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Filters;
using Ams.Infrastructure.CustomException;
using Ams.Kernel.Model.Dto.Monitor;
using Ams.Kernel.Services.IService.Monitor;
//创建时间：2023-11-19
namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 短信记录
    /// API控制器
    /// @Author: (Lean365:Davis.Cheng)
    /// @Date: (2023-12-15)
    /// </summary>
    [Verify]
    [Route("monitor/logsms")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LogSmsController : BaseController
    {
        /// <summary>
        /// 短信验证码记录接口
        /// </summary>
        private readonly ILogSmsService _LogSmsService;

        public LogSmsController(ILogSmsService LogSmsService)
        {
            _LogSmsService = LogSmsService;
        }

        /// <summary>
        /// 查询短信验证码记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "monitor:logsms:list")]
        public IActionResult QueryLogSms([FromQuery] LogSmsQueryDto parm)
        {
            var response = _LogSmsService.GetList(parm);
            return SUCCESS(response, TIME_FORMAT_YYYMMDD);
        }

        /// <summary>
        /// 删除短信验证码记录
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "monitor:logsms:delete")]
        [Log(Title = "短信验证码记录", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteLogSms(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _LogSmsService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出短信验证码记录
        /// </summary>
        /// <returns></returns>
        [Log(Title = "短信验证码记录", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:logsms:export")]
        public IActionResult Export([FromQuery] LogSmsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _LogSmsService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "短信验证码记录", "短信验证码记录", "/export/log/");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}