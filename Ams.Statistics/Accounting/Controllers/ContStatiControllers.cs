using Ams.Model.Accounting.Dto;
using Ams.Statistics.Accounting;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Statistics
{
    /// <summary>
    /// 月度存货
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/cost")]
    [ApiExplorerSettings(GroupName = "statistics")]
    public class ContStatiControllers : BaseController
    {
        private readonly IContStatiService _CostStatiService;

        /// <summary>
        /// 月度存货接口
        /// </summary>
        public ContStatiControllers(IContStatiService CostStatiService)
        {
            _CostStatiService = CostStatiService;
        }

        /// <summary>
        /// 查询月度成本
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlyProductionCost")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:list")]
        public IActionResult QueryMonthlyProductionCost([FromQuery] FicoBudgetActualContQueryDto parm)
        {
            //DateTime nowDate = DateTime.Now;
            ////parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
            ////parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天

            //DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            //if (nowDate > Date10)
            //{
            //    parm.BeginPomDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
            //    parm.EndPomDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天
            //}
            //else
            //{
            //    parm.BeginPomDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1);//上月第一天
            //    parm.EndPomDate = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            //}
            var response = _CostStatiService.GetMonthlyProductionCost(parm);
            return SUCCESS(response);
        }
    }
}