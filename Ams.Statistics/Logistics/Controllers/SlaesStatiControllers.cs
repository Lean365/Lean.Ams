using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Statistics.Logistics.Controllers
{
    /// <summary>
    /// 销售统计
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/sales")]
    [ApiExplorerSettings(GroupName = "statistics")]
    public class SlaesStatiControllers : BaseController
    {
        private readonly ISalesStatiService _SalesStatiService;

        /// <summary>
        /// OPH统计接口
        /// </summary>
        public SlaesStatiControllers(ISalesStatiService SalesStatiService)
        {
            _SalesStatiService = SalesStatiService;
        }

        /// <summary>
        /// 查询当月销售台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CurrentMonthSalesQty")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryCurrentMonthSalesQty([FromQuery] SdSellingInvoiceQueryDto parm)
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
            var response = _SalesStatiService.GetCurrentMonthSalesQty(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询当月生产金额
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CurrentMonthSalesAmount")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryCurrentMonthSalesAmount([FromQuery] SdSellingInvoiceQueryDto parm)
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
            var response = _SalesStatiService.GetCurrentMonthSalesAmount(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlySales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryMonthlySales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetMonthlySales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月,国家统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlyAreaSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryMonthlyAreaSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetMonthlyAreaSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月,仕向统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlyRegionSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryMonthlyRegionSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetMonthlyRegionSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("YearSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryYearSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetYearSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按年统计销售-国家
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("YearAreaSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryYearAreaSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetYearAreaSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按年统计销售-仕向
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("YearRegionSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryYearRegionSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetYearRegionSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月统计销售--柱状图
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListMonthlySalesBar")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryListMonthlySalesBar([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetListMonthlySalesBar(parm);
            return SUCCESS(response);
        }
    }
}