using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 加班预算
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:44
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetOvertimeMa")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetOvertimeMaController : BaseController
    {
        /// <summary>
        /// 加班预算接口
        /// </summary>
        private readonly IFicoBudgetOvertimeMaService _FicoBudgetOvertimeMaService;

        public FicoBudgetOvertimeMaController(IFicoBudgetOvertimeMaService FicoBudgetOvertimeMaService)
        {
            _FicoBudgetOvertimeMaService = FicoBudgetOvertimeMaService;
        }

        /// <summary>
        /// 查询加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetovertimema:list")]
        public IActionResult QueryFicoBudgetOvertimeMa([FromQuery] FicoBudgetOvertimeMaQueryDto parm)
        {
            var response = _FicoBudgetOvertimeMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询加班预算详情
        /// </summary>
        /// <param name="FboSfId"></param>
        /// <returns></returns>
        [HttpGet("{FboSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetovertimema:query")]
        public IActionResult GetFicoBudgetOvertimeMa(long FboSfId)
        {
            var response = _FicoBudgetOvertimeMaService.GetInfo(FboSfId);
            
            var info = response.Adapt<FicoBudgetOvertimeMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加加班预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetovertimema:add")]
        [Log(Title = "加班预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetOvertimeMa([FromBody] FicoBudgetOvertimeMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetOvertimeMaService.CheckInputUnique(parm.FboSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增加班预算 '{parm.FboSfId}'失败(Add failed)，输入的加班预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetOvertimeMa>().ToCreate(HttpContext);

            var response = _FicoBudgetOvertimeMaService.AddFicoBudgetOvertimeMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新加班预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetovertimema:edit")]
        [Log(Title = "加班预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetOvertimeMa([FromBody] FicoBudgetOvertimeMaDto parm)
        {
            var modal = parm.Adapt<FicoBudgetOvertimeMa>().ToUpdate(HttpContext);
            var response = _FicoBudgetOvertimeMaService.UpdateFicoBudgetOvertimeMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除加班预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetovertimema:delete")]
        [Log(Title = "加班预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetOvertimeMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetOvertimeMaService.Delete(idArr, "删除加班预算"));
        }

        /// <summary>
        /// 导出加班预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "加班预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetovertimema:export")]
        public IActionResult Export([FromQuery] FicoBudgetOvertimeMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetOvertimeMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "加班预算", "加班预算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "加班预算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetovertimema:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetOvertimeMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetOvertimeMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetOvertimeMaService.ImportFicoBudgetOvertimeMa(list.Adapt<List<FicoBudgetOvertimeMa>>()));
        }

        /// <summary>
        /// 加班预算导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "加班预算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetOvertimeMaImportTpl>() { }, "FicoBudgetOvertimeMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}