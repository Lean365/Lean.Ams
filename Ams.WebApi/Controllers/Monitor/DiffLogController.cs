namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 审计日志
    /// </summary>
    [Verify]
    [Route("monitor/diff")]
    [ApiExplorerSettings(GroupName = "system")]
    public class DiffLogController : BaseController
    {
        /// <summary>
        /// 审计日志接口
        /// </summary>
        private readonly IDiffLogService _SqlDiffLogService;

        public DiffLogController(IDiffLogService SqlDiffLogService)
        {
            _SqlDiffLogService = SqlDiffLogService;
        }

        /// <summary>
        /// 查询审计日志列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "monitor:diff:list")]
        public IActionResult QuerySqlDiffLog([FromQuery] DiffLogQueryDto parm)
        {
            var response = _SqlDiffLogService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除审计日志
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "monitor:diff:delete")]
        [Log(Title = "审计日志", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSqlDiffLog(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SqlDiffLogService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出审计日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "审计日志", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:diff:export")]
        public IActionResult Export([FromQuery] DiffLogQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SqlDiffLogService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "审计日志", "审计日志");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}