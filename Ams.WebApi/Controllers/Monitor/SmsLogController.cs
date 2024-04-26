namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 短信验证
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("monitor/smslog")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class SmsLogController : BaseController
    {
        /// <summary>
        /// 短信验证记录接口
        /// </summary>
        private readonly ISmsLogService _SmsLogService;

        public SmsLogController(ISmsLogService SmsLogService)
        {
            _SmsLogService = SmsLogService;
        }

        /// <summary>
        /// 查询短信验证记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "monitor:smslog:list")]
        public IActionResult QuerySmsLog([FromQuery] SmsLogQueryDto parm)
        {
            var response = _SmsLogService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除短信验证记录
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "monitor:smslog:delete")]
        [Log(Title = "短信验证记录", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSmsLog(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SmsLogService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出短信验证记录
        /// </summary>
        /// <returns></returns>
        [Log(Title = "短信验证记录", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:smslog:export")]
        public IActionResult Export([FromQuery] SmsLogQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SmsLogService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "短信验证记录", "短信验证记录");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}