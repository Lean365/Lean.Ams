using Ams.Model.Monitor.Dto;
using Ams.Service.Monitor.IMonitorService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 在线时长
    /// API控制器
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    [Verify]
    [ApiExplorerSettings(GroupName = "monitor")]
    [Route("monitor/duration")]
    public class DurationLogController : BaseController
    {
        /// <summary>
        /// 用户在线时长接口
        /// </summary>
        private readonly IDurationLogService _UserOnlineLogService;

        public DurationLogController(IDurationLogService UserOnlineLogService)
        {
            _UserOnlineLogService = UserOnlineLogService;
        }

        /// <summary>
        /// 查询用户在线时长列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult QueryUserOnlineLog([FromQuery] DurationLogQueryDto parm)
        {
            var response = _UserOnlineLogService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除用户在线时长
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "monitor:duration:delete")]
        [Log(Title = "用户在线时长", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteUserOnlineLog([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_UserOnlineLogService.Delete(idArr));
        }

        /// <summary>
        /// 导出用户在线时长
        /// </summary>
        /// <returns></returns>
        [Log(Title = "用户在线时长", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:duration:export")]
        public IActionResult Export([FromQuery] DurationLogQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _UserOnlineLogService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "用户在线时长", "用户在线时长");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}