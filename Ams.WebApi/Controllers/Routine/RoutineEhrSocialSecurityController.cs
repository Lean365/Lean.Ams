using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 社保
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:30:43
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrSocialSecurity")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrSocialSecurityController : BaseController
    {
        /// <summary>
        /// 社保接口
        /// </summary>
        private readonly IRoutineEhrSocialSecurityService _RoutineEhrSocialSecurityService;

        public RoutineEhrSocialSecurityController(IRoutineEhrSocialSecurityService RoutineEhrSocialSecurityService)
        {
            _RoutineEhrSocialSecurityService = RoutineEhrSocialSecurityService;
        }

        /// <summary>
        /// 查询社保列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrsocialsecurity:list")]
        public IActionResult QueryRoutineEhrSocialSecurity([FromQuery] RoutineEhrSocialSecurityQueryDto parm)
        {
            var response = _RoutineEhrSocialSecurityService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询社保详情
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        [HttpGet("{EeSfId}")]
        [ActionPermissionFilter(Permission = "routine:ehrsocialsecurity:query")]
        public IActionResult GetRoutineEhrSocialSecurity(long EeSfId)
        {
            var response = _RoutineEhrSocialSecurityService.GetInfo(EeSfId);
            
            var info = response.Adapt<RoutineEhrSocialSecurityDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加社保
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrsocialsecurity:add")]
        [Log(Title = "社保", BusinessType = BusinessType.INSERT)]
        public IActionResult AddRoutineEhrSocialSecurity([FromBody] RoutineEhrSocialSecurityDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrSocialSecurityService.CheckInputUnique(parm.EeSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增社保 '{parm.EeSfId}'失败(Add failed)，输入的社保已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrSocialSecurity>().ToCreate(HttpContext);

            var response = _RoutineEhrSocialSecurityService.AddRoutineEhrSocialSecurity(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新社保
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrsocialsecurity:edit")]
        [Log(Title = "社保", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateRoutineEhrSocialSecurity([FromBody] RoutineEhrSocialSecurityDto parm)
        {
            var modal = parm.Adapt<RoutineEhrSocialSecurity>().ToUpdate(HttpContext);
            var response = _RoutineEhrSocialSecurityService.UpdateRoutineEhrSocialSecurity(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除社保
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrsocialsecurity:delete")]
        [Log(Title = "社保", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrSocialSecurity([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrSocialSecurityService.Delete(idArr, "删除社保"));
        }

        /// <summary>
        /// 导出社保
        /// </summary>
        /// <returns></returns>
        [Log(Title = "社保", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrsocialsecurity:export")]
        public IActionResult Export([FromQuery] RoutineEhrSocialSecurityQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrSocialSecurityService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "社保", "社保");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "社保导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrsocialsecurity:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<RoutineEhrSocialSecurityDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrSocialSecurityDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrSocialSecurityService.ImportRoutineEhrSocialSecurity(list.Adapt<List<RoutineEhrSocialSecurity>>()));
        }

        /// <summary>
        /// 社保导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "社保模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrSocialSecurityImportTpl>() { }, "RoutineEhrSocialSecurity_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}