using Ams.Infrastructure.Controllers;
using Ams.Kernel.Filters;
using Ams.Model.Dto;
using Ams.Report.Logistics.pp;
using Microsoft.AspNetCore.Mvc;
namespace Ams.Report.Logistics.sd
{
    /// <summary>
    /// 生产统计
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/sales")]
    [ApiExplorerSettings(GroupName = "stat")]
    public class SalesStatsController : BaseController
    {

        private readonly ISalesStatsService _ISalesStatsService;
        /// <summary>
        /// OPH统计接口
        /// </summary>
        public SalesStatsController(ISalesStatsService ISalesStatsService)
        {
            _ISalesStatsService = ISalesStatsService;
        }
        /// <summary>
        /// 查询本月销售台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CurrentMonthlySales")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:list")]
        public IActionResult GetCurrentMonthlySales([FromQuery] SalesInvoiceQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            //parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天 
            //parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天 


            DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            if (nowDate > Date10)
            {
                parm.SsiYm = new DateTime(nowDate.Year, nowDate.Month, 1).ToString("yyyyMM");   //本月第一天 
                //parm.EndPomMfgDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天 

            }
            else
            {
                parm.SsiYm = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1).ToString("yyyyMM");//上月第一天
                //parm.EndPomMfgDate = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            }
            var response = _ISalesStatsService.QueryCurrentMonthlySales(parm);
            return SUCCESS(response);
        }
    }

}
