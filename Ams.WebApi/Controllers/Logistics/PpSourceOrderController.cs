using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 源订单
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:05:57
    /// </summary>
    [Verify]
    [Route("Logistics/PpSourceOrder")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpSourceOrderController : BaseController
    {
        /// <summary>
        /// 源订单接口
        /// </summary>
        private readonly IPpSourceOrderService _PpSourceOrderService;

        public PpSourceOrderController(IPpSourceOrderService PpSourceOrderService)
        {
            _PpSourceOrderService = PpSourceOrderService;
        }

        /// <summary>
        /// 查询源订单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:sourceorder:list")]
        public IActionResult QueryPpSourceOrder([FromQuery] PpSourceOrderQueryDto parm)
        {
            var response = _PpSourceOrderService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询源订单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:sourceorder:query")]
        public IActionResult GetPpSourceOrder(long Id)
        {
            var response = _PpSourceOrderService.GetInfo(Id);
            
            var info = response.Adapt<PpSourceOrderDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加源订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:sourceorder:add")]
        [Log(Title = "源订单", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpSourceOrder([FromBody] PpSourceOrderDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpSourceOrderService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增源订单 '{parm.Id}'失败(Add failed)，输入的源订单已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpSourceOrder>().ToCreate(HttpContext);

            var response = _PpSourceOrderService.AddPpSourceOrder(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新源订单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:sourceorder:edit")]
        [Log(Title = "源订单", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpSourceOrder([FromBody] PpSourceOrderDto parm)
        {
            var modal = parm.Adapt<PpSourceOrder>().ToUpdate(HttpContext);
            var response = _PpSourceOrderService.UpdatePpSourceOrder(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除源订单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:sourceorder:delete")]
        [Log(Title = "源订单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpSourceOrder([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpSourceOrderService.Delete(idArr, "删除源订单"));
        }

        /// <summary>
        /// 导出源订单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "源订单导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:sourceorder:export")]
        public IActionResult Export([FromQuery] PpSourceOrderQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpSourceOrderService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "源订单", "源订单");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入源订单
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "源订单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:sourceorder:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpSourceOrderDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpSourceOrderDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpSourceOrderService.ImportPpSourceOrder(list.Adapt<List<PpSourceOrder>>()));
        }

        /// <summary>
        /// 源订单
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "源订单模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpSourceOrderImportTpl>() { }, "PpSourceOrder_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}