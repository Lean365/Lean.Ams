using Microsoft.AspNetCore.Mvc;
using Ams.Model.Admin.Dto;
using Ams.Model.Admin;
using Ams.Service.Admin.IAdminService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Admin
{
    /// <summary>
    /// 表字段
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:01
    /// </summary>
    [Verify]
    [Route("Admin/SysTableFields")]
    [ApiExplorerSettings(GroupName = "admin")]
    public class SysTableFieldsController : BaseController
    {
        /// <summary>
        /// 表字段接口
        /// </summary>
        private readonly ISysTableFieldsService _SysTableFieldsService;

        public SysTableFieldsController(ISysTableFieldsService SysTableFieldsService)
        {
            _SysTableFieldsService = SysTableFieldsService;
        }

        /// <summary>
        /// 查询表字段列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sys:tablefields:list")]
        public IActionResult QuerySysTableFields([FromQuery] SysTableFieldsQueryDto parm)
        {
            var response = _SysTableFieldsService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询表字段详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "sys:tablefields:query")]
        public IActionResult GetSysTableFields(long Id)
        {
            var response = _SysTableFieldsService.GetInfo(Id);
            
            var info = response.Adapt<SysTableFieldsDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加表字段
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sys:tablefields:add")]
        [Log(Title = "表字段", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSysTableFields([FromBody] SysTableFieldsDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_SysTableFieldsService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增表字段 '{parm.Id}'失败(Add failed)，输入的表字段已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<SysTableFields>().ToCreate(HttpContext);

            var response = _SysTableFieldsService.AddSysTableFields(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新表字段
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sys:tablefields:edit")]
        [Log(Title = "表字段", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSysTableFields([FromBody] SysTableFieldsDto parm)
        {
            var modal = parm.Adapt<SysTableFields>().ToUpdate(HttpContext);
            var response = _SysTableFieldsService.UpdateSysTableFields(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除表字段
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "sys:tablefields:delete")]
        [Log(Title = "表字段", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysTableFields([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_SysTableFieldsService.Delete(idArr, "删除表字段"));
        }

        /// <summary>
        /// 导出表字段
        /// </summary>
        /// <returns></returns>
        [Log(Title = "表字段导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sys:tablefields:export")]
        public IActionResult Export([FromQuery] SysTableFieldsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SysTableFieldsService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "表字段", "表字段");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入表字段
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "表字段导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "sys:tablefields:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<SysTableFieldsDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SysTableFieldsDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SysTableFieldsService.ImportSysTableFields(list.Adapt<List<SysTableFields>>()));
        }

        /// <summary>
        /// 表字段
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "表字段模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SysTableFieldsImportTpl>() { }, "SysTableFields_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}