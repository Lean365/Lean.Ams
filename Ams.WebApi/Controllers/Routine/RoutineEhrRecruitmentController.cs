using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 招聘
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:16
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrRecruitment")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrRecruitmentController : BaseController
    {
        /// <summary>
        /// 招聘接口
        /// </summary>
        private readonly IRoutineEhrRecruitmentService _RoutineEhrRecruitmentService;

        public RoutineEhrRecruitmentController(IRoutineEhrRecruitmentService RoutineEhrRecruitmentService)
        {
            _RoutineEhrRecruitmentService = RoutineEhrRecruitmentService;
        }

        /// <summary>
        /// 查询招聘列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrrecruitment:list")]
        public IActionResult QueryRoutineEhrRecruitment([FromQuery] RoutineEhrRecruitmentQueryDto parm)
        {
            var response = _RoutineEhrRecruitmentService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询招聘详情
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        [HttpGet("{EeSfId}")]
        [ActionPermissionFilter(Permission = "routine:ehrrecruitment:query")]
        public IActionResult GetRoutineEhrRecruitment(long EeSfId)
        {
            var response = _RoutineEhrRecruitmentService.GetInfo(EeSfId);
            
            var info = response.Adapt<RoutineEhrRecruitmentDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加招聘
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrrecruitment:add")]
        [Log(Title = "招聘", BusinessType = BusinessType.INSERT)]
        public IActionResult AddRoutineEhrRecruitment([FromBody] RoutineEhrRecruitmentDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrRecruitmentService.CheckInputUnique(parm.EeSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增招聘 '{parm.EeSfId}'失败(Add failed)，输入的招聘已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrRecruitment>().ToCreate(HttpContext);

            var response = _RoutineEhrRecruitmentService.AddRoutineEhrRecruitment(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新招聘
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrrecruitment:edit")]
        [Log(Title = "招聘", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateRoutineEhrRecruitment([FromBody] RoutineEhrRecruitmentDto parm)
        {
            var modal = parm.Adapt<RoutineEhrRecruitment>().ToUpdate(HttpContext);
            var response = _RoutineEhrRecruitmentService.UpdateRoutineEhrRecruitment(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除招聘
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrrecruitment:delete")]
        [Log(Title = "招聘", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrRecruitment([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrRecruitmentService.Delete(idArr, "删除招聘"));
        }

        /// <summary>
        /// 导出招聘
        /// </summary>
        /// <returns></returns>
        [Log(Title = "招聘", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrrecruitment:export")]
        public IActionResult Export([FromQuery] RoutineEhrRecruitmentQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrRecruitmentService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "招聘", "招聘");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "招聘导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrrecruitment:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<RoutineEhrRecruitmentDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrRecruitmentDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrRecruitmentService.ImportRoutineEhrRecruitment(list.Adapt<List<RoutineEhrRecruitment>>()));
        }

        /// <summary>
        /// 招聘导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "招聘模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrRecruitmentImportTpl>() { }, "RoutineEhrRecruitment_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}