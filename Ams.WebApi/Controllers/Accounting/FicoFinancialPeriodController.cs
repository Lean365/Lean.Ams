using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;
using Microsoft.AspNetCore.Mvc;
using MiniExcelLibs;

namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 财务期间
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 13:51:07
    /// </summary>
    [Verify]
    [Route("Accounting/FicoFinancialPeriod")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoFinancialPeriodController : BaseController
    {
        /// <summary>
        /// 财务期间接口
        /// </summary>
        private readonly IFicoFinancialPeriodService _FicoFinancialPeriodService;

        public FicoFinancialPeriodController(IFicoFinancialPeriodService FicoFinancialPeriodService)
        {
            _FicoFinancialPeriodService = FicoFinancialPeriodService;
        }

        /// <summary>
        /// 查询财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:financialperiod:list")]
        public IActionResult QueryFicoFinancialPeriod([FromQuery] FicoFinancialPeriodQueryDto parm)
        {
            var response = _FicoFinancialPeriodService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询财务期间详情
        /// </summary>
        /// <param name="FpSfId"></param>
        /// <returns></returns>
        [HttpGet("{FpSfId}")]
        [ActionPermissionFilter(Permission = "fico:financialperiod:query")]
        public IActionResult GetFicoFinancialPeriod(long FpSfId)
        {
            var response = _FicoFinancialPeriodService.GetInfo(FpSfId);

            var info = response.Adapt<FicoFinancialPeriodDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加财务期间
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:financialperiod:add")]
        [Log(Title = "财务期间", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoFinancialPeriod([FromBody] FicoFinancialPeriodDto parm)
        {
            // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoFinancialPeriodService.CheckInputUnique(parm.FpYearMonth.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增财务期间 '{parm.FpYearMonth}'失败(Add failed)，输入的财务期间已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoFinancialPeriod>().ToCreate(HttpContext);

            var response = _FicoFinancialPeriodService.AddFicoFinancialPeriod(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新财务期间
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:financialperiod:edit")]
        [Log(Title = "财务期间", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoFinancialPeriod([FromBody] FicoFinancialPeriodDto parm)
        {
            var modal = parm.Adapt<FicoFinancialPeriod>().ToUpdate(HttpContext);
            var response = _FicoFinancialPeriodService.UpdateFicoFinancialPeriod(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除财务期间
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:financialperiod:delete")]
        [Log(Title = "财务期间", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoFinancialPeriod([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoFinancialPeriodService.Delete(idArr, "删除财务期间"));
        }

        /// <summary>
        /// 导出财务期间
        /// </summary>
        /// <returns></returns>
        [Log(Title = "财务期间", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:financialperiod:export")]
        public IActionResult Export([FromQuery] FicoFinancialPeriodQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoFinancialPeriodService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "财务期间", "财务期间");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "财务期间导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:financialperiod:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoFinancialPeriodDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoFinancialPeriodDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoFinancialPeriodService.ImportFicoFinancialPeriod(list.Adapt<List<FicoFinancialPeriod>>()));
        }

        /// <summary>
        /// 财务期间导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "财务期间模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoFinancialPeriodImportTpl>() { }, "FicoFinancialPeriod_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}