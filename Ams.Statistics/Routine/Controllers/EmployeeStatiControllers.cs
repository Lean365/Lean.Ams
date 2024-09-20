using Ams.Model.Routine.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Statistics.Routine
{
    /// <summary>
    /// 工号
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/employee")]
    [ApiExplorerSettings(GroupName = "statistics")]
    public class EmployeeStatiControllers : BaseController
    {
        private readonly IEmployeeStatiService _EmployeeStatiService;

        /// <summary>
        /// 工号接口
        /// </summary>
        public EmployeeStatiControllers(IEmployeeStatiService EmployeeStatiService)
        {
            _EmployeeStatiService = EmployeeStatiService;
        }

        /// <summary>
        /// 按性别生成工号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MaxWorkNumber")]
        [ActionPermissionFilter(Permission = "routine:ehremployee:add")]
        public IActionResult QueryMaxWorkNumber([FromQuery] RoutineEhrEmployeeQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）

            var response = _EmployeeStatiService.GetMaxWorkNumber(parm);
            return SUCCESS(response);
        }
    }
}