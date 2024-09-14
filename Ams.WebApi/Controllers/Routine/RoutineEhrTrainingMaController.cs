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
    /// @Date: 2024/9/12 15:13:49
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrTrainingMa")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrTrainingMaController : BaseController
    {
        /// <summary>
        /// 培训接口
        /// </summary>
        private readonly IRoutineEhrTrainingMaService _RoutineEhrTrainingMaService;

        public RoutineEhrTrainingMaController(IRoutineEhrTrainingMaService RoutineEhrTrainingMaService)
        {
            _RoutineEhrTrainingMaService = RoutineEhrTrainingMaService;
        }

        /// <summary>
        /// 查询培训列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingma:list")]
        public IActionResult QueryRoutineEhrTrainingMa([FromQuery] RoutineEhrTrainingMaQueryDto parm)
        {
            var response = _RoutineEhrTrainingMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询培训详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingma:query")]
        public IActionResult GetRoutineEhrTrainingMa(long Id)
        {
            var response = _RoutineEhrTrainingMaService.GetInfo(Id);
            
            var info = response.Adapt<RoutineEhrTrainingMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加培训
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingma:add")]
        [Log(Title = "培训", BusinessType = BusinessType.ADD)]
        public IActionResult AddRoutineEhrTrainingMa([FromBody] RoutineEhrTrainingMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrTrainingMaService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增培训 '{parm.Id}'失败(Add failed)，输入的培训已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrTrainingMa>().ToCreate(HttpContext);

            var response = _RoutineEhrTrainingMaService.AddRoutineEhrTrainingMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新培训
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingma:edit")]
        [Log(Title = "培训", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateRoutineEhrTrainingMa([FromBody] RoutineEhrTrainingMaDto parm)
        {
            var modal = parm.Adapt<RoutineEhrTrainingMa>().ToUpdate(HttpContext);
            var response = _RoutineEhrTrainingMaService.UpdateRoutineEhrTrainingMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除培训
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingma:delete")]
        [Log(Title = "培训", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrTrainingMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrTrainingMaService.Delete(idArr, "删除培训"));
        }

        /// <summary>
        /// 导出培训
        /// </summary>
        /// <returns></returns>
        [Log(Title = "培训导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrtrainingma:export")]
        public IActionResult Export([FromQuery] RoutineEhrTrainingMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrTrainingMaService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "routine:ehrtrainingma:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<RoutineEhrTrainingMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrTrainingMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrTrainingMaService.ImportRoutineEhrTrainingMa(list.Adapt<List<RoutineEhrTrainingMa>>()));
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
            var result = DownloadImportTemplate(new List<RoutineEhrTrainingMaImportTpl>() { }, "RoutineEhrTrainingMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}