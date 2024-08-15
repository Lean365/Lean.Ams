using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 人员预算
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:30:08
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetStaffMa")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetStaffMaController : BaseController
    {
        /// <summary>
        /// 人员预算接口
        /// </summary>
        private readonly IFicoBudgetStaffMaService _FicoBudgetStaffMaService;

        public FicoBudgetStaffMaController(IFicoBudgetStaffMaService FicoBudgetStaffMaService)
        {
            _FicoBudgetStaffMaService = FicoBudgetStaffMaService;
        }

        /// <summary>
        /// 查询人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetstaffma:list")]
        public IActionResult QueryFicoBudgetStaffMa([FromQuery] FicoBudgetStaffMaQueryDto parm)
        {
            var response = _FicoBudgetStaffMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询人员预算详情
        /// </summary>
        /// <param name="FbsSfId"></param>
        /// <returns></returns>
        [HttpGet("{FbsSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetstaffma:query")]
        public IActionResult GetFicoBudgetStaffMa(long FbsSfId)
        {
            var response = _FicoBudgetStaffMaService.GetInfo(FbsSfId);
            
            var info = response.Adapt<FicoBudgetStaffMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加人员预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetstaffma:add")]
        [Log(Title = "人员预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetStaffMa([FromBody] FicoBudgetStaffMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetStaffMaService.CheckInputUnique(parm.FbsSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增人员预算 '{parm.FbsSfId}'失败(Add failed)，输入的人员预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetStaffMa>().ToCreate(HttpContext);

            var response = _FicoBudgetStaffMaService.AddFicoBudgetStaffMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新人员预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetstaffma:edit")]
        [Log(Title = "人员预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetStaffMa([FromBody] FicoBudgetStaffMaDto parm)
        {
            var modal = parm.Adapt<FicoBudgetStaffMa>().ToUpdate(HttpContext);
            var response = _FicoBudgetStaffMaService.UpdateFicoBudgetStaffMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除人员预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetstaffma:delete")]
        [Log(Title = "人员预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetStaffMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetStaffMaService.Delete(idArr, "删除人员预算"));
        }

        /// <summary>
        /// 导出人员预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "人员预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetstaffma:export")]
        public IActionResult Export([FromQuery] FicoBudgetStaffMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetStaffMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "人员预算", "人员预算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "人员预算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetstaffma:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetStaffMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetStaffMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetStaffMaService.ImportFicoBudgetStaffMa(list.Adapt<List<FicoBudgetStaffMa>>()));
        }

        /// <summary>
        /// 人员预算导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "人员预算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetStaffMaImportTpl>() { }, "FicoBudgetStaffMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}