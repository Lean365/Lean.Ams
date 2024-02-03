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
    /// 资产预算
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// </summary>
    [Verify]
    [Route("accounting/BudgetAsset")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class BudgetAssetController : BaseController
    {
        /// <summary>
        /// 资产预算接口
        /// </summary>
        private readonly IBudgetAssetService _BudgetAssetService;

        public BudgetAssetController(IBudgetAssetService BudgetAssetService)
        {
            _BudgetAssetService = BudgetAssetService;
        }

        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetasset:list")]
        public IActionResult QueryBudgetAsset([FromQuery] BudgetAssetQueryDto parm)
        {
            var response = _BudgetAssetService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询资产预算详情
        /// </summary>
        /// <param name="FbaSFID"></param>
        /// <returns></returns>
        [HttpGet("{FbaSFID}")]
        [ActionPermissionFilter(Permission = "fico:budgetasset:query")]
        public IActionResult GetBudgetAsset(long FbaSFID)
        {
            var response = _BudgetAssetService.GetInfo(FbaSFID);
            
            var info = response.Adapt<BudgetAssetDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetasset:add")]
        [Log(Title = "资产预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddBudgetAsset([FromBody] BudgetAssetDto parm)
        {
            var modal = parm.Adapt<BudgetAsset>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_BudgetAssetService.CheckEntryUnique(parm.FbaSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)资产预算 '{parm.FbaSFID}'失败(failed)，输入的(The entered)资产预算已存在(already exists)"));
            }
            var response = _BudgetAssetService.AddBudgetAsset(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetasset:edit")]
        [Log(Title = "资产预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateBudgetAsset([FromBody] BudgetAssetDto parm)
        {
            var modal = parm.Adapt<BudgetAsset>().ToUpdate(HttpContext);
            var response = _BudgetAssetService.UpdateBudgetAsset(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除资产预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetasset:delete")]
        [Log(Title = "资产预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteBudgetAsset([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_BudgetAssetService.Delete(idArr, "删除资产预算"));
        }

        /// <summary>
        /// 导出资产预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "资产预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetasset:export")]
        public IActionResult Export([FromQuery] BudgetAssetQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _BudgetAssetService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "资产预算", "资产预算","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入资产预算
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "资产预算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetasset:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<BudgetAssetDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<BudgetAssetDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_BudgetAssetService.ImportBudgetAsset(list.Adapt<List<BudgetAsset>>()));
        }

        /// <summary>
        /// 资产预算导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "资产预算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<BudgetAssetDto>() { }, "BudgetAssetTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}