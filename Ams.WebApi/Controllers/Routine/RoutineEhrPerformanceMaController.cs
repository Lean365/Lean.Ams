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
    /// @Date: 2024/8/9 17:21:08
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrPerformanceMa")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrPerformanceMaController : BaseController
    {
        /// <summary>
        /// 绩效接口
        /// </summary>
        private readonly IRoutineEhrPerformanceMaService _RoutineEhrPerformanceMaService;

        public RoutineEhrPerformanceMaController(IRoutineEhrPerformanceMaService RoutineEhrPerformanceMaService)
        {
            _RoutineEhrPerformanceMaService = RoutineEhrPerformanceMaService;
        }

        /// <summary>
        /// 查询绩效列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrperformancema:list")]
        public IActionResult QueryRoutineEhrPerformanceMa([FromQuery] RoutineEhrPerformanceMaQueryDto parm)
        {
            var response = _RoutineEhrPerformanceMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询绩效详情
        /// </summary>
        /// <param name="EpSfId"></param>
        /// <returns></returns>
        [HttpGet("{EpSfId}")]
        [ActionPermissionFilter(Permission = "routine:ehrperformancema:query")]
        public IActionResult GetRoutineEhrPerformanceMa(long EpSfId)
        {
            var response = _RoutineEhrPerformanceMaService.GetInfo(EpSfId);
            
            var info = response.Adapt<RoutineEhrPerformanceMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加绩效
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrperformancema:add")]
        [Log(Title = "绩效", BusinessType = BusinessType.INSERT)]
        public IActionResult AddRoutineEhrPerformanceMa([FromBody] RoutineEhrPerformanceMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrPerformanceMaService.CheckInputUnique(parm.EpSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增绩效 '{parm.EpSfId}'失败(Add failed)，输入的绩效已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrPerformanceMa>().ToCreate(HttpContext);

            var response = _RoutineEhrPerformanceMaService.AddRoutineEhrPerformanceMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新绩效
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrperformancema:edit")]
        [Log(Title = "绩效", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateRoutineEhrPerformanceMa([FromBody] RoutineEhrPerformanceMaDto parm)
        {
            var modal = parm.Adapt<RoutineEhrPerformanceMa>().ToUpdate(HttpContext);
            var response = _RoutineEhrPerformanceMaService.UpdateRoutineEhrPerformanceMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除绩效
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrperformancema:delete")]
        [Log(Title = "绩效", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrPerformanceMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrPerformanceMaService.Delete(idArr, "删除绩效"));
        }

        /// <summary>
        /// 导出绩效
        /// </summary>
        /// <returns></returns>
        [Log(Title = "绩效", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrperformancema:export")]
        public IActionResult Export([FromQuery] RoutineEhrPerformanceMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrPerformanceMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "绩效", "绩效");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "绩效导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrperformancema:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<RoutineEhrPerformanceMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrPerformanceMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrPerformanceMaService.ImportRoutineEhrPerformanceMa(list.Adapt<List<RoutineEhrPerformanceMa>>()));
        }

        /// <summary>
        /// 绩效导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "绩效模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrPerformanceMaImportTpl>() { }, "RoutineEhrPerformanceMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}