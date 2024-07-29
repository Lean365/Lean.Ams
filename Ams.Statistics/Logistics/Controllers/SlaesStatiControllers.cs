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
        /// 查询当月生产台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlySalesQty")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryMonthlySalesQty([FromQuery] SdSellingInvoiceQueryDto parm)
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
            var response = _SalesStatiService.GetMonthlySalesQty(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询当月生产台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlySalesAmount")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryMonthlySalesAmount([FromQuery] SdSellingInvoiceQueryDto parm)
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
            var response = _SalesStatiService.GetMonthlySalesAmount(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListMonthSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryListMonthSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetListMonthSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月,国家统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListMonthAreaSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryListMonthAreaSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetListMonthAreaSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月,仕向统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthRegionSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthRegionSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetListMonthRegionSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListYearSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryListYearSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetListYearSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListYearAreaSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryListYearAreaSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetListYearAreaSales(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListYearRegionSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryListYearRegionSales([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SalesStatiService.GetListYearRegionSales(parm);
            return SUCCESS(response);
        }
    }
}