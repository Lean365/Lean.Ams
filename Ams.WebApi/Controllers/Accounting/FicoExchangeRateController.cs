using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 汇率表
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:18
    /// </summary>
    [Verify]
    [Route("Accounting/FicoExchangeRate")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoExchangeRateController : BaseController
    {
        /// <summary>
        /// 汇率表接口
        /// </summary>
        private readonly IFicoExchangeRateService _FicoExchangeRateService;

        public FicoExchangeRateController(IFicoExchangeRateService FicoExchangeRateService)
        {
            _FicoExchangeRateService = FicoExchangeRateService;
        }

        /// <summary>
        /// 查询汇率表列表
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
        /// 查询汇率表详情
        /// </summary>
        /// <param name="FerSfId"></param>
        /// <returns></returns>
        [HttpGet("{FerSfId}")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:query")]
        public IActionResult GetFicoExchangeRate(long FerSfId)
        {
            var response = _FicoExchangeRateService.GetInfo(FerSfId);
            
            var info = response.Adapt<FicoExchangeRateDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加汇率表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:exchangerate:add")]
        [Log(Title = "汇率表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoExchangeRate([FromBody] FicoExchangeRateDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoExchangeRateService.CheckInputUnique(parm.FerSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增汇率表 '{parm.FerSfId}'失败(Add failed)，输入的汇率表已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoExchangeRate>().ToCreate(HttpContext);

            var response = _FicoExchangeRateService.AddFicoExchangeRate(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新汇率表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:exchangerate:edit")]
        [Log(Title = "汇率表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoExchangeRate([FromBody] FicoExchangeRateDto parm)
        {
            var modal = parm.Adapt<FicoExchangeRate>().ToUpdate(HttpContext);
            var response = _FicoExchangeRateService.UpdateFicoExchangeRate(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除汇率表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:delete")]
        [Log(Title = "汇率表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoExchangeRate([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoExchangeRateService.Delete(idArr, "删除汇率表"));
        }

        /// <summary>
        /// 导出汇率表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "汇率表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
            var result = ExportExcelMini(list, "汇率表", "汇率表");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "汇率表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:exchangerate:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoExchangeRateDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoExchangeRateDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoExchangeRateService.ImportFicoExchangeRate(list.Adapt<List<FicoExchangeRate>>()));
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
            var result = DownloadImportTemplate(new List<FicoExchangeRateImportTpl>() { }, "FicoExchangeRate_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}