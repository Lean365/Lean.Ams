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
    [Route("stat/output")]
    [ApiExplorerSettings(GroupName = "statistics")]
    public class OutputStatiControllers : BaseController
    {
        private readonly IOutputStatiService _OutputStatiService;

        /// <summary>
        /// OPH统计接口
        /// </summary>
        public OutputStatiControllers(IOutputStatiService OutputStatiService)
        {
            _OutputStatiService = OutputStatiService;
        }

        /// <summary>
        /// 查询最大ID
        /// </summary>
        ///
        /// <returns></returns>
        [HttpGet("MaxSfId")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult GetMaxSfId()
        {
            var response = _OutputStatiService.GetMaxSfId();
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询当月生产台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlyOutputQty")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryMonthlyOutputQty([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            //parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
            //parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天

            DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            if (nowDate > Date10)
            {
                parm.BeginMma009 = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
                parm.EndMma009 = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天
            }
            else
            {
                parm.BeginMma009 = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1);//上月第一天
                parm.EndMma009 = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            }
            var response = _OutputStatiService.GetMonthlyOutputQty(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListMonthOutput")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryListMonthOutput([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            var response = _OutputStatiService.GetListMonthOutput(parm);
            return SUCCESS(response);

            //PagedInfo<dynamic> pagedInfo = new()
            //{
            //    Result = _OutputStatiService.QueryCountMonthOutput(parm)
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
        [ActionPermissionFilter(Permission = "pp:outputmaster:export")]
        public IActionResult ExportMonthOutput([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _OutputStatiService.ExportListMonthOutput(parm);
            string sFileName = ExportExcel(list, "ExportMonthOutput", "OPH月报");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
            //string sFileName = ExportExcel(list, "Output", "OPH月报", "export/stat");
            //return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }

        /// <summary>
        /// 按月,班组统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListMonthLineOutput")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryListMonthLineOutput([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            var response = _OutputStatiService.GetListMonthLineOutput(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月,班组统计OPH Bar
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListMonthLineOutputBar")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryListMonthLineOutputBar([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            var response = _OutputStatiService.GetListMonthLineOutputBar(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 当月,班组统计OPH Bar
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListCurrentMonthLineOutputBar")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryListCurrentMonthLineOutputBar([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            //parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
            //parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天

            DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            if (nowDate > Date10)
            {
                parm.BeginMma009 = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
                parm.EndMma009 = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天
            }
            else
            {
                parm.BeginMma009 = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1);//上月第一天
                parm.EndMma009 = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            }

            var response = _OutputStatiService.GetListCurrentMonthLineOutputBar(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月班组统计OPH导出
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OPH月报", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("ExportMonthLineOutputList")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:export")]
        public IActionResult ExportMonthLineOutput([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _OutputStatiService.ExportListMonthLineOutput(parm);
            string sFileName = ExportExcel(list, "ExportMonthLineOutput", "OPH月报-班组");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
            //string sFileName = ExportExcel(list, "Output", "OPH月报-班组", "export/stat");
            //return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }

        /// <summary>
        /// 按月，机种统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("ListMonthModelOutput")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryListMonthModelOutput([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            var response = _OutputStatiService.GetListMonthModelOutput(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 按月机种统计OPH导出
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OPH月报", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("ExportMonthModelOutputList")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:export")]
        public IActionResult ExportMonthModelOutput([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _OutputStatiService.ExportListMonthModelOutput(parm);
            string sFileName = ExportExcel(list, "ExportMonthModelOutput", "OPH月报-机种");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
            //string sFileName = ExportExcel(list, "Output", "OPH月报-机种", "export/stat");
            //return SUCCESS(new { path = "/export/stat/" + sFileName, fileName = sFileName });
        }
    }
}