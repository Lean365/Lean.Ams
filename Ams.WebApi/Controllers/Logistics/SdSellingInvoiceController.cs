using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 销售凭证
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/7 16:16:45
    /// </summary>
    [Verify]
    [Route("Logistics/SdSellingInvoice")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class SdSellingInvoiceController : BaseController
    {
        /// <summary>
        /// 销售凭证接口
        /// </summary>
        private readonly ISdSellingInvoiceService _SdSellingInvoiceService;

        public SdSellingInvoiceController(ISdSellingInvoiceService SdSellingInvoiceService)
        {
            _SdSellingInvoiceService = SdSellingInvoiceService;
        }

        /// <summary>
        /// 查询销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:sellinginvoice:list")]
        public IActionResult QuerySdSellingInvoice([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            var response = _SdSellingInvoiceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询销售凭证详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "sd:sellinginvoice:query")]
        public IActionResult GetSdSellingInvoice(long Id)
        {
            var response = _SdSellingInvoiceService.GetInfo(Id);
            
            var info = response.Adapt<SdSellingInvoiceDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:sellinginvoice:add")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.ADD)]
        public IActionResult AddSdSellingInvoice([FromBody] SdSellingInvoiceDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_SdSellingInvoiceService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增销售凭证 '{parm.Id}'失败(Add failed)，输入的销售凭证已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<SdSellingInvoice>().ToCreate(HttpContext);

            var response = _SdSellingInvoiceService.AddSdSellingInvoice(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:sellinginvoice:edit")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateSdSellingInvoice([FromBody] SdSellingInvoiceDto parm)
        {
            var modal = parm.Adapt<SdSellingInvoice>().ToUpdate(HttpContext);
            var response = _SdSellingInvoiceService.UpdateSdSellingInvoice(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "sd:sellinginvoice:delete")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdSellingInvoice([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_SdSellingInvoiceService.Delete(idArr, "删除销售凭证"));
        }

        /// <summary>
        /// 导出销售凭证
        /// </summary>
        /// <returns></returns>
        [Log(Title = "销售凭证导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:sellinginvoice:export")]
        public IActionResult Export([FromQuery] SdSellingInvoiceQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SdSellingInvoiceService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "销售凭证", "销售凭证");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入销售凭证
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "销售凭证导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "sd:sellinginvoice:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<SdSellingInvoiceDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SdSellingInvoiceDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SdSellingInvoiceService.ImportSdSellingInvoice(list.Adapt<List<SdSellingInvoice>>()));
        }

        /// <summary>
        /// 销售凭证
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "销售凭证模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SdSellingInvoiceImportTpl>() { }, "SdSellingInvoice_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}