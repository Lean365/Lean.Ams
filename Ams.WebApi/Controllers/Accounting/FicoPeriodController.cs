using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 财务期间
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:53
    /// </summary>
    [Verify]
    [Route("Accounting/FicoPeriod")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoPeriodController : BaseController
    {
        /// <summary>
        /// 财务期间接口
        /// </summary>
        private readonly IFicoPeriodService _FicoPeriodService;

        public FicoPeriodController(IFicoPeriodService FicoPeriodService)
        {
            _FicoPeriodService = FicoPeriodService;
        }

        /// <summary>
        /// 查询财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:period:list")]
        public IActionResult QueryFicoPeriod([FromQuery] FicoPeriodQueryDto parm)
        {
            var response = _FicoPeriodService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询财务期间详情
        /// </summary>
        /// <param name="FpSFID"></param>
        /// <returns></returns>
        [HttpGet("{FpSFID}")]
        [ActionPermissionFilter(Permission = "fico:period:query")]
        public IActionResult GetFicoPeriod(long FpSFID)
        {
            var response = _FicoPeriodService.GetInfo(FpSFID);
            
            var info = response.Adapt<FicoPeriodDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加财务期间
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:period:add")]
        [Log(Title = "财务期间", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoPeriod([FromBody] FicoPeriodDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoPeriodService.CheckInputUnique(parm.FpSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增财务期间 '{parm.FpSFID}'失败(Add failed)，输入的财务期间已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoPeriod>().ToCreate(HttpContext);

            var response = _FicoPeriodService.AddFicoPeriod(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新财务期间
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:period:edit")]
        [Log(Title = "财务期间", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoPeriod([FromBody] FicoPeriodDto parm)
        {
            var modal = parm.Adapt<FicoPeriod>().ToUpdate(HttpContext);
            var response = _FicoPeriodService.UpdateFicoPeriod(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除财务期间
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:period:delete")]
        [Log(Title = "财务期间", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoPeriod([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoPeriodService.Delete(idArr, "删除财务期间"));
        }

        /// <summary>
        /// 导出财务期间
        /// </summary>
        /// <returns></returns>
        [Log(Title = "财务期间", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:period:export")]
        public IActionResult Export([FromQuery] FicoPeriodQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoPeriodService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "财务期间", "财务期间");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "财务期间导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:period:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoPeriodDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoPeriodDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoPeriodService.ImportFicoPeriod(list.Adapt<List<FicoPeriod>>()));
        }

        /// <summary>
        /// 财务期间导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "财务期间模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoPeriodImportTpl>() { }, "FicoPeriod_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}