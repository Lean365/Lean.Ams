using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics;
using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;
using System.Linq;
using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using MiniExcelLibs;
using Ams.Kernel;
using Ams.Infrastructure.Controllers;
using SqlSugar;
using Ams.Service.Logistics;
using Ams.Infrastructure.Enums;
using Ams.Kernel.Model.Dto.System;
using Ams.Kernel.Signalr;
using System;
namespace Ams.Report.Logistics.pp
{
    /// <summary>
    /// 生产统计
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/output")]
    [ApiExplorerSettings(GroupName = "stat")]
    public class ProductionStatsController : BaseController
    {

        private readonly IProductionStatsService _ProductionStatsService;
        /// <summary>
        /// OPH统计接口
        /// </summary>
        public ProductionStatsController(IProductionStatsService ProductionStatsService)
        {
            _ProductionStatsService = ProductionStatsService;
        }
        /// <summary>
        /// 查询最大ID
        /// </summary>
        /// 
        /// <returns></returns>
        [HttpGet("MaxSfid")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult GetMaxSfid()
        {
            var response = _ProductionStatsService.QueryMaxSfid();
            return SUCCESS(response);
        }
        /// <summary>
        /// 查询当月生产台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlyProductionQty")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult GetMonthlyProductionQty([FromQuery] OutputMasterQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            //parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天 
            //parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天 


            DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            if (nowDate > Date10)
            {
                parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天 
                parm.EndPomMfgDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天 

            }
            else
            {
                parm.BeginPomMfgDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1);//上月第一天
                parm.EndPomMfgDate = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            }
            var response = _ProductionStatsService.QueryMonthlyProductionQty(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthOutput")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthOutput([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthOutput(parm);
            return SUCCESS(response);

            //PagedInfo<dynamic> pagedInfo = new()
            //{
            //    Result = _ProductionStatsService.QueryCountMonthOutput(parm)
            //};

            ////return SUCCESS(pagedInfo, TIME_FORMAT_YYYMMDD);
            //return SUCCESS(new { pagedInfo }, TIME_FORMAT_YYYMMDD);

        }


        /// <summary>
        /// 按月统计OPH导出
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OPH月报", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("ExportMonthOutput")]
        [ActionPermissionFilter(Permission = "system:lang:export")]
        public IActionResult ExportMonthOutput([FromQuery] OutputMasterQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _ProductionStatsService.ExportMonthOutputList(parm);

            string sFileName = ExportExcel(list, "Output", "OPH月报", "export/stat");
            return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }
        /// <summary>
        /// 按月,班组统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthLineOutput")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthLineOutput([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthLineOutput(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月,班组统计OPH Bar
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthLineOutputBar")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthLineOutputBar([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthLineOutputBar(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 当月,班组统计OPH Bar
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountCurrentMonthOutputBar")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountCurrentMonthOutputBar([FromQuery] OutputMasterQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            //parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天 
            //parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天 


            DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            if(nowDate>Date10)
            {
                parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天 
                parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天 

            }
            else
            {
                parm.BeginPomMfgDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1);//上月第一天
                parm.EndPomMfgDate = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            }

            var response = _ProductionStatsService.QueryCountCurrentMonthOutputBar(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月班组统计OPH导出
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OPH月报", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("ExportMonthLineOutputList")]
        [ActionPermissionFilter(Permission = "system:lang:export")]
        public IActionResult ExportMonthLineOutput([FromQuery] OutputMasterQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _ProductionStatsService.ExportMonthLineOutputList(parm);

            string sFileName = ExportExcel(list, "Output", "OPH月报-班组", "export/stat");
            return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }
        /// <summary>
        /// 按月，机种统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthModelOutput")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthModelOutput([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthModelOutput(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月机种统计OPH导出
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OPH月报", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("ExportMonthModelOutputList")]
        [ActionPermissionFilter(Permission = "system:lang:export")]
        public IActionResult ExportMonthModelOutput([FromQuery] OutputMasterQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _ProductionStatsService.ExportMonthModelOutputList(parm);

            string sFileName = ExportExcel(list, "Output", "OPH月报-机种", "export/stat");
            return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }
        /// <summary>
        /// 按月统计EC
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthEc")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthEc([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthEc(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月统计OPH不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthDefective")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryCountMonthDefective([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthOutput(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月统计OPH工数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthLaborhours")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthLaborhours([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthLaborhours(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月统计IQC进货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthIncoming")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthIncoming([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthIncoming(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月统计QA出货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthOutgoing")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryCountMonthOutgoing([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthOutgoing(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult QueryCountMonthSales([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthOutput(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月,国家统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthAreaSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthAreaSales([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthAreaSales(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月,仕向统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountMonthRegionSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountMonthRegionSales([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountMonthRegionSales(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearOutput")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearOutput([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearOutput(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按月统计OPH导出
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OPH月报", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("ExportYearOutput")]
        [ActionPermissionFilter(Permission = "system:lang:export")]
        public IActionResult ExportYearOutput([FromQuery] OutputMasterQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _ProductionStatsService.ExportYearOutputList(parm);

            string sFileName = ExportExcel(list, "Output", "OPH月报", "export/stat");
            return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }
        /// <summary>
        /// 按年，班组统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearLineOutput")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearLineOutput([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearLineOutput(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年班组统计OPH导出
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OPH月报", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("ExportYearLineOutput")]
        [ActionPermissionFilter(Permission = "system:lang:export")]
        public IActionResult ExportYearLineOutput([FromQuery] OutputMasterQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _ProductionStatsService.ExportYearLineOutputList(parm);

            string sFileName = ExportExcel(list, "Output", "OPH月报", "export/stat");
            return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }
        /// <summary>
        /// 按年统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearModelOutput")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearModelOutput([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearModelOutput(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年班组统计OPH导出
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OPH月报", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("ExportYearModelOutput")]
        [ActionPermissionFilter(Permission = "system:lang:export")]
        public IActionResult ExportYearModelOutput([FromQuery] OutputMasterQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _ProductionStatsService.ExportYearModelOutputList(parm);

            string sFileName = ExportExcel(list, "Output", "OPH月报", "export/stat");
            return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }
        /// <summary>
        /// 按年统计EC
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearEc")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearEc([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearEc(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年统计不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearDefective")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearDefective([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearDefective(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年统计不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearLaborhours")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearLaborhours([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearLaborhours(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年统计IQC进货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearIncoming")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearIncoming([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearIncoming(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年统计QA出货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearOutgoing")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearOutgoing([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearOutgoing(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearSales([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearSales(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearAreaSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearAreaSales([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearAreaSales(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("CountYearRegionSales")]
        [ActionPermissionFilter(Permission = "pp:statistics:list")]
        public IActionResult GetCountYearRegionSales([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _ProductionStatsService.QueryCountYearRegionSales(parm);
            return SUCCESS(response);
        }
    }
}
