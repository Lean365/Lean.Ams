using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Statistics.Logistics.Controllers
{
    /// <summary>
    /// 设变统计
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/ec")]
    [ApiExplorerSettings(GroupName = "statistics")]
    public class EcStatiControllers : BaseController
    {
        private readonly IEcStatiService _EcStatiService;

        /// <summary>
        /// ec点数统计接口
        /// </summary>
        public EcStatiControllers(IEcStatiService EcStatiService)
        {
            _EcStatiService = EcStatiService;
        }

        /// <summary>
        /// ec点数统计
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("totalStati")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:list")]
        public IActionResult QueryEcCount([FromQuery] PpEcSlaveQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）

            var response = _EcStatiService.GetEcCount(parm);
            return SUCCESS(response);
        }
    }
}