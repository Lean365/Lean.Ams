using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 奖惩
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:00
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrRewardPenalties")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrRewardPenaltiesController : BaseController
    {
        /// <summary>
        /// 奖惩接口
        /// </summary>
        private readonly IRoutineEhrRewardPenaltiesService _RoutineEhrRewardPenaltiesService;

        public RoutineEhrRewardPenaltiesController(IRoutineEhrRewardPenaltiesService RoutineEhrRewardPenaltiesService)
        {
            _RoutineEhrRewardPenaltiesService = RoutineEhrRewardPenaltiesService;
        }

        /// <summary>
        /// 查询奖惩列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrrewardpenalties:list")]
        public IActionResult QueryRoutineEhrRewardPenalties([FromQuery] RoutineEhrRewardPenaltiesQueryDto parm)
        {
            var response = _RoutineEhrRewardPenaltiesService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询奖惩详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:ehrrewardpenalties:query")]
        public IActionResult GetRoutineEhrRewardPenalties(long Id)
        {
            var response = _RoutineEhrRewardPenaltiesService.GetInfo(Id);
            
            var info = response.Adapt<RoutineEhrRewardPenaltiesDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加奖惩
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrrewardpenalties:add")]
        [Log(Title = "奖惩", BusinessType = BusinessType.ADD)]
        public IActionResult AddRoutineEhrRewardPenalties([FromBody] RoutineEhrRewardPenaltiesDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrRewardPenaltiesService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增奖惩 '{parm.Id}'失败(Add failed)，输入的奖惩已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrRewardPenalties>().ToCreate(HttpContext);

            var response = _RoutineEhrRewardPenaltiesService.AddRoutineEhrRewardPenalties(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新奖惩
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrrewardpenalties:edit")]
        [Log(Title = "奖惩", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateRoutineEhrRewardPenalties([FromBody] RoutineEhrRewardPenaltiesDto parm)
        {
            var modal = parm.Adapt<RoutineEhrRewardPenalties>().ToUpdate(HttpContext);
            var response = _RoutineEhrRewardPenaltiesService.UpdateRoutineEhrRewardPenalties(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除奖惩
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrrewardpenalties:delete")]
        [Log(Title = "奖惩", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrRewardPenalties([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrRewardPenaltiesService.Delete(idArr, "删除奖惩"));
        }

        /// <summary>
        /// 导出奖惩
        /// </summary>
        /// <returns></returns>
        [Log(Title = "奖惩导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrrewardpenalties:export")]
        public IActionResult Export([FromQuery] RoutineEhrRewardPenaltiesQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrRewardPenaltiesService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "奖惩", "奖惩");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入奖惩
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "奖惩导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrrewardpenalties:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<RoutineEhrRewardPenaltiesDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrRewardPenaltiesDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrRewardPenaltiesService.ImportRoutineEhrRewardPenalties(list.Adapt<List<RoutineEhrRewardPenalties>>()));
        }

        /// <summary>
        /// 奖惩
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "奖惩模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrRewardPenaltiesImportTpl>() { }, "RoutineEhrRewardPenalties_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}