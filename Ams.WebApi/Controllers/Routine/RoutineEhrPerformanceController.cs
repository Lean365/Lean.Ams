using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 绩效
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 9:40:38
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrPerformance")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrPerformanceController : BaseController
    {
        /// <summary>
        /// 绩效接口
        /// </summary>
        private readonly IRoutineEhrPerformanceService _RoutineEhrPerformanceService;

        public RoutineEhrPerformanceController(IRoutineEhrPerformanceService RoutineEhrPerformanceService)
        {
            _RoutineEhrPerformanceService = RoutineEhrPerformanceService;
        }

        /// <summary>
        /// 查询绩效列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrperformance:list")]
        public IActionResult QueryRoutineEhrPerformance([FromQuery] RoutineEhrPerformanceQueryDto parm)
        {
            var response = _RoutineEhrPerformanceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询绩效详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:ehrperformance:query")]
        public IActionResult GetRoutineEhrPerformance(long Id)
        {
            var response = _RoutineEhrPerformanceService.GetInfo(Id);
            
            var info = response.Adapt<RoutineEhrPerformanceDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加绩效
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrperformance:add")]
        [Log(Title = "绩效", BusinessType = BusinessType.ADD)]
        public IActionResult AddRoutineEhrPerformance([FromBody] RoutineEhrPerformanceDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrPerformanceService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增绩效 '{parm.Id}'失败(Add failed)，输入的绩效已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrPerformance>().ToCreate(HttpContext);

            var response = _RoutineEhrPerformanceService.AddRoutineEhrPerformance(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新绩效
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrperformance:edit")]
        [Log(Title = "绩效", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateRoutineEhrPerformance([FromBody] RoutineEhrPerformanceDto parm)
        {
            var modal = parm.Adapt<RoutineEhrPerformance>().ToUpdate(HttpContext);
            var response = _RoutineEhrPerformanceService.UpdateRoutineEhrPerformance(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除绩效
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrperformance:delete")]
        [Log(Title = "绩效", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrPerformance([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrPerformanceService.Delete(idArr, "删除绩效"));
        }

        /// <summary>
        /// 导出绩效
        /// </summary>
        /// <returns></returns>
        [Log(Title = "绩效导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrperformance:export")]
        public IActionResult Export([FromQuery] RoutineEhrPerformanceQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrPerformanceService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "绩效", "绩效");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入绩效
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "绩效导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrperformance:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<RoutineEhrPerformanceDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrPerformanceDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrPerformanceService.ImportRoutineEhrPerformance(list.Adapt<List<RoutineEhrPerformance>>()));
        }

        /// <summary>
        /// 绩效
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "绩效模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrPerformanceImportTpl>() { }, "RoutineEhrPerformance_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}