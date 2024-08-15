using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 福利
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:35
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrBenefits")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrBenefitsController : BaseController
    {
        /// <summary>
        /// 福利接口
        /// </summary>
        private readonly IRoutineEhrBenefitsService _RoutineEhrBenefitsService;

        public RoutineEhrBenefitsController(IRoutineEhrBenefitsService RoutineEhrBenefitsService)
        {
            _RoutineEhrBenefitsService = RoutineEhrBenefitsService;
        }

        /// <summary>
        /// 查询福利列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrbenefits:list")]
        public IActionResult QueryRoutineEhrBenefits([FromQuery] RoutineEhrBenefitsQueryDto parm)
        {
            var response = _RoutineEhrBenefitsService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询福利详情
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        [HttpGet("{EeSfId}")]
        [ActionPermissionFilter(Permission = "routine:ehrbenefits:query")]
        public IActionResult GetRoutineEhrBenefits(long EeSfId)
        {
            var response = _RoutineEhrBenefitsService.GetInfo(EeSfId);
            
            var info = response.Adapt<RoutineEhrBenefitsDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加福利
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrbenefits:add")]
        [Log(Title = "福利", BusinessType = BusinessType.INSERT)]
        public IActionResult AddRoutineEhrBenefits([FromBody] RoutineEhrBenefitsDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrBenefitsService.CheckInputUnique(parm.EeSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增福利 '{parm.EeSfId}'失败(Add failed)，输入的福利已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrBenefits>().ToCreate(HttpContext);

            var response = _RoutineEhrBenefitsService.AddRoutineEhrBenefits(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新福利
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrbenefits:edit")]
        [Log(Title = "福利", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateRoutineEhrBenefits([FromBody] RoutineEhrBenefitsDto parm)
        {
            var modal = parm.Adapt<RoutineEhrBenefits>().ToUpdate(HttpContext);
            var response = _RoutineEhrBenefitsService.UpdateRoutineEhrBenefits(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除福利
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrbenefits:delete")]
        [Log(Title = "福利", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrBenefits([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrBenefitsService.Delete(idArr, "删除福利"));
        }

        /// <summary>
        /// 导出福利
        /// </summary>
        /// <returns></returns>
        [Log(Title = "福利", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrbenefits:export")]
        public IActionResult Export([FromQuery] RoutineEhrBenefitsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrBenefitsService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "福利", "福利");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "福利导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrbenefits:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<RoutineEhrBenefitsDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrBenefitsDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrBenefitsService.ImportRoutineEhrBenefits(list.Adapt<List<RoutineEhrBenefits>>()));
        }

        /// <summary>
        /// 福利导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "福利模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrBenefitsImportTpl>() { }, "RoutineEhrBenefits_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}