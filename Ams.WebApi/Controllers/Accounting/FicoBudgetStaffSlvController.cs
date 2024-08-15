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
    /// @Date: 2024/8/9 13:28:59
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetStaffSlv")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetStaffSlvController : BaseController
    {
        /// <summary>
        /// 人员预算接口
        /// </summary>
        private readonly IFicoBudgetStaffSlvService _FicoBudgetStaffSlvService;

        public FicoBudgetStaffSlvController(IFicoBudgetStaffSlvService FicoBudgetStaffSlvService)
        {
            _FicoBudgetStaffSlvService = FicoBudgetStaffSlvService;
        }

        /// <summary>
        /// 查询人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetstaffslv:list")]
        public IActionResult QueryFicoBudgetStaffSlv([FromQuery] FicoBudgetStaffSlvQueryDto parm)
        {
            var response = _FicoBudgetStaffSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询人员预算详情
        /// </summary>
        /// <param name="FbssSfId"></param>
        /// <returns></returns>
        [HttpGet("{FbssSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetstaffslv:query")]
        public IActionResult GetFicoBudgetStaffSlv(long FbssSfId)
        {
            var response = _FicoBudgetStaffSlvService.GetInfo(FbssSfId);
            
            var info = response.Adapt<FicoBudgetStaffSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加人员预算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetstaffslv:add")]
        [Log(Title = "人员预算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetStaffSlv([FromBody] FicoBudgetStaffSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetStaffSlvService.CheckInputUnique(parm.FbssSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增人员预算 '{parm.FbssSfId}'失败(Add failed)，输入的人员预算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetStaffSlv>().ToCreate(HttpContext);

            var response = _FicoBudgetStaffSlvService.AddFicoBudgetStaffSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新人员预算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetstaffslv:edit")]
        [Log(Title = "人员预算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetStaffSlv([FromBody] FicoBudgetStaffSlvDto parm)
        {
            var modal = parm.Adapt<FicoBudgetStaffSlv>().ToUpdate(HttpContext);
            var response = _FicoBudgetStaffSlvService.UpdateFicoBudgetStaffSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除人员预算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetstaffslv:delete")]
        [Log(Title = "人员预算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetStaffSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetStaffSlvService.Delete(idArr, "删除人员预算"));
        }

        /// <summary>
        /// 导出人员预算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "人员预算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetstaffslv:export")]
        public IActionResult Export([FromQuery] FicoBudgetStaffSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetStaffSlvService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "fico:budgetstaffslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetStaffSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetStaffSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetStaffSlvService.ImportFicoBudgetStaffSlv(list.Adapt<List<FicoBudgetStaffSlv>>()));
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
            var result = DownloadImportTemplate(new List<FicoBudgetStaffSlvImportTpl>() { }, "FicoBudgetStaffSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}