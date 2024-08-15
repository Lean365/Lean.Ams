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
    /// @Date: 2024/8/9 12:06:46
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetOvertimeSlv")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetOvertimeSlvController : BaseController
    {
        /// <summary>
        /// 加班预算接口
        /// </summary>
        private readonly IFicoBudgetOvertimeSlvService _FicoBudgetOvertimeSlvService;

        public FicoBudgetOvertimeSlvController(IFicoBudgetOvertimeSlvService FicoBudgetOvertimeSlvService)
        {
            _FicoBudgetOvertimeSlvService = FicoBudgetOvertimeSlvService;
        }

        /// <summary>
        /// 查询加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetovertimeslv:list")]
        public IActionResult QueryFicoBudgetOvertimeSlv([FromQuery] FicoBudgetOvertimeSlvQueryDto parm)
        {
            var response = _FicoBudgetOvertimeSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询加班预算详情
        /// </summary>
        /// <param name="FbosSfId"></param>
        /// <returns></returns>
        [HttpGet("{FbosSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetovertimeslv:query")]
        public IActionResult GetFicoBudgetOvertimeSlv(long FbosSfId)
        {
            var response = _FicoBudgetOvertimeSlvService.GetInfo(FbosSfId);
            
            var info = response.Adapt<FicoBudgetOvertimeSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加加班预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetovertimeslv:add")]
        [Log(Title = "加班预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetOvertimeSlv([FromBody] FicoBudgetOvertimeSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetOvertimeSlvService.CheckInputUnique(parm.FbosSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增加班预算 '{parm.FbosSfId}'失败(Add failed)，输入的加班预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetOvertimeSlv>().ToCreate(HttpContext);

            var response = _FicoBudgetOvertimeSlvService.AddFicoBudgetOvertimeSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新加班预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetovertimeslv:edit")]
        [Log(Title = "加班预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetOvertimeSlv([FromBody] FicoBudgetOvertimeSlvDto parm)
        {
            var modal = parm.Adapt<FicoBudgetOvertimeSlv>().ToUpdate(HttpContext);
            var response = _FicoBudgetOvertimeSlvService.UpdateFicoBudgetOvertimeSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除加班预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetovertimeslv:delete")]
        [Log(Title = "加班预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetOvertimeSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetOvertimeSlvService.Delete(idArr, "删除加班预算"));
        }

        /// <summary>
        /// 导出加班预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "加班预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetovertimeslv:export")]
        public IActionResult Export([FromQuery] FicoBudgetOvertimeSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetOvertimeSlvService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "fico:budgetovertimeslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetOvertimeSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetOvertimeSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetOvertimeSlvService.ImportFicoBudgetOvertimeSlv(list.Adapt<List<FicoBudgetOvertimeSlv>>()));
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
            var result = DownloadImportTemplate(new List<FicoBudgetOvertimeSlvImportTpl>() { }, "FicoBudgetOvertimeSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}