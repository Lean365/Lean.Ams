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
    /// @Date: 2024/9/10 15:46:44
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetAssets")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetAssetsController : BaseController
    {
        /// <summary>
        /// 资产预算接口
        /// </summary>
        private readonly IFicoBudgetAssetsService _FicoBudgetAssetsService;

        public FicoBudgetAssetsController(IFicoBudgetAssetsService FicoBudgetAssetsService)
        {
            _FicoBudgetAssetsService = FicoBudgetAssetsService;
        }

        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetassets:list")]
        public IActionResult QueryFicoBudgetAssets([FromQuery] FicoBudgetAssetsQueryDto parm)
        {
            var response = _FicoBudgetAssetsService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询资产预算列表树
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("treeList")]
        [ActionPermissionFilter(Permission = "fico:budgetassets:list")]
        public IActionResult QueryTreeFicoBudgetAssets([FromQuery] FicoBudgetAssetsQueryDto parm)
        {
            var response = _FicoBudgetAssetsService.GetTreeList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询资产预算详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:budgetassets:query")]
        public IActionResult GetFicoBudgetAssets(long Id)
        {
            var response = _FicoBudgetAssetsService.GetInfo(Id);
            
            var info = response.Adapt<FicoBudgetAssetsDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetassets:add")]
        [Log(Title = "资产预算", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoBudgetAssets([FromBody] FicoBudgetAssetsDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetAssetsService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增资产预算 '{parm.Id}'失败(Add failed)，输入的资产预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetAssets>().ToCreate(HttpContext);

            var response = _FicoBudgetAssetsService.AddFicoBudgetAssets(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetassets:edit")]
        [Log(Title = "资产预算", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoBudgetAssets([FromBody] FicoBudgetAssetsDto parm)
        {
            var modal = parm.Adapt<FicoBudgetAssets>().ToUpdate(HttpContext);
            var response = _FicoBudgetAssetsService.UpdateFicoBudgetAssets(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除资产预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetassets:delete")]
        [Log(Title = "资产预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetAssets([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetAssetsService.Delete(idArr, "删除资产预算"));
        }

        /// <summary>
        /// 导出资产预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "资产预算导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetassets:export")]
        public IActionResult Export([FromQuery] FicoBudgetAssetsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetAssetsService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "资产预算", "资产预算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入资产预算
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "资产预算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetassets:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoBudgetAssetsDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetAssetsDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetAssetsService.ImportFicoBudgetAssets(list.Adapt<List<FicoBudgetAssets>>()));
        }

        /// <summary>
        /// 资产预算
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "资产预算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetAssetsImportTpl>() { }, "FicoBudgetAssets_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}