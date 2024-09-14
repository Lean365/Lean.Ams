using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 币种汇率
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:52:45
    /// </summary>
    [Verify]
    [Route("Accounting/FicoExchangeRate")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoExchangeRateController : BaseController
    {
        /// <summary>
        /// 币种汇率接口
        /// </summary>
        private readonly IFicoExchangeRateService _FicoExchangeRateService;

        public FicoExchangeRateController(IFicoExchangeRateService FicoExchangeRateService)
        {
            _FicoExchangeRateService = FicoExchangeRateService;
        }

        /// <summary>
        /// 查询币种汇率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:list")]
        public IActionResult QueryFicoExchangeRate([FromQuery] FicoExchangeRateQueryDto parm)
        {
            var response = _FicoExchangeRateService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询币种汇率详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:query")]
        public IActionResult GetFicoExchangeRate(long Id)
        {
            var response = _FicoExchangeRateService.GetInfo(Id);
            
            var info = response.Adapt<FicoExchangeRateDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加币种汇率
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:exchangerate:add")]
        [Log(Title = "币种汇率", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoExchangeRate([FromBody] FicoExchangeRateDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoExchangeRateService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增币种汇率 '{parm.Id}'失败(Add failed)，输入的币种汇率已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoExchangeRate>().ToCreate(HttpContext);

            var response = _FicoExchangeRateService.AddFicoExchangeRate(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新币种汇率
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:exchangerate:edit")]
        [Log(Title = "币种汇率", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoExchangeRate([FromBody] FicoExchangeRateDto parm)
        {
            var modal = parm.Adapt<FicoExchangeRate>().ToUpdate(HttpContext);
            var response = _FicoExchangeRateService.UpdateFicoExchangeRate(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除币种汇率
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:delete")]
        [Log(Title = "币种汇率", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoExchangeRate([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoExchangeRateService.Delete(idArr, "删除币种汇率"));
        }

        /// <summary>
        /// 导出币种汇率
        /// </summary>
        /// <returns></returns>
        [Log(Title = "币种汇率导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:export")]
        public IActionResult Export([FromQuery] FicoExchangeRateQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoExchangeRateService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "币种汇率", "币种汇率");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入币种汇率
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "币种汇率导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:exchangerate:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoExchangeRateDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoExchangeRateDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoExchangeRateService.ImportFicoExchangeRate(list.Adapt<List<FicoExchangeRate>>()));
        }

        /// <summary>
        /// 币种汇率
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "币种汇率模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoExchangeRateImportTpl>() { }, "FicoExchangeRate_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}