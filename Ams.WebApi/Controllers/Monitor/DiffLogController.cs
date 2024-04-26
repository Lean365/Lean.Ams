namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 审计日志
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("monitor/difflog")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class DiffLogController : BaseController
    {
        /// <summary>
        /// 审计日志接口
        /// </summary>
        private readonly IDiffLogService _DiffLogService;

        public DiffLogController(IDiffLogService DiffLogService)
        {
            _DiffLogService = DiffLogService;
        }

        /// <summary>
        /// 查询审计日志列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "monitor:difflog:list")]
        public IActionResult QueryDiffLog([FromQuery] DiffLogQueryDto parm)
        {
            var response = _DiffLogService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除审计日志
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "monitor:difflog:delete")]
        [Log(Title = "审计日志", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteDiffLog(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _DiffLogService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出审计日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "审计日志", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:difflog:export")]
        public IActionResult Export([FromQuery] DiffLogQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _DiffLogService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "审计日志", "审计日志");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}