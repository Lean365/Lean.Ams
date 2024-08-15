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
    /// @Date: 2024/8/9 13:23:49
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetAssetsSlv")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetAssetsSlvController : BaseController
    {
        /// <summary>
        /// 资产预算接口
        /// </summary>
        private readonly IFicoBudgetAssetsSlvService _FicoBudgetAssetsSlvService;

        public FicoBudgetAssetsSlvController(IFicoBudgetAssetsSlvService FicoBudgetAssetsSlvService)
        {
            _FicoBudgetAssetsSlvService = FicoBudgetAssetsSlvService;
        }

        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetassetsslv:list")]
        public IActionResult QueryFicoBudgetAssetsSlv([FromQuery] FicoBudgetAssetsSlvQueryDto parm)
        {
            var response = _FicoBudgetAssetsSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询资产预算详情
        /// </summary>
        /// <param name="FbasSfId"></param>
        /// <returns></returns>
        [HttpGet("{FbasSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetassetsslv:query")]
        public IActionResult GetFicoBudgetAssetsSlv(long FbasSfId)
        {
            var response = _FicoBudgetAssetsSlvService.GetInfo(FbasSfId);
            
            var info = response.Adapt<FicoBudgetAssetsSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetassetsslv:add")]
        [Log(Title = "资产预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetAssetsSlv([FromBody] FicoBudgetAssetsSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetAssetsSlvService.CheckInputUnique(parm.FbasSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增资产预算 '{parm.FbasSfId}'失败(Add failed)，输入的资产预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetAssetsSlv>().ToCreate(HttpContext);

            var response = _FicoBudgetAssetsSlvService.AddFicoBudgetAssetsSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新资产预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetassetsslv:edit")]
        [Log(Title = "资产预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetAssetsSlv([FromBody] FicoBudgetAssetsSlvDto parm)
        {
            var modal = parm.Adapt<FicoBudgetAssetsSlv>().ToUpdate(HttpContext);
            var response = _FicoBudgetAssetsSlvService.UpdateFicoBudgetAssetsSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除资产预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetassetsslv:delete")]
        [Log(Title = "资产预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetAssetsSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetAssetsSlvService.Delete(idArr, "删除资产预算"));
        }

        /// <summary>
        /// 导出资产预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "资产预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetassetsslv:export")]
        public IActionResult Export([FromQuery] FicoBudgetAssetsSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetAssetsSlvService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "fico:budgetassetsslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetAssetsSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetAssetsSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetAssetsSlvService.ImportFicoBudgetAssetsSlv(list.Adapt<List<FicoBudgetAssetsSlv>>()));
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
            var result = DownloadImportTemplate(new List<FicoBudgetAssetsSlvImportTpl>() { }, "FicoBudgetAssetsSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}