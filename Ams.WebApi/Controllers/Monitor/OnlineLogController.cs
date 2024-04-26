namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 在线时长
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("monitor/online/log")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class OnlineLogController : BaseController
    {
        /// <summary>
        /// 在线时长接口
        /// </summary>
        private readonly IOnlineLogService _OnlineLogService;

        public OnlineLogController(IOnlineLogService OnlineLogService)
        {
            _OnlineLogService = OnlineLogService;
        }

        /// <summary>
        /// 查询在线时长列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult QueryOnlineLog([FromQuery] OnlineLogQueryDto parm)
        {
            var response = _OnlineLogService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除在线时长
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "monitor:onlinelog:delete")]
        [Log(Title = "在线时长", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteOnlineLog([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_OnlineLogService.Delete(idArr));
        }

        /// <summary>
        /// 导出在线时长
        /// </summary>
        /// <returns></returns>
        [Log(Title = "在线时长", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:onlinelog:export")]
        public IActionResult Export([FromQuery] OnlineLogQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _OnlineLogService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "在线时长", "在线时长");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}