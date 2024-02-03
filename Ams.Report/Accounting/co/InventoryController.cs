using Ams.Infrastructure.Controllers;
using Ams.Kernel.Filters;
using Ams.Model.Dto;
using Ams.Report.Logistics.mm;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Report.Accounting.co
{
    /// <summary>
    /// 物料号码
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/fico")]
    [ApiExplorerSettings(GroupName = "stat")]
    public class InventoryController  : BaseController
    {
        private readonly IInventoryService _IInventoryService;
        /// <summary>
        /// 物料号码接口
        /// </summary>
        public InventoryController(IInventoryService IInventoryService)
        {
            _IInventoryService = IInventoryService;
        }
        /// <summary>
        /// 上月库存
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("QueryInventoryAmount")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:list")]
        public IActionResult GetQueryInventoryAmount([FromQuery] MonthlyInventoryQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            //parm.BeginPomMfgDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天 
            //parm.EndPomMfgDate= nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天 

            //只显示上月库存
            parm.MiYm = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1).ToString("yyyyMM");//上月第一天
            //DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            //if (nowDate > Date10)
            //{
            //    parm.MiYm = new DateTime(nowDate.Year, nowDate.Month, 1).ToString("yyyyMM");   //本月第一天 
            //    //parm.EndPomMfgDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天 

            //}
            //else
            //{
            //    parm.MiYm = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1).ToString("yyyyMM");//上月第一天
            //    //parm.EndPomMfgDate = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            //}
            var response = _IInventoryService.QueryInventoryAmount(parm);
            return SUCCESS(response);
        }
    }
}
