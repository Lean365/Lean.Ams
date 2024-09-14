using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 考勤
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:26:15
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrAttendance")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrAttendanceController : BaseController
    {
        /// <summary>
        /// 考勤接口
        /// </summary>
        private readonly IRoutineEhrAttendanceService _RoutineEhrAttendanceService;

        public RoutineEhrAttendanceController(IRoutineEhrAttendanceService RoutineEhrAttendanceService)
        {
            _RoutineEhrAttendanceService = RoutineEhrAttendanceService;
        }

        /// <summary>
        /// 查询考勤列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrattendance:list")]
        public IActionResult QueryRoutineEhrAttendance([FromQuery] RoutineEhrAttendanceQueryDto parm)
        {
            var response = _RoutineEhrAttendanceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询考勤详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:ehrattendance:query")]
        public IActionResult GetRoutineEhrAttendance(long Id)
        {
            var response = _RoutineEhrAttendanceService.GetInfo(Id);
            
            var info = response.Adapt<RoutineEhrAttendanceDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加考勤
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrattendance:add")]
        [Log(Title = "考勤", BusinessType = BusinessType.ADD)]
        public IActionResult AddRoutineEhrAttendance([FromBody] RoutineEhrAttendanceDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrAttendanceService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增考勤 '{parm.Id}'失败(Add failed)，输入的考勤已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrAttendance>().ToCreate(HttpContext);

            var response = _RoutineEhrAttendanceService.AddRoutineEhrAttendance(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新考勤
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrattendance:edit")]
        [Log(Title = "考勤", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateRoutineEhrAttendance([FromBody] RoutineEhrAttendanceDto parm)
        {
            var modal = parm.Adapt<RoutineEhrAttendance>().ToUpdate(HttpContext);
            var response = _RoutineEhrAttendanceService.UpdateRoutineEhrAttendance(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除考勤
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrattendance:delete")]
        [Log(Title = "考勤", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrAttendance([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrAttendanceService.Delete(idArr, "删除考勤"));
        }

        /// <summary>
        /// 导出考勤
        /// </summary>
        /// <returns></returns>
        [Log(Title = "考勤导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrattendance:export")]
        public IActionResult Export([FromQuery] RoutineEhrAttendanceQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrAttendanceService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "考勤", "考勤");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入考勤
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "考勤导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrattendance:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<RoutineEhrAttendanceDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrAttendanceDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrAttendanceService.ImportRoutineEhrAttendance(list.Adapt<List<RoutineEhrAttendance>>()));
        }

        /// <summary>
        /// 考勤
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "考勤模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrAttendanceImportTpl>() { }, "RoutineEhrAttendance_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}