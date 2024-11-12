using Ams.Infrastructure.Enums;
using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Statistics.Logistics.Controllers
{
    /// <summary>
    /// 生产统计
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/poor/assy")]
    [ApiExplorerSettings(GroupName = "statistics")]
    public class AssyPoorStatiControllers : BaseController
    {
        private readonly IAssyPoorStatiService _IAsmPoorStatiService;

        /// <summary>
        /// OPH统计接口
        /// </summary>
        public AssyPoorStatiControllers(IAssyPoorStatiService AsmPoorStatiService)
        {
            _IAsmPoorStatiService = AsmPoorStatiService;
        }

        /// <summary>
        /// 本月组立不良台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlyPoorQty")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryMonthlyPoorQty([FromQuery] PpRepairAssyMaQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            //parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
            //parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天

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
            var response = _IAsmPoorStatiService.GetMonthlyPoorQty(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月统计组立不良报表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListMonthPoor")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryListMonthPoor([FromQuery] PpRepairAssyMaQueryDto parm)
        {
            var response = _IAsmPoorStatiService.GetListMonthPoor(parm);
            return SUCCESS(response);

            //PagedInfo<dynamic> pagedInfo = new()
            //{
            //    Result = _OutputStatiService.QueryCountMonthOutput(parm)
            //};

            ////return SUCCESS(pagedInfo, TIME_FORMAT_YYYMMDD);
            //return SUCCESS(new { pagedInfo }, TIME_FORMAT_YYYMMDD);
        }

        /// <summary>
        /// 导出月度组立不良报表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OPH月报", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("ExportListMonthPoor")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:export")]
        public IActionResult QueryExportListMonthPoor([FromQuery] PpRepairAssyMaQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _IAsmPoorStatiService.ExportListMonthPoor(parm);
            string sFileName = ExportExcel(list, "ExportMonthOutput", "OPH月报");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
            //string sFileName = ExportExcel(list, "Output", "OPH月报", "export/stat");
            //return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }

        /// <summary>
        /// 按月统计组立不良--柱状图
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListMonthlyPoorBar")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryListMonthlyPoorBar([FromQuery] PpRepairAssyMaQueryDto parm)
        {
            var response = _IAsmPoorStatiService.GetListMonthlyPoorBar(parm);
            return SUCCESS(response);
        }
    }
}