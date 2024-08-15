using Ams.Model.Monitor.Dto;
using Ams.Service.Monitor.IMonitorService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 短信验证码
    /// API控制器
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    [Verify]
    [Route("monitor/sms")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class SmsLogController : BaseController
    {
        /// <summary>
        /// 短信验证码记录接口
        /// </summary>
        private readonly ISmsLogService _SmscodeLogService;

        public SmsLogController(ISmsLogService SmscodeLogService)
        {
            _SmscodeLogService = SmscodeLogService;
        }

        /// <summary>
        /// 查询短信验证码记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "monitor:sms:list")]
        public IActionResult QuerySmscodeLog([FromQuery] SmsLogQueryDto parm)
        {
            var response = _SmscodeLogService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除短信验证码记录
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "monitor:sms:delete")]
        [Log(Title = "短信验证码记录", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSmscodeLog(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SmscodeLogService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出短信验证码记录
        /// </summary>
        /// <returns></returns>
        [Log(Title = "短信验证码记录", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:sms:export")]
        public IActionResult Export([FromQuery] SmsLogQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SmscodeLogService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "短信验证码记录", "短信验证码记录");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}