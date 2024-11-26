using Ams.Model.Accounting.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Statistics.Accounting.Controllers
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
    public class ExpenseStatiControllers(IExpenseStatiService ExpenseStatiService) : BaseController
    {
        /// <summary>
        /// 费用比较接口
        /// </summary>
        private readonly IExpenseStatiService _ExpenseStatiService = ExpenseStatiService;

        //public ExpenseStatiControllers(IExpenseStatiService ExpenseStatiService)
        //{
        //    _ExpenseStatiService = ExpenseStatiService;
        //}

        /// <summary>
        /// 查询月度成本
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("monthlyProd")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:list")]
        public IActionResult QueryMonthlyProductionCost([FromQuery] FicoBudgetActualContQueryDto parm)
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
            var response = _ExpenseStatiService.GetMonthlyProductionCost(parm);
            return SUCCESS(response);
        }
    }
}