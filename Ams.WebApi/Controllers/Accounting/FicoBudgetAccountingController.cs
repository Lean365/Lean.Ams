using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 预算科目
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/15 17:17:38
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetAccounting")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetAccountingController : BaseController
    {
        /// <summary>
        /// 预算科目接口
        /// </summary>
        private readonly IFicoBudgetAccountingService _FicoBudgetAccountingService;

        public FicoBudgetAccountingController(IFicoBudgetAccountingService FicoBudgetAccountingService)
        {
            _FicoBudgetAccountingService = FicoBudgetAccountingService;
        }

        /// <summary>
        /// 查询预算科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetaccounting:list")]
        public IActionResult QueryFicoBudgetAccounting([FromQuery] FicoBudgetAccountingQueryDto parm)
        {
            var response = _FicoBudgetAccountingService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询预算科目列表树
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("treeList")]
        [ActionPermissionFilter(Permission = "fico:budgetaccounting:list")]
        public IActionResult QueryTreeFicoBudgetAccounting([FromQuery] FicoBudgetAccountingQueryDto parm)
        {
            var response = _FicoBudgetAccountingService.GetTreeList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 获取预算科目下拉树列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("treeselect")]
        public IActionResult BudgetAccountingTreeSelect(FicoBudgetAccountingQueryDto parm)
        {
            var parms = _FicoBudgetAccountingService.GetBudgetAccountings(parm);

            return SUCCESS(_FicoBudgetAccountingService.BuildBudgetAccountingTreeSelect(parms), TIME_FORMAT_FULL);
        }

        /// <summary>
        /// 查询预算科目详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:budgetaccounting:query")]
        public IActionResult GetFicoBudgetAccounting(long Id)
        {
            var response = _FicoBudgetAccountingService.GetInfo(Id);

            var info = response.Adapt<FicoBudgetAccountingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加预算科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetaccounting:add")]
        [Log(Title = "预算科目", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoBudgetAccounting([FromBody] FicoBudgetAccountingDto parm)
        {
            // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetAccountingService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增预算科目 '{parm.Id}'失败(Add failed)，输入的预算科目已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetAccounting>().ToCreate(HttpContext);

            var response = _FicoBudgetAccountingService.AddFicoBudgetAccounting(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新预算科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetaccounting:edit")]
        [Log(Title = "预算科目", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoBudgetAccounting([FromBody] FicoBudgetAccountingDto parm)
        {
            var modal = parm.Adapt<FicoBudgetAccounting>().ToUpdate(HttpContext);
            var response = _FicoBudgetAccountingService.UpdateFicoBudgetAccounting(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除预算科目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetaccounting:delete")]
        [Log(Title = "预算科目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetAccounting([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetAccountingService.Delete(idArr, "删除预算科目"));
        }

        /// <summary>
        /// 导出预算科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "预算科目导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetaccounting:export")]
        public IActionResult Export([FromQuery] FicoBudgetAccountingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetAccountingService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "预算科目", "预算科目");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入预算科目
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "预算科目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetaccounting:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoBudgetAccountingDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetAccountingDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetAccountingService.ImportFicoBudgetAccounting(list.Adapt<List<FicoBudgetAccounting>>()));
        }

        /// <summary>
        /// 预算科目
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "预算科目模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetAccountingImportTpl>() { }, "FicoBudgetAccounting_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}