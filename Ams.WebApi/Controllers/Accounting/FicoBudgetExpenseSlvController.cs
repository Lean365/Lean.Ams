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
    /// @Date: 2024/8/9 13:28:29
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetExpenseSlv")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetExpenseSlvController : BaseController
    {
        /// <summary>
        /// 费用预算接口
        /// </summary>
        private readonly IFicoBudgetExpenseSlvService _FicoBudgetExpenseSlvService;

        public FicoBudgetExpenseSlvController(IFicoBudgetExpenseSlvService FicoBudgetExpenseSlvService)
        {
            _FicoBudgetExpenseSlvService = FicoBudgetExpenseSlvService;
        }

        /// <summary>
        /// 查询费用预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetexpenseslv:list")]
        public IActionResult QueryFicoBudgetExpenseSlv([FromQuery] FicoBudgetExpenseSlvQueryDto parm)
        {
            var response = _FicoBudgetExpenseSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询费用预算详情
        /// </summary>
        /// <param name="FbesSfId"></param>
        /// <returns></returns>
        [HttpGet("{FbesSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetexpenseslv:query")]
        public IActionResult GetFicoBudgetExpenseSlv(long FbesSfId)
        {
            var response = _FicoBudgetExpenseSlvService.GetInfo(FbesSfId);
            
            var info = response.Adapt<FicoBudgetExpenseSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加费用预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetexpenseslv:add")]
        [Log(Title = "费用预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetExpenseSlv([FromBody] FicoBudgetExpenseSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetExpenseSlvService.CheckInputUnique(parm.FbesSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增费用预算 '{parm.FbesSfId}'失败(Add failed)，输入的费用预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetExpenseSlv>().ToCreate(HttpContext);

            var response = _FicoBudgetExpenseSlvService.AddFicoBudgetExpenseSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新费用预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetexpenseslv:edit")]
        [Log(Title = "费用预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetExpenseSlv([FromBody] FicoBudgetExpenseSlvDto parm)
        {
            var modal = parm.Adapt<FicoBudgetExpenseSlv>().ToUpdate(HttpContext);
            var response = _FicoBudgetExpenseSlvService.UpdateFicoBudgetExpenseSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除费用预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetexpenseslv:delete")]
        [Log(Title = "费用预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetExpenseSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetExpenseSlvService.Delete(idArr, "删除费用预算"));
        }

        /// <summary>
        /// 导出费用预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "费用预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetexpenseslv:export")]
        public IActionResult Export([FromQuery] FicoBudgetExpenseSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetExpenseSlvService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "fico:budgetexpenseslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetExpenseSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetExpenseSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetExpenseSlvService.ImportFicoBudgetExpenseSlv(list.Adapt<List<FicoBudgetExpenseSlv>>()));
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
            var result = DownloadImportTemplate(new List<FicoBudgetExpenseSlvImportTpl>() { }, "FicoBudgetExpenseSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}