using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 生产工单
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 9:49:40)
    /// </summary>
    [Verify]
    [Route("logistics/Order")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class OrderController : BaseController
    {
        /// <summary>
        /// 生产工单接口
        /// </summary>
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:order:list")]
        public IActionResult QueryOrder([FromQuery] OrderQueryDto parm)
        {
            var response = _OrderService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询生产工单详情
        /// </summary>
        /// <param name="MoSFID"></param>
        /// <returns></returns>
        [HttpGet("{MoSFID}")]
        [ActionPermissionFilter(Permission = "pp:order:query")]
        public IActionResult GetOrder(long MoSFID)
        {
            var response = _OrderService.GetInfo(MoSFID);
            
            var info = response.Adapt<OrderDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:order:add")]
        [Log(Title = "生产工单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddOrder([FromBody] OrderDto parm)
        {
            var modal = parm.Adapt<Order>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_OrderService.CheckEntryUnique(parm.MoOrderNo.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)生产工单 '{parm.MoOrderNo}'失败(failed)，输入的(The entered)生产工单已存在(already exists)"));
            }
            var response = _OrderService.AddOrder(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:order:edit")]
        [Log(Title = "生产工单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateOrder([FromBody] OrderDto parm)
        {
            var modal = parm.Adapt<Order>().ToUpdate(HttpContext);
            var response = _OrderService.UpdateOrder(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产工单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:order:delete")]
        [Log(Title = "生产工单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteOrder([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_OrderService.Delete(idArr, "删除生产工单"));
        }

        /// <summary>
        /// 导出生产工单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产工单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:order:export")]
        public IActionResult Export([FromQuery] OrderQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _OrderService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生产工单", "生产工单","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入生产工单
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "生产工单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:order:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<OrderDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<OrderDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_OrderService.ImportOrder(list.Adapt<List<Order>>()));
        }

        /// <summary>
        /// 生产工单导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "生产工单模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<OrderDto>() { }, "OrderTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}