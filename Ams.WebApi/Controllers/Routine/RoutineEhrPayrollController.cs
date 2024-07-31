using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 薪资
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:32:33
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrPayroll")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrPayrollController : BaseController
    {
        /// <summary>
        /// 薪资接口
        /// </summary>
        private readonly IRoutineEhrPayrollService _RoutineEhrPayrollService;

        public RoutineEhrPayrollController(IRoutineEhrPayrollService RoutineEhrPayrollService)
        {
            _RoutineEhrPayrollService = RoutineEhrPayrollService;
        }

        /// <summary>
        /// 查询薪资列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrpayroll:list")]
        public IActionResult QueryRoutineEhrPayroll([FromQuery] RoutineEhrPayrollQueryDto parm)
        {
            var response = _RoutineEhrPayrollService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询薪资详情
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        [HttpGet("{EeSfId}")]
        [ActionPermissionFilter(Permission = "routine:ehrpayroll:query")]
        public IActionResult GetRoutineEhrPayroll(long EeSfId)
        {
            var response = _RoutineEhrPayrollService.GetInfo(EeSfId);
            
            var info = response.Adapt<RoutineEhrPayrollDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加薪资
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrpayroll:add")]
        [Log(Title = "薪资", BusinessType = BusinessType.INSERT)]
        public IActionResult AddRoutineEhrPayroll([FromBody] RoutineEhrPayrollDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrPayrollService.CheckInputUnique(parm.EeSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增薪资 '{parm.EeSfId}'失败(Add failed)，输入的薪资已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrPayroll>().ToCreate(HttpContext);

            var response = _RoutineEhrPayrollService.AddRoutineEhrPayroll(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新薪资
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrpayroll:edit")]
        [Log(Title = "薪资", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateRoutineEhrPayroll([FromBody] RoutineEhrPayrollDto parm)
        {
            var modal = parm.Adapt<RoutineEhrPayroll>().ToUpdate(HttpContext);
            var response = _RoutineEhrPayrollService.UpdateRoutineEhrPayroll(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除薪资
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrpayroll:delete")]
        [Log(Title = "薪资", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrPayroll([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrPayrollService.Delete(idArr, "删除薪资"));
        }

        /// <summary>
        /// 导出薪资
        /// </summary>
        /// <returns></returns>
        [Log(Title = "薪资", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrpayroll:export")]
        public IActionResult Export([FromQuery] RoutineEhrPayrollQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrPayrollService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "薪资", "薪资");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "薪资导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrpayroll:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<RoutineEhrPayrollDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrPayrollDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrPayrollService.ImportRoutineEhrPayroll(list.Adapt<List<RoutineEhrPayroll>>()));
        }

        /// <summary>
        /// 薪资导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "薪资模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrPayrollImportTpl>() { }, "RoutineEhrPayroll_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}