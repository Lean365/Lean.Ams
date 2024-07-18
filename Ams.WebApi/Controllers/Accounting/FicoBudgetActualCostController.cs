using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 预算实际明细
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:42:06
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetActualCost")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetActualCostController : BaseController
    {
        /// <summary>
        /// 预算实际明细接口
        /// </summary>
        private readonly IFicoBudgetActualCostService _FicoBudgetActualCostService;

        public FicoBudgetActualCostController(IFicoBudgetActualCostService FicoBudgetActualCostService)
        {
            _FicoBudgetActualCostService = FicoBudgetActualCostService;
        }

        /// <summary>
        /// 查询预算实际明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:list")]
        public IActionResult QueryFicoBudgetActualCost([FromQuery] FicoBudgetActualCostQueryDto parm)
        {
            var response = _FicoBudgetActualCostService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询预算实际明细详情
        /// </summary>
        /// <param name="FbSFID"></param>
        /// <returns></returns>
        [HttpGet("{FbSFID}")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:query")]
        public IActionResult GetFicoBudgetActualCost(long FbSFID)
        {
            var response = _FicoBudgetActualCostService.GetInfo(FbSFID);
            
            var info = response.Adapt<FicoBudgetActualCostDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 导出预算实际明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "预算实际明细", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:export")]
        public IActionResult Export([FromQuery] FicoBudgetActualCostQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetActualCostService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "预算实际明细", "预算实际明细");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "预算实际明细导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetActualCostDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetActualCostDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetActualCostService.ImportFicoBudgetActualCost(list.Adapt<List<FicoBudgetActualCost>>()));
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
            var result = DownloadImportTemplate(new List<FicoBudgetActualCostDto>() { }, "FicoBudgetActualCost");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}