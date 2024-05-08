using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 在线时长
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [ApiExplorerSettings(GroupName = "monitor")]
    [Route("monitor/onlinetime")]
    public class LogOnlineTimeController : BaseController
    {
        /// <summary>
        /// 在线时长接口
        /// </summary>
        private readonly ILogOnlineTimeService _LogOnlineTimeService;

        public LogOnlineTimeController(ILogOnlineTimeService LogOnlineTimeService)
        {
            _LogOnlineTimeService = LogOnlineTimeService;
        }

        /// <summary>
        /// 查询在线时长列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult QueryLogOnlineTime([FromQuery] LogOnlineTimeQueryDto parm)
        {
            var response = _LogOnlineTimeService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除在线时长
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "monitor:onlinetime:delete")]
        [Log(Title = "在线时长", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteLogOnlineTime([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_LogOnlineTimeService.Delete(idArr));
        }

        /// <summary>
        /// 导出在线时长
        /// </summary>
        /// <returns></returns>
        [Log(Title = "在线时长", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:onlinetime:export")]
        public IActionResult Export([FromQuery] LogOnlineTimeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _LogOnlineTimeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "在线时长", "在线时长");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}