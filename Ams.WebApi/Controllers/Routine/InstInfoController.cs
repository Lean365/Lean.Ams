using Ams.Model.Routine.Dto;
using Ams.Service.Routine.IRoutineService;
using Microsoft.AspNetCore.Mvc;
using MiniExcelLibs;

namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 机构信息
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:51:09
    /// </summary>
    [Verify]
    [Route("Routine/InstInfo")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class InstInfoController : BaseController
    {
        /// <summary>
        /// 机构信息接口
        /// </summary>
        private readonly IInstInfoService _InstInfoService;

        public InstInfoController(IInstInfoService InstInfoService)
        {
            _InstInfoService = InstInfoService;
        }

        /// <summary>
        /// 查询机构信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inst:info:list")]
        public IActionResult QueryInstInfo([FromQuery] InstInfoQueryDto parm)
        {
            var response = _InstInfoService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询机构信息详情
        /// </summary>
        /// <param name="IiSfId"></param>
        /// <returns></returns>
        [HttpGet("{IiSfId}")]
        [ActionPermissionFilter(Permission = "inst:info:query")]
        public IActionResult GetInstInfo(long IiSfId)
        {
            var response = _InstInfoService.GetInfo(IiSfId);

            var info = response.Adapt<InstInfoDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加机构信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inst:info:add")]
        [Log(Title = "机构信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInstInfo([FromBody] InstInfoDto parm)
        {
            // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_InstInfoService.CheckInputUnique(parm.IiInstCode.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增机构信息 '{parm.IiInstCode}'失败(Add failed)，输入的机构信息已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<InstInfo>().ToCreate(HttpContext);

            var response = _InstInfoService.AddInstInfo(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新机构信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inst:info:edit")]
        [Log(Title = "机构信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateInstInfo([FromBody] InstInfoDto parm)
        {
            var modal = parm.Adapt<InstInfo>().ToUpdate(HttpContext);
            var response = _InstInfoService.UpdateInstInfo(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除机构信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inst:info:delete")]
        [Log(Title = "机构信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInstInfo([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_InstInfoService.Delete(idArr, "删除机构信息"));
        }

        /// <summary>
        /// 导出机构信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "机构信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inst:info:export")]
        public IActionResult Export([FromQuery] InstInfoQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InstInfoService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "机构信息", "机构信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "机构信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "inst:info:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<InstInfoDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InstInfoDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_InstInfoService.ImportInstInfo(list.Adapt<List<InstInfo>>()));
        }

        /// <summary>
        /// 机构信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "机构信息模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InstInfoImportTpl>() { }, "InstInfo_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}