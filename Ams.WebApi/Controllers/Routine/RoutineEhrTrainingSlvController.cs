using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 培训
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:39
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrTrainingSlv")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrTrainingSlvController : BaseController
    {
        /// <summary>
        /// 培训接口
        /// </summary>
        private readonly IRoutineEhrTrainingSlvService _RoutineEhrTrainingSlvService;

        public RoutineEhrTrainingSlvController(IRoutineEhrTrainingSlvService RoutineEhrTrainingSlvService)
        {
            _RoutineEhrTrainingSlvService = RoutineEhrTrainingSlvService;
        }

        /// <summary>
        /// 查询培训列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingslv:list")]
        public IActionResult QueryRoutineEhrTrainingSlv([FromQuery] RoutineEhrTrainingSlvQueryDto parm)
        {
            var response = _RoutineEhrTrainingSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询培训详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingslv:query")]
        public IActionResult GetRoutineEhrTrainingSlv(long Id)
        {
            var response = _RoutineEhrTrainingSlvService.GetInfo(Id);
            
            var info = response.Adapt<RoutineEhrTrainingSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加培训
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingslv:add")]
        [Log(Title = "培训", BusinessType = BusinessType.ADD)]
        public IActionResult AddRoutineEhrTrainingSlv([FromBody] RoutineEhrTrainingSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrTrainingSlvService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增培训 '{parm.Id}'失败(Add failed)，输入的培训已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrTrainingSlv>().ToCreate(HttpContext);

            var response = _RoutineEhrTrainingSlvService.AddRoutineEhrTrainingSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新培训
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingslv:edit")]
        [Log(Title = "培训", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateRoutineEhrTrainingSlv([FromBody] RoutineEhrTrainingSlvDto parm)
        {
            var modal = parm.Adapt<RoutineEhrTrainingSlv>().ToUpdate(HttpContext);
            var response = _RoutineEhrTrainingSlvService.UpdateRoutineEhrTrainingSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除培训
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingslv:delete")]
        [Log(Title = "培训", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrTrainingSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrTrainingSlvService.Delete(idArr, "删除培训"));
        }

        /// <summary>
        /// 导出培训
        /// </summary>
        /// <returns></returns>
        [Log(Title = "培训导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingslv:export")]
        public IActionResult Export([FromQuery] RoutineEhrTrainingSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrTrainingSlvService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "培训", "培训");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入培训
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "培训导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<RoutineEhrTrainingSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrTrainingSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrTrainingSlvService.ImportRoutineEhrTrainingSlv(list.Adapt<List<RoutineEhrTrainingSlv>>()));
        }

        /// <summary>
        /// 培训
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "培训模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrTrainingSlvImportTpl>() { }, "RoutineEhrTrainingSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}