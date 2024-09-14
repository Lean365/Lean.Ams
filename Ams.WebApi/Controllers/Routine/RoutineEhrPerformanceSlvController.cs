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
    /// @Date: 2024/9/12 16:38:43
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrPerformanceSlv")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrPerformanceSlvController : BaseController
    {
        /// <summary>
        /// 绩效接口
        /// </summary>
        private readonly IRoutineEhrPerformanceSlvService _RoutineEhrPerformanceSlvService;

        public RoutineEhrPerformanceSlvController(IRoutineEhrPerformanceSlvService RoutineEhrPerformanceSlvService)
        {
            _RoutineEhrPerformanceSlvService = RoutineEhrPerformanceSlvService;
        }

        /// <summary>
        /// 查询绩效列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrperformanceslv:list")]
        public IActionResult QueryRoutineEhrPerformanceSlv([FromQuery] RoutineEhrPerformanceSlvQueryDto parm)
        {
            var response = _RoutineEhrPerformanceSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询绩效详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:ehrperformanceslv:query")]
        public IActionResult GetRoutineEhrPerformanceSlv(long Id)
        {
            var response = _RoutineEhrPerformanceSlvService.GetInfo(Id);
            
            var info = response.Adapt<RoutineEhrPerformanceSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加绩效
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrperformanceslv:add")]
        [Log(Title = "绩效", BusinessType = BusinessType.ADD)]
        public IActionResult AddRoutineEhrPerformanceSlv([FromBody] RoutineEhrPerformanceSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrPerformanceSlvService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增绩效 '{parm.Id}'失败(Add failed)，输入的绩效已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrPerformanceSlv>().ToCreate(HttpContext);

            var response = _RoutineEhrPerformanceSlvService.AddRoutineEhrPerformanceSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新绩效
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrperformanceslv:edit")]
        [Log(Title = "绩效", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateRoutineEhrPerformanceSlv([FromBody] RoutineEhrPerformanceSlvDto parm)
        {
            var modal = parm.Adapt<RoutineEhrPerformanceSlv>().ToUpdate(HttpContext);
            var response = _RoutineEhrPerformanceSlvService.UpdateRoutineEhrPerformanceSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除绩效
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrperformanceslv:delete")]
        [Log(Title = "绩效", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrPerformanceSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrPerformanceSlvService.Delete(idArr, "删除绩效"));
        }

        /// <summary>
        /// 导出绩效
        /// </summary>
        /// <returns></returns>
        [Log(Title = "绩效导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrperformanceslv:export")]
        public IActionResult Export([FromQuery] RoutineEhrPerformanceSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrPerformanceSlvService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "routine:ehrperformanceslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<RoutineEhrPerformanceSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrPerformanceSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrPerformanceSlvService.ImportRoutineEhrPerformanceSlv(list.Adapt<List<RoutineEhrPerformanceSlv>>()));
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
            var result = DownloadImportTemplate(new List<RoutineEhrPerformanceSlvImportTpl>() { }, "RoutineEhrPerformanceSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}