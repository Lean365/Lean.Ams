using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// bom核算
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:34:34
    /// </summary>
    [Verify]
    [Route("Accounting/FicoCostingBom")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoCostingBomController : BaseController
    {
        /// <summary>
        /// bom核算接口
        /// </summary>
        private readonly IFicoCostingBomService _FicoCostingBomService;

        public FicoCostingBomController(IFicoCostingBomService FicoCostingBomService)
        {
            _FicoCostingBomService = FicoCostingBomService;
        }

        /// <summary>
        /// 查询bom核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:costingbom:list")]
        public IActionResult QueryFicoCostingBom([FromQuery] FicoCostingBomQueryDto parm)
        {
            var response = _FicoCostingBomService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询bom核算详情
        /// </summary>
        /// <param name="BcSfId"></param>
        /// <returns></returns>
        [HttpGet("{BcSfId}")]
        [ActionPermissionFilter(Permission = "fico:costingbom:query")]
        public IActionResult GetFicoCostingBom(long BcSfId)
        {
            var response = _FicoCostingBomService.GetInfo(BcSfId);
            
            var info = response.Adapt<FicoCostingBomDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加bom核算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:costingbom:add")]
        [Log(Title = "bom核算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoCostingBom([FromBody] FicoCostingBomDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoCostingBomService.CheckInputUnique(parm.BcSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增bom核算 '{parm.BcSfId}'失败(Add failed)，输入的bom核算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoCostingBom>().ToCreate(HttpContext);

            var response = _FicoCostingBomService.AddFicoCostingBom(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新bom核算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:costingbom:edit")]
        [Log(Title = "bom核算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoCostingBom([FromBody] FicoCostingBomDto parm)
        {
            var modal = parm.Adapt<FicoCostingBom>().ToUpdate(HttpContext);
            var response = _FicoCostingBomService.UpdateFicoCostingBom(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除bom核算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:costingbom:delete")]
        [Log(Title = "bom核算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoCostingBom([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoCostingBomService.Delete(idArr, "删除bom核算"));
        }

        /// <summary>
        /// 导出bom核算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "bom核算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:costingbom:export")]
        public IActionResult Export([FromQuery] FicoCostingBomQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoCostingBomService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "bom核算", "bom核算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "bom核算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:costingbom:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoCostingBomDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoCostingBomDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoCostingBomService.ImportFicoCostingBom(list.Adapt<List<FicoCostingBom>>()));
        }

        /// <summary>
        /// bom核算导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "bom核算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoCostingBomImportTpl>() { }, "FicoCostingBom_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}