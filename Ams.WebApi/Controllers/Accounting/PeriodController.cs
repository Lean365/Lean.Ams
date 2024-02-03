using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 财务期间
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:02:36)
    /// </summary>
    [Verify]
    [Route("accounting/Period")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class PeriodController : BaseController
    {
        /// <summary>
        /// 财务期间接口
        /// </summary>
        private readonly IPeriodService _PeriodService;

        public PeriodController(IPeriodService PeriodService)
        {
            _PeriodService = PeriodService;
        }

        /// <summary>
        /// 查询财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:period:list")]
        public IActionResult QueryPeriod([FromQuery] PeriodQueryDto parm)
        {
            var response = _PeriodService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询财务期间详情
        /// </summary>
        /// <param name="FpSFID"></param>
        /// <returns></returns>
        [HttpGet("{FpSFID}")]
        [ActionPermissionFilter(Permission = "fico:period:query")]
        public IActionResult GetPeriod(long FpSFID)
        {
            var response = _PeriodService.GetInfo(FpSFID);
            
            var info = response.Adapt<PeriodDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加财务期间
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:period:add")]
        [Log(Title = "财务期间", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPeriod([FromBody] PeriodDto parm)
        {
            var modal = parm.Adapt<Period>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_PeriodService.CheckEntryUnique(parm.FpSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)财务期间 '{parm.FpSFID}'失败(failed)，输入的(The entered)财务期间已存在(already exists)"));
            }
            var response = _PeriodService.AddPeriod(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新财务期间
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:period:edit")]
        [Log(Title = "财务期间", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePeriod([FromBody] PeriodDto parm)
        {
            var modal = parm.Adapt<Period>().ToUpdate(HttpContext);
            var response = _PeriodService.UpdatePeriod(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除财务期间
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:period:delete")]
        [Log(Title = "财务期间", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePeriod([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PeriodService.Delete(idArr, "删除财务期间"));
        }

        /// <summary>
        /// 导出财务期间
        /// </summary>
        /// <returns></returns>
        [Log(Title = "财务期间", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:period:export")]
        public IActionResult Export([FromQuery] PeriodQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PeriodService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "财务期间", "财务期间","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入财务期间
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "财务期间导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:period:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PeriodDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PeriodDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PeriodService.ImportPeriod(list.Adapt<List<Period>>()));
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
            var result = DownloadImportTemplate(new List<PeriodDto>() { }, "PeriodTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}