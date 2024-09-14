using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 财政年度
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:42:58
    /// </summary>
    [Verify]
    [Route("Accounting/FicoFinancialPeriod")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoFinancialPeriodController : BaseController
    {
        /// <summary>
        /// 财政年度接口
        /// </summary>
        private readonly IFicoFinancialPeriodService _FicoFinancialPeriodService;

        public FicoFinancialPeriodController(IFicoFinancialPeriodService FicoFinancialPeriodService)
        {
            _FicoFinancialPeriodService = FicoFinancialPeriodService;
        }

        /// <summary>
        /// 查询财政年度列表
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
        /// 查询财政年度详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:financialperiod:query")]
        public IActionResult GetFicoFinancialPeriod(long Id)
        {
            var response = _FicoFinancialPeriodService.GetInfo(Id);
            
            var info = response.Adapt<FicoFinancialPeriodDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加财政年度
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:financialperiod:add")]
        [Log(Title = "财政年度", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoFinancialPeriod([FromBody] FicoFinancialPeriodDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoFinancialPeriodService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增财政年度 '{parm.Id}'失败(Add failed)，输入的财政年度已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoFinancialPeriod>().ToCreate(HttpContext);

            var response = _FicoFinancialPeriodService.AddFicoFinancialPeriod(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新财政年度
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:financialperiod:edit")]
        [Log(Title = "财政年度", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoFinancialPeriod([FromBody] FicoFinancialPeriodDto parm)
        {
            var modal = parm.Adapt<FicoFinancialPeriod>().ToUpdate(HttpContext);
            var response = _FicoFinancialPeriodService.UpdateFicoFinancialPeriod(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除财政年度
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:financialperiod:delete")]
        [Log(Title = "财政年度", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoFinancialPeriod([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoFinancialPeriodService.Delete(idArr, "删除财政年度"));
        }

        /// <summary>
        /// 导出财政年度
        /// </summary>
        /// <returns></returns>
        [Log(Title = "财政年度导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
            var result = ExportExcelMini(list, "财政年度", "财政年度");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入财政年度
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "财政年度导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:financialperiod:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoFinancialPeriodDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoFinancialPeriodDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoFinancialPeriodService.ImportFicoFinancialPeriod(list.Adapt<List<FicoFinancialPeriod>>()));
        }

        /// <summary>
        /// 财政年度
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "财政年度模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoFinancialPeriodImportTpl>() { }, "FicoFinancialPeriod_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}