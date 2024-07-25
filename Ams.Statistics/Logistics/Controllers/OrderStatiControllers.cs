using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Statistics.Logistics.Controllers
{
    /// <summary>
    /// 生产订单号码
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/order")]
    [ApiExplorerSettings(GroupName = "statistics")]
    public class OrderStatiControllers : BaseController
    {
        private readonly IOrderStatiService _OrderStatiService;

        /// <summary>
        /// 接口
        /// </summary>
        public OrderStatiControllers(IOrderStatiService OrderStatiService)
        {
            _OrderStatiService = OrderStatiService;
        }

        /// <summary>
        /// 按类型生成订单号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("NewOrderNumber")]
        [ActionPermissionFilter(Permission = "pp:order:add")]
        public IActionResult QueryNewOrderNumber([FromQuery] PpOrderQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）

            var response = _OrderStatiService.GetNewOrderNumber(parm);
            return SUCCESS(response);
        }
    }
}