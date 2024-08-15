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
    /// @Date: 2024/8/9 13:25:02
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetAssetsMa")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetAssetsMaController : BaseController
    {
        /// <summary>
        /// 资产预算接口
        /// </summary>
        private readonly IFicoBudgetAssetsMaService _FicoBudgetAssetsMaService;

        public FicoBudgetAssetsMaController(IFicoBudgetAssetsMaService FicoBudgetAssetsMaService)
        {
            _FicoBudgetAssetsMaService = FicoBudgetAssetsMaService;
        }

        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetassetsma:list")]
        public IActionResult QueryFicoBudgetAssetsMa([FromQuery] FicoBudgetAssetsMaQueryDto parm)
        {
            var response = _FicoBudgetAssetsMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询资产预算详情
        /// </summary>
        /// <param name="FbaSfId"></param>
        /// <returns></returns>
        [HttpGet("{FbaSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetassetsma:query")]
        public IActionResult GetFicoBudgetAssetsMa(long FbaSfId)
        {
            var response = _FicoBudgetAssetsMaService.GetInfo(FbaSfId);
            
            var info = response.Adapt<FicoBudgetAssetsMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetassetsma:add")]
        [Log(Title = "资产预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetAssetsMa([FromBody] FicoBudgetAssetsMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetAssetsMaService.CheckInputUnique(parm.FbaSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增资产预算 '{parm.FbaSfId}'失败(Add failed)，输入的资产预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetAssetsMa>().ToCreate(HttpContext);

            var response = _FicoBudgetAssetsMaService.AddFicoBudgetAssetsMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetassetsma:edit")]
        [Log(Title = "资产预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetAssetsMa([FromBody] FicoBudgetAssetsMaDto parm)
        {
            var modal = parm.Adapt<FicoBudgetAssetsMa>().ToUpdate(HttpContext);
            var response = _FicoBudgetAssetsMaService.UpdateFicoBudgetAssetsMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除资产预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetassetsma:delete")]
        [Log(Title = "资产预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetAssetsMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetAssetsMaService.Delete(idArr, "删除资产预算"));
        }

        /// <summary>
        /// 导出资产预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "资产预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetassetsma:export")]
        public IActionResult Export([FromQuery] FicoBudgetAssetsMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetAssetsMaService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "fico:budgetassetsma:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetAssetsMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetAssetsMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetAssetsMaService.ImportFicoBudgetAssetsMa(list.Adapt<List<FicoBudgetAssetsMa>>()));
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
            var result = DownloadImportTemplate(new List<FicoBudgetAssetsMaImportTpl>() { }, "FicoBudgetAssetsMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}