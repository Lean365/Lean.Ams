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
        [HttpGet("EcCount")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:list")]
        public IActionResult QueryEcCount([FromQuery] PpEcSlaveQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）

            var response = _EcStatiService.GetEcCount(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月统计ec点数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlyEcCount")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:list")]
        public IActionResult QueryMonthlyEcCount([FromQuery] PpEcSlaveQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）

            var response = _EcStatiService.GetListMonthlyEc(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 当月,班组统计OPH Bar
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlyEcBar")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:list")]
        public IActionResult QueryMonthlyEcBar([FromQuery] PpEcSlaveQueryDto parm)
        {
            //DateTime nowDate = DateTime.Now;
            ////parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
            ////parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天

            //DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            //if (nowDate > Date10)
            //{
            //    parm.BeginMma009 = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
            //    parm.EndMma009 = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天
            //}
            //else
            //{
            //    parm.BeginMma009 = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1);//上月第一天
            //    parm.EndMma009 = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            //}

            var response = _EcStatiService.GetListMonthlyEcBar(parm);
            return SUCCESS(response);
        }
    }
}