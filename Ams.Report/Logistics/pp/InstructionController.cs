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
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics;
using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;

namespace Ams.Report.Logistics.pp
{
    /// <summary>
    /// 生产订单号码
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/order")]
    [ApiExplorerSettings(GroupName = "stat")]
    public class InstructionController : BaseController
    {

        private readonly IInstructionService _InstructionService;
        /// <summary>
        /// 接口
        /// </summary>
        public InstructionController(IInstructionService IInstructionService)
        {
            _InstructionService = IInstructionService;
        }
        /// <summary>
        /// 按类型生成订单号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("OrderNum")]
        [ActionPermissionFilter(Permission = "pp:order:list")]
        public IActionResult GetOrderNum([FromQuery] OrderQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）

            var response = _InstructionService.QueryOrderNum(parm);
            return SUCCESS(response);
        }
    }
}
