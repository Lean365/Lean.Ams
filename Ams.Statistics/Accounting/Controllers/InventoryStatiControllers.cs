﻿using Ams.Model.Accounting.Dto;
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
    [Route("stat/inventory")]
    [ApiExplorerSettings(GroupName = "statistics")]
    public class InventoryStatiControllers(IInventoryStatiService InventoryStatiService) : BaseController
    {
        /// <summary>
        /// 月度存货接口
        /// </summary>
        private readonly IInventoryStatiService _InventoryStatiService = InventoryStatiService;

        /// <summary>
        /// 查询月度存货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MonthlyInventoryAmount")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:list")]
        public IActionResult QueryMonthlyInventoryAmount([FromQuery] FicoMonthlyInventoryQueryDto parm)
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
            var response = _InventoryStatiService.GetMonthlyInventoryAmount(parm);
            return SUCCESS(response);
        }
    }
}