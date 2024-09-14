using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 实际对比
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 14:38:54
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetActualCont")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetActualContController : BaseController
    {
        /// <summary>
        /// 实际对比接口
        /// </summary>
        private readonly IFicoBudgetActualContService _FicoBudgetActualContService;

        public FicoBudgetActualContController(IFicoBudgetActualContService FicoBudgetActualContService)
        {
            _FicoBudgetActualContService = FicoBudgetActualContService;
        }

        /// <summary>
        /// 查询实际对比列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcont:list")]
        public IActionResult QueryFicoBudgetActualCont([FromQuery] FicoBudgetActualContQueryDto parm)
        {
            var response = _FicoBudgetActualContService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询实际对比详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcont:query")]
        public IActionResult GetFicoBudgetActualCont(long Id)
        {
            var response = _FicoBudgetActualContService.GetInfo(Id);
            
            var info = response.Adapt<FicoBudgetActualContDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加实际对比
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetactualcont:add")]
        [Log(Title = "实际对比", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoBudgetActualCont([FromBody] FicoBudgetActualContDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetActualContService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增实际对比 '{parm.Id}'失败(Add failed)，输入的实际对比已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetActualCont>().ToCreate(HttpContext);

            var response = _FicoBudgetActualContService.AddFicoBudgetActualCont(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新实际对比
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetactualcont:edit")]
        [Log(Title = "实际对比", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoBudgetActualCont([FromBody] FicoBudgetActualContDto parm)
        {
            var modal = parm.Adapt<FicoBudgetActualCont>().ToUpdate(HttpContext);
            var response = _FicoBudgetActualContService.UpdateFicoBudgetActualCont(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除实际对比
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcont:delete")]
        [Log(Title = "实际对比", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetActualCont([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetActualContService.Delete(idArr, "删除实际对比"));
        }

        /// <summary>
        /// 导出实际对比
        /// </summary>
        /// <returns></returns>
        [Log(Title = "实际对比导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcont:export")]
        public IActionResult Export([FromQuery] FicoBudgetActualContQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetActualContService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "实际对比", "实际对比");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入实际对比
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "实际对比导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetactualcont:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoBudgetActualContDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetActualContDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetActualContService.ImportFicoBudgetActualCont(list.Adapt<List<FicoBudgetActualCont>>()));
        }

        /// <summary>
        /// 实际对比
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "实际对比模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetActualContImportTpl>() { }, "FicoBudgetActualCont_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}