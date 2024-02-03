using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 预算实际明细
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 10:41:09)
    /// </summary>
    [Verify]
    [Route("accounting/BudgetActualCost")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class BudgetActualCostController : BaseController
    {
        /// <summary>
        /// 预算实际明细接口
        /// </summary>
        private readonly IBudgetActualCostService _BudgetActualCostService;

        public BudgetActualCostController(IBudgetActualCostService BudgetActualCostService)
        {
            _BudgetActualCostService = BudgetActualCostService;
        }

        /// <summary>
        /// 查询预算实际明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:list")]
        public IActionResult QueryBudgetActualCost([FromQuery] BudgetActualCostQueryDto parm)
        {
            var response = _BudgetActualCostService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询预算实际明细详情
        /// </summary>
        /// <param name="FbSFID"></param>
        /// <returns></returns>
        [HttpGet("{FbSFID}")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:query")]
        public IActionResult GetBudgetActualCost(long FbSFID)
        {
            var response = _BudgetActualCostService.GetInfo(FbSFID);
            
            var info = response.Adapt<BudgetActualCostDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加预算实际明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:add")]
        [Log(Title = "预算实际明细", BusinessType = BusinessType.INSERT)]
        public IActionResult AddBudgetActualCost([FromBody] BudgetActualCostDto parm)
        {
            var modal = parm.Adapt<BudgetActualCost>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_BudgetActualCostService.CheckEntryUnique(parm.FbSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)预算实际明细 '{parm.FbSFID}'失败(failed)，输入的(The entered)预算实际明细已存在(already exists)"));
            }
            var response = _BudgetActualCostService.AddBudgetActualCost(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新预算实际明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:edit")]
        [Log(Title = "预算实际明细", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateBudgetActualCost([FromBody] BudgetActualCostDto parm)
        {
            var modal = parm.Adapt<BudgetActualCost>().ToUpdate(HttpContext);
            var response = _BudgetActualCostService.UpdateBudgetActualCost(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除预算实际明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:delete")]
        [Log(Title = "预算实际明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteBudgetActualCost([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_BudgetActualCostService.Delete(idArr, "删除预算实际明细"));
        }

        /// <summary>
        /// 导出预算实际明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "预算实际明细", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:export")]
        public IActionResult Export([FromQuery] BudgetActualCostQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _BudgetActualCostService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "预算实际明细", "预算实际明细","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入预算实际明细
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "预算实际明细导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<BudgetActualCostDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<BudgetActualCostDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_BudgetActualCostService.ImportBudgetActualCost(list.Adapt<List<BudgetActualCost>>()));
        }

        /// <summary>
        /// 预算实际明细导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "预算实际明细模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<BudgetActualCostDto>() { }, "BudgetActualCostTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}