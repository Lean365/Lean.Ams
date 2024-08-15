using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 预算科目
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/7 8:08:11
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetAccountingMa")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetAccountingMaController : BaseController
    {
        /// <summary>
        /// 预算科目接口
        /// </summary>
        private readonly IFicoBudgetAccountingMaService _FicoBudgetAccountingMaService;

        public FicoBudgetAccountingMaController(IFicoBudgetAccountingMaService FicoBudgetAccountingMaService)
        {
            _FicoBudgetAccountingMaService = FicoBudgetAccountingMaService;
        }

        /// <summary>
        /// 查询预算科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingma:list")]
        public IActionResult QueryFicoBudgetAccountingMa([FromQuery] FicoBudgetAccountingMaQueryDto parm)
        {
            var response = _FicoBudgetAccountingMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询预算科目详情
        /// </summary>
        /// <param name="FbasSfId"></param>
        /// <returns></returns>
        [HttpGet("{FbasSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingma:query")]
        public IActionResult GetFicoBudgetAccountingMa(long FbasSfId)
        {
            var response = _FicoBudgetAccountingMaService.GetInfo(FbasSfId);
            
            var info = response.Adapt<FicoBudgetAccountingMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加预算科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingma:add")]
        [Log(Title = "预算科目", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetAccountingMa([FromBody] FicoBudgetAccountingMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetAccountingMaService.CheckInputUnique(parm.FbasSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增预算科目 '{parm.FbasSfId}'失败(Add failed)，输入的预算科目已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetAccountingMa>().ToCreate(HttpContext);

            var response = _FicoBudgetAccountingMaService.AddFicoBudgetAccountingMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新预算科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingma:edit")]
        [Log(Title = "预算科目", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetAccountingMa([FromBody] FicoBudgetAccountingMaDto parm)
        {
            var modal = parm.Adapt<FicoBudgetAccountingMa>().ToUpdate(HttpContext);
            var response = _FicoBudgetAccountingMaService.UpdateFicoBudgetAccountingMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除预算科目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingma:delete")]
        [Log(Title = "预算科目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetAccountingMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetAccountingMaService.Delete(idArr, "删除预算科目"));
        }

        /// <summary>
        /// 导出预算科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "预算科目", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingma:export")]
        public IActionResult Export([FromQuery] FicoBudgetAccountingMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetAccountingMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "预算科目", "预算科目");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "预算科目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingma:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetAccountingMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetAccountingMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetAccountingMaService.ImportFicoBudgetAccountingMa(list.Adapt<List<FicoBudgetAccountingMa>>()));
        }

        /// <summary>
        /// 预算科目导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "预算科目模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetAccountingMaImportTpl>() { }, "FicoBudgetAccountingMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}