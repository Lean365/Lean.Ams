using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 费用预算
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:31:03
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetExpenseMa")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetExpenseMaController : BaseController
    {
        /// <summary>
        /// 费用预算接口
        /// </summary>
        private readonly IFicoBudgetExpenseMaService _FicoBudgetExpenseMaService;

        public FicoBudgetExpenseMaController(IFicoBudgetExpenseMaService FicoBudgetExpenseMaService)
        {
            _FicoBudgetExpenseMaService = FicoBudgetExpenseMaService;
        }

        /// <summary>
        /// 查询费用预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetexpensema:list")]
        public IActionResult QueryFicoBudgetExpenseMa([FromQuery] FicoBudgetExpenseMaQueryDto parm)
        {
            var response = _FicoBudgetExpenseMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询费用预算详情
        /// </summary>
        /// <param name="FbeSfId"></param>
        /// <returns></returns>
        [HttpGet("{FbeSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetexpensema:query")]
        public IActionResult GetFicoBudgetExpenseMa(long FbeSfId)
        {
            var response = _FicoBudgetExpenseMaService.GetInfo(FbeSfId);
            
            var info = response.Adapt<FicoBudgetExpenseMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加费用预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetexpensema:add")]
        [Log(Title = "费用预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetExpenseMa([FromBody] FicoBudgetExpenseMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetExpenseMaService.CheckInputUnique(parm.FbeSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增费用预算 '{parm.FbeSfId}'失败(Add failed)，输入的费用预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetExpenseMa>().ToCreate(HttpContext);

            var response = _FicoBudgetExpenseMaService.AddFicoBudgetExpenseMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新费用预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetexpensema:edit")]
        [Log(Title = "费用预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetExpenseMa([FromBody] FicoBudgetExpenseMaDto parm)
        {
            var modal = parm.Adapt<FicoBudgetExpenseMa>().ToUpdate(HttpContext);
            var response = _FicoBudgetExpenseMaService.UpdateFicoBudgetExpenseMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除费用预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetexpensema:delete")]
        [Log(Title = "费用预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetExpenseMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetExpenseMaService.Delete(idArr, "删除费用预算"));
        }

        /// <summary>
        /// 导出费用预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "费用预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetexpensema:export")]
        public IActionResult Export([FromQuery] FicoBudgetExpenseMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetExpenseMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "费用预算", "费用预算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "费用预算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetexpensema:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetExpenseMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetExpenseMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetExpenseMaService.ImportFicoBudgetExpenseMa(list.Adapt<List<FicoBudgetExpenseMa>>()));
        }

        /// <summary>
        /// 费用预算导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "费用预算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetExpenseMaImportTpl>() { }, "FicoBudgetExpenseMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}