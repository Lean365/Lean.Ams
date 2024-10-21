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
    /// @Date: 2024/10/16 8:05:21
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetExpense")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetExpenseController : BaseController
    {
        /// <summary>
        /// 费用预算接口
        /// </summary>
        private readonly IFicoBudgetExpenseService _FicoBudgetExpenseService;

        public FicoBudgetExpenseController(IFicoBudgetExpenseService FicoBudgetExpenseService)
        {
            _FicoBudgetExpenseService = FicoBudgetExpenseService;
        }

        /// <summary>
        /// 查询费用预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetexpense:list")]
        public IActionResult QueryFicoBudgetExpense([FromQuery] FicoBudgetExpenseQueryDto parm)
        {
            var response = _FicoBudgetExpenseService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询费用预算详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:budgetexpense:query")]
        public IActionResult GetFicoBudgetExpense(long Id)
        {
            var response = _FicoBudgetExpenseService.GetInfo(Id);
            
            var info = response.Adapt<FicoBudgetExpenseDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加费用预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetexpense:add")]
        [Log(Title = "费用预算", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoBudgetExpense([FromBody] FicoBudgetExpenseDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetExpenseService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增费用预算 '{parm.Id}'失败(Add failed)，输入的费用预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetExpense>().ToCreate(HttpContext);

            var response = _FicoBudgetExpenseService.AddFicoBudgetExpense(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新费用预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetexpense:edit")]
        [Log(Title = "费用预算", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoBudgetExpense([FromBody] FicoBudgetExpenseDto parm)
        {
            var modal = parm.Adapt<FicoBudgetExpense>().ToUpdate(HttpContext);
            var response = _FicoBudgetExpenseService.UpdateFicoBudgetExpense(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除费用预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetexpense:delete")]
        [Log(Title = "费用预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetExpense([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetExpenseService.Delete(idArr, "删除费用预算"));
        }

        /// <summary>
        /// 导出费用预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "费用预算导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetexpense:export")]
        public IActionResult Export([FromQuery] FicoBudgetExpenseQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetExpenseService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "费用预算", "费用预算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入费用预算
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "费用预算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetexpense:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoBudgetExpenseDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetExpenseDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetExpenseService.ImportFicoBudgetExpense(list.Adapt<List<FicoBudgetExpense>>()));
        }

        /// <summary>
        /// 费用预算
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "费用预算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetExpenseImportTpl>() { }, "FicoBudgetExpense_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}