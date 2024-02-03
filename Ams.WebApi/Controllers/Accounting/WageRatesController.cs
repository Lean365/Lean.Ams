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
    /// 工资率
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 7:33:39)
    /// </summary>
    [Verify]
    [Route("accounting/WageRates")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class WageRatesController : BaseController
    {
        /// <summary>
        /// 工资率接口
        /// </summary>
        private readonly IWageRatesService _WageRatesService;

        public WageRatesController(IWageRatesService WageRatesService)
        {
            _WageRatesService = WageRatesService;
        }

        /// <summary>
        /// 查询工资率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:wagerates:list")]
        public IActionResult QueryWageRates([FromQuery] WageRatesQueryDto parm)
        {
            var response = _WageRatesService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询工资率详情
        /// </summary>
        /// <param name="FwSFID"></param>
        /// <returns></returns>
        [HttpGet("{FwSFID}")]
        [ActionPermissionFilter(Permission = "fico:wagerates:query")]
        public IActionResult GetWageRates(long FwSFID)
        {
            var response = _WageRatesService.GetInfo(FwSFID);
            
            var info = response.Adapt<WageRatesDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加工资率
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:wagerates:add")]
        [Log(Title = "工资率", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWageRates([FromBody] WageRatesDto parm)
        {
            var modal = parm.Adapt<WageRates>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_WageRatesService.CheckEntryUnique(parm.FwCrop.ToString()+ parm.FwYm.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)工资率 '{parm.FwCrop.ToString() +","+ parm.FwYm.ToString()}'失败(failed)，输入的(The entered)工资率已存在(already exists)"));
            }
            var response = _WageRatesService.AddWageRates(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新工资率
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:wagerates:edit")]
        [Log(Title = "工资率", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWageRates([FromBody] WageRatesDto parm)
        {
            var modal = parm.Adapt<WageRates>().ToUpdate(HttpContext);
            var response = _WageRatesService.UpdateWageRates(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工资率
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:wagerates:delete")]
        [Log(Title = "工资率", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWageRates([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_WageRatesService.Delete(idArr, "删除工资率"));
        }

        /// <summary>
        /// 导出工资率
        /// </summary>
        /// <returns></returns>
        [Log(Title = "工资率", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:wagerates:export")]
        public IActionResult Export([FromQuery] WageRatesQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _WageRatesService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "工资率", "工资率","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入工资率
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "工资率导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:wagerates:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<WageRatesDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<WageRatesDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_WageRatesService.ImportWageRates(list.Adapt<List<WageRates>>()));
        }

        /// <summary>
        /// 工资率导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "工资率模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<WageRatesDto>() { }, "WageRatesTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}