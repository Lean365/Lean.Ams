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
    /// @Date: 2024/9/10 16:57:03
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetOvertime")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetOvertimeController : BaseController
    {
        /// <summary>
        /// 加班预算接口
        /// </summary>
        private readonly IFicoBudgetOvertimeService _FicoBudgetOvertimeService;

        public FicoBudgetOvertimeController(IFicoBudgetOvertimeService FicoBudgetOvertimeService)
        {
            _FicoBudgetOvertimeService = FicoBudgetOvertimeService;
        }

        /// <summary>
        /// 查询加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetovertime:list")]
        public IActionResult QueryFicoBudgetOvertime([FromQuery] FicoBudgetOvertimeQueryDto parm)
        {
            var response = _FicoBudgetOvertimeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询加班预算详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:budgetovertime:query")]
        public IActionResult GetFicoBudgetOvertime(long Id)
        {
            var response = _FicoBudgetOvertimeService.GetInfo(Id);
            
            var info = response.Adapt<FicoBudgetOvertimeDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加加班预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetovertime:add")]
        [Log(Title = "加班预算", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoBudgetOvertime([FromBody] FicoBudgetOvertimeDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetOvertimeService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增加班预算 '{parm.Id}'失败(Add failed)，输入的加班预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetOvertime>().ToCreate(HttpContext);

            var response = _FicoBudgetOvertimeService.AddFicoBudgetOvertime(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新加班预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetovertime:edit")]
        [Log(Title = "加班预算", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoBudgetOvertime([FromBody] FicoBudgetOvertimeDto parm)
        {
            var modal = parm.Adapt<FicoBudgetOvertime>().ToUpdate(HttpContext);
            var response = _FicoBudgetOvertimeService.UpdateFicoBudgetOvertime(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除加班预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetovertime:delete")]
        [Log(Title = "加班预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetOvertime([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetOvertimeService.Delete(idArr, "删除加班预算"));
        }

        /// <summary>
        /// 导出加班预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "加班预算导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetovertime:export")]
        public IActionResult Export([FromQuery] FicoBudgetOvertimeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetOvertimeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "加班预算", "加班预算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入加班预算
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "加班预算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetovertime:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoBudgetOvertimeDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetOvertimeDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetOvertimeService.ImportFicoBudgetOvertime(list.Adapt<List<FicoBudgetOvertime>>()));
        }

        /// <summary>
        /// 加班预算
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "加班预算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetOvertimeImportTpl>() { }, "FicoBudgetOvertime_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}