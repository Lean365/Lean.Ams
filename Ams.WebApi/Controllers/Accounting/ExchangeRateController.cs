using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 汇率表
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:07:17)
    /// </summary>
    [Verify]
    [Route("accounting/ExchangeRate")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class ExchangeRateController : BaseController
    {
        /// <summary>
        /// 汇率表接口
        /// </summary>
        private readonly IExchangeRateService _ExchangeRateService;

        public ExchangeRateController(IExchangeRateService ExchangeRateService)
        {
            _ExchangeRateService = ExchangeRateService;
        }

        /// <summary>
        /// 查询汇率表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:list")]
        public IActionResult QueryExchangeRate([FromQuery] ExchangeRateQueryDto parm)
        {
            var response = _ExchangeRateService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询汇率表详情
        /// </summary>
        /// <param name="FerSFID"></param>
        /// <returns></returns>
        [HttpGet("{FerSFID}")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:query")]
        public IActionResult GetExchangeRate(long FerSFID)
        {
            var response = _ExchangeRateService.GetInfo(FerSFID);
            
            var info = response.Adapt<ExchangeRateDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加汇率表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:exchangerate:add")]
        [Log(Title = "汇率表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddExchangeRate([FromBody] ExchangeRateDto parm)
        {
            var modal = parm.Adapt<ExchangeRate>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_ExchangeRateService.CheckEntryUnique(parm.FerSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)汇率表 '{parm.FerSFID}'失败(failed)，输入的(The entered)汇率表已存在(already exists)"));
            }
            var response = _ExchangeRateService.AddExchangeRate(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新汇率表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:exchangerate:edit")]
        [Log(Title = "汇率表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateExchangeRate([FromBody] ExchangeRateDto parm)
        {
            var modal = parm.Adapt<ExchangeRate>().ToUpdate(HttpContext);
            var response = _ExchangeRateService.UpdateExchangeRate(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除汇率表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:delete")]
        [Log(Title = "汇率表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteExchangeRate([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_ExchangeRateService.Delete(idArr, "删除汇率表"));
        }

        /// <summary>
        /// 导出汇率表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "汇率表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:export")]
        public IActionResult Export([FromQuery] ExchangeRateQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _ExchangeRateService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "汇率表", "汇率表","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入汇率表
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "汇率表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:exchangerate:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<ExchangeRateDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<ExchangeRateDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_ExchangeRateService.ImportExchangeRate(list.Adapt<List<ExchangeRate>>()));
        }

        /// <summary>
        /// 汇率表导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "汇率表模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<ExchangeRateDto>() { }, "ExchangeRateTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}