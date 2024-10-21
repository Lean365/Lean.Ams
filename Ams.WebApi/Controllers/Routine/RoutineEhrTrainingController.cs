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
    /// @Date: 2024/10/21 8:56:48
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrTraining")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrTrainingController : BaseController
    {
        /// <summary>
        /// 培训接口
        /// </summary>
        private readonly IRoutineEhrTrainingService _RoutineEhrTrainingService;

        public RoutineEhrTrainingController(IRoutineEhrTrainingService RoutineEhrTrainingService)
        {
            _RoutineEhrTrainingService = RoutineEhrTrainingService;
        }

        /// <summary>
        /// 查询培训列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrtraining:list")]
        public IActionResult QueryRoutineEhrTraining([FromQuery] RoutineEhrTrainingQueryDto parm)
        {
            var response = _RoutineEhrTrainingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询培训详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:ehrtraining:query")]
        public IActionResult GetRoutineEhrTraining(long Id)
        {
            var response = _RoutineEhrTrainingService.GetInfo(Id);
            
            var info = response.Adapt<RoutineEhrTrainingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加培训
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrtraining:add")]
        [Log(Title = "培训", BusinessType = BusinessType.ADD)]
        public IActionResult AddRoutineEhrTraining([FromBody] RoutineEhrTrainingDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrTrainingService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增培训 '{parm.Id}'失败(Add failed)，输入的培训已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrTraining>().ToCreate(HttpContext);

            var response = _RoutineEhrTrainingService.AddRoutineEhrTraining(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新培训
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrtraining:edit")]
        [Log(Title = "培训", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateRoutineEhrTraining([FromBody] RoutineEhrTrainingDto parm)
        {
            var modal = parm.Adapt<RoutineEhrTraining>().ToUpdate(HttpContext);
            var response = _RoutineEhrTrainingService.UpdateRoutineEhrTraining(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除培训
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrtraining:delete")]
        [Log(Title = "培训", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrTraining([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrTrainingService.Delete(idArr, "删除培训"));
        }

        /// <summary>
        /// 导出培训
        /// </summary>
        /// <returns></returns>
        [Log(Title = "培训导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrtraining:export")]
        public IActionResult Export([FromQuery] RoutineEhrTrainingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrTrainingService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "routine:ehrtraining:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<RoutineEhrTrainingDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrTrainingDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrTrainingService.ImportRoutineEhrTraining(list.Adapt<List<RoutineEhrTraining>>()));
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
            var result = DownloadImportTemplate(new List<RoutineEhrTrainingImportTpl>() { }, "RoutineEhrTraining_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}