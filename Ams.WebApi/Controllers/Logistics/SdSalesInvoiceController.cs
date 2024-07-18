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
    /// @Date: 2024/7/18 11:28:47
    /// </summary>
    [Verify]
    [Route("Logistics/SdSalesInvoice")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class SdSalesInvoiceController : BaseController
    {
        /// <summary>
        /// 销售凭证接口
        /// </summary>
        private readonly ISdSalesInvoiceService _SdSalesInvoiceService;

        public SdSalesInvoiceController(ISdSalesInvoiceService SdSalesInvoiceService)
        {
            _SdSalesInvoiceService = SdSalesInvoiceService;
        }

        /// <summary>
        /// 查询销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:list")]
        public IActionResult QuerySdSalesInvoice([FromQuery] SdSalesInvoiceQueryDto parm)
        {
            var response = _SdSalesInvoiceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询销售凭证详情
        /// </summary>
        /// <param name="SsiSfid"></param>
        /// <returns></returns>
        [HttpGet("{SsiSfid}")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:query")]
        public IActionResult GetSdSalesInvoice(long SsiSfid)
        {
            var response = _SdSalesInvoiceService.GetInfo(SsiSfid);
            
            var info = response.Adapt<SdSalesInvoiceDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:add")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSdSalesInvoice([FromBody] SdSalesInvoiceDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_SdSalesInvoiceService.CheckInputUnique(parm.SsiSfid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增销售凭证 '{parm.SsiSfid}'失败(Add failed)，输入的销售凭证已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<SdSalesInvoice>().ToCreate(HttpContext);

            var response = _SdSalesInvoiceService.AddSdSalesInvoice(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:edit")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSdSalesInvoice([FromBody] SdSalesInvoiceDto parm)
        {
            var modal = parm.Adapt<SdSalesInvoice>().ToUpdate(HttpContext);
            var response = _SdSalesInvoiceService.UpdateSdSalesInvoice(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:delete")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdSalesInvoice([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_SdSalesInvoiceService.Delete(idArr, "删除销售凭证"));
        }

        /// <summary>
        /// 导出销售凭证
        /// </summary>
        /// <returns></returns>
        [Log(Title = "销售凭证", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:export")]
        public IActionResult Export([FromQuery] SdSalesInvoiceQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SdSalesInvoiceService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "销售凭证", "销售凭证");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "销售凭证导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SdSalesInvoiceDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SdSalesInvoiceDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SdSalesInvoiceService.ImportSdSalesInvoice(list.Adapt<List<SdSalesInvoice>>()));
        }

        /// <summary>
        /// 销售凭证导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "销售凭证模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SdSalesInvoiceImportTpl>() { }, "SdSalesInvoice_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}