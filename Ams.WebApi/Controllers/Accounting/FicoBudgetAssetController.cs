using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 资产预算
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:07
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetAsset")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetAssetController : BaseController
    {
        /// <summary>
        /// 资产预算接口
        /// </summary>
        private readonly IFicoBudgetAssetService _FicoBudgetAssetService;

        public FicoBudgetAssetController(IFicoBudgetAssetService FicoBudgetAssetService)
        {
            _FicoBudgetAssetService = FicoBudgetAssetService;
        }

        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetasset:list")]
        public IActionResult QueryFicoBudgetAsset([FromQuery] FicoBudgetAssetQueryDto parm)
        {
            var response = _FicoBudgetAssetService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询资产预算详情
        /// </summary>
        /// <param name="FbaSFID"></param>
        /// <returns></returns>
        [HttpGet("{FbaSFID}")]
        [ActionPermissionFilter(Permission = "fico:budgetasset:query")]
        public IActionResult GetFicoBudgetAsset(long FbaSFID)
        {
            var response = _FicoBudgetAssetService.GetInfo(FbaSFID);
            
            var info = response.Adapt<FicoBudgetAssetDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetasset:add")]
        [Log(Title = "资产预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetAsset([FromBody] FicoBudgetAssetDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetAssetService.CheckInputUnique(parm.FbaSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增资产预算 '{parm.FbaSFID}'失败(Add failed)，输入的资产预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetAsset>().ToCreate(HttpContext);

            var response = _FicoBudgetAssetService.AddFicoBudgetAsset(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetasset:edit")]
        [Log(Title = "资产预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetAsset([FromBody] FicoBudgetAssetDto parm)
        {
            var modal = parm.Adapt<FicoBudgetAsset>().ToUpdate(HttpContext);
            var response = _FicoBudgetAssetService.UpdateFicoBudgetAsset(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除资产预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetasset:delete")]
        [Log(Title = "资产预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetAsset([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetAssetService.Delete(idArr, "删除资产预算"));
        }

        /// <summary>
        /// 导出资产预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "资产预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetasset:export")]
        public IActionResult Export([FromQuery] FicoBudgetAssetQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetAssetService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "资产预算", "资产预算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "资产预算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetasset:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetAssetDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetAssetDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetAssetService.ImportFicoBudgetAsset(list.Adapt<List<FicoBudgetAsset>>()));
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
            var result = DownloadImportTemplate(new List<FicoBudgetAssetImportTpl>() { }, "FicoBudgetAsset_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}