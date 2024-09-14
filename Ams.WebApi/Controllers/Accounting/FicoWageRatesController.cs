using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 工资率
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:26:01
    /// </summary>
    [Verify]
    [Route("Accounting/FicoWageRates")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoWageRatesController : BaseController
    {
        /// <summary>
        /// 工资率接口
        /// </summary>
        private readonly IFicoWageRatesService _FicoWageRatesService;

        public FicoWageRatesController(IFicoWageRatesService FicoWageRatesService)
        {
            _FicoWageRatesService = FicoWageRatesService;
        }

        /// <summary>
        /// 查询工资率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:wagerates:list")]
        public IActionResult QueryFicoWageRates([FromQuery] FicoWageRatesQueryDto parm)
        {
            var response = _FicoWageRatesService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询工资率详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:wagerates:query")]
        public IActionResult GetFicoWageRates(long Id)
        {
            var response = _FicoWageRatesService.GetInfo(Id);
            
            var info = response.Adapt<FicoWageRatesDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加工资率
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:wagerates:add")]
        [Log(Title = "工资率", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoWageRates([FromBody] FicoWageRatesDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoWageRatesService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增工资率 '{parm.Id}'失败(Add failed)，输入的工资率已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoWageRates>().ToCreate(HttpContext);

            var response = _FicoWageRatesService.AddFicoWageRates(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新工资率
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:wagerates:edit")]
        [Log(Title = "工资率", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoWageRates([FromBody] FicoWageRatesDto parm)
        {
            var modal = parm.Adapt<FicoWageRates>().ToUpdate(HttpContext);
            var response = _FicoWageRatesService.UpdateFicoWageRates(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工资率
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:wagerates:delete")]
        [Log(Title = "工资率", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoWageRates([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoWageRatesService.Delete(idArr, "删除工资率"));
        }

        /// <summary>
        /// 导出工资率
        /// </summary>
        /// <returns></returns>
        [Log(Title = "工资率导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:wagerates:export")]
        public IActionResult Export([FromQuery] FicoWageRatesQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoWageRatesService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "工资率", "工资率");
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
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoWageRatesDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoWageRatesDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoWageRatesService.ImportFicoWageRates(list.Adapt<List<FicoWageRates>>()));
        }

        /// <summary>
        /// 工资率
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "工资率模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoWageRatesImportTpl>() { }, "FicoWageRates_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}