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
    /// @Date: 2024/10/14 13:41:08
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetStaff")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetStaffController : BaseController
    {
        /// <summary>
        /// 人员预算接口
        /// </summary>
        private readonly IFicoBudgetStaffService _FicoBudgetStaffService;

        public FicoBudgetStaffController(IFicoBudgetStaffService FicoBudgetStaffService)
        {
            _FicoBudgetStaffService = FicoBudgetStaffService;
        }

        /// <summary>
        /// 查询人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetstaff:list")]
        public IActionResult QueryFicoBudgetStaff([FromQuery] FicoBudgetStaffQueryDto parm)
        {
            var response = _FicoBudgetStaffService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询人员预算详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:budgetstaff:query")]
        public IActionResult GetFicoBudgetStaff(long Id)
        {
            var response = _FicoBudgetStaffService.GetInfo(Id);
            
            var info = response.Adapt<FicoBudgetStaffDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加人员预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetstaff:add")]
        [Log(Title = "人员预算", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoBudgetStaff([FromBody] FicoBudgetStaffDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetStaffService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增人员预算 '{parm.Id}'失败(Add failed)，输入的人员预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetStaff>().ToCreate(HttpContext);

            var response = _FicoBudgetStaffService.AddFicoBudgetStaff(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新人员预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetstaff:edit")]
        [Log(Title = "人员预算", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoBudgetStaff([FromBody] FicoBudgetStaffDto parm)
        {
            var modal = parm.Adapt<FicoBudgetStaff>().ToUpdate(HttpContext);
            var response = _FicoBudgetStaffService.UpdateFicoBudgetStaff(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除人员预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetstaff:delete")]
        [Log(Title = "人员预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetStaff([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetStaffService.Delete(idArr, "删除人员预算"));
        }

        /// <summary>
        /// 导出人员预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "人员预算导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetstaff:export")]
        public IActionResult Export([FromQuery] FicoBudgetStaffQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetStaffService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "人员预算", "人员预算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入人员预算
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "人员预算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetstaff:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoBudgetStaffDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetStaffDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetStaffService.ImportFicoBudgetStaff(list.Adapt<List<FicoBudgetStaff>>()));
        }

        /// <summary>
        /// 人员预算
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "人员预算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetStaffImportTpl>() { }, "FicoBudgetStaff_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}