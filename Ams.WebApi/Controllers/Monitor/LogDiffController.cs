using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Filters;
using Ams.Infrastructure.CustomException;
using Ams.Kernel.Model.Dto.Monitor;
using Ams.Kernel.Services.IService.Monitor;

//创建时间：2023-08-17
namespace Ams.WebApi.Controllers.Monitor
{
    /// <summary>
    /// 审计日志
    /// API控制器
    /// @Author: (Lean365:Davis.Cheng)
    /// @Date: (2023-12-15)
    /// </summary>
    [Verify]
    [Route("monitor/logdiff")]
    [ApiExplorerSettings(GroupName = "monitor")]
    public class LogDiffController : BaseController
    {
        /// <summary>
        /// 审计日志接口
        /// </summary>
        private readonly ILogDiffService _LogDiffService;

        public LogDiffController(ILogDiffService LogDiffService)
        {
            _LogDiffService = LogDiffService;
        }

        /// <summary>
        /// 查询审计日志列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "monitor:logdiff:list")]
        public IActionResult QueryLogDiff([FromQuery] LogDiffQueryDto parm)
        {
            var response = _LogDiffService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除审计日志
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "monitor:logdiff:delete")]
        [Log(Title = "审计日志", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteLogDiff(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _LogDiffService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出审计日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "审计日志", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:logdiff:export")]
        public IActionResult Export([FromQuery] LogDiffQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _LogDiffService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "审计日志", "审计日志");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}