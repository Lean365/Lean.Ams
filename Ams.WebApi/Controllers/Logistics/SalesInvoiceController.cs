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
    /// 销售凭证
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/31 12:01:23)
    /// </summary>
    [Verify]
    [Route("logistics/SalesInvoice")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class SalesInvoiceController : BaseController
    {
        /// <summary>
        /// 销售凭证接口
        /// </summary>
        private readonly ISalesInvoiceService _SalesInvoiceService;

        public SalesInvoiceController(ISalesInvoiceService SalesInvoiceService)
        {
            _SalesInvoiceService = SalesInvoiceService;
        }

        /// <summary>
        /// 查询销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:list")]
        public IActionResult QuerySalesInvoice([FromQuery] SalesInvoiceQueryDto parm)
        {
            var response = _SalesInvoiceService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询销售凭证详情
        /// </summary>
        /// <param name="SsiSfid"></param>
        /// <returns></returns>
        [HttpGet("{SsiSfid}")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:query")]
        public IActionResult GetSalesInvoice(long SsiSfid)
        {
            var response = _SalesInvoiceService.GetInfo(SsiSfid);
            
            var info = response.Adapt<SalesInvoiceDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:add")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSalesInvoice([FromBody] SalesInvoiceDto parm)
        {
            var modal = parm.Adapt<SalesInvoice>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_SalesInvoiceService.CheckEntryUnique(parm.SsiSfid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)销售凭证 '{parm.SsiSfid}'失败(failed)，输入的(The entered)销售凭证已存在(already exists)"));
            }
            var response = _SalesInvoiceService.AddSalesInvoice(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:edit")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSalesInvoice([FromBody] SalesInvoiceDto parm)
        {
            var modal = parm.Adapt<SalesInvoice>().ToUpdate(HttpContext);
            var response = _SalesInvoiceService.UpdateSalesInvoice(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:delete")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSalesInvoice([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_SalesInvoiceService.Delete(idArr, "删除销售凭证"));
        }

        /// <summary>
        /// 导出销售凭证
        /// </summary>
        /// <returns></returns>
        [Log(Title = "销售凭证", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:export")]
        public IActionResult Export([FromQuery] SalesInvoiceQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SalesInvoiceService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "销售凭证", "销售凭证","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入销售凭证
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "销售凭证导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "sd:salesinvoice:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SalesInvoiceDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SalesInvoiceDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SalesInvoiceService.ImportSalesInvoice(list.Adapt<List<SalesInvoice>>()));
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
            var result = DownloadImportTemplate(new List<SalesInvoiceDto>() { }, "SalesInvoiceTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}