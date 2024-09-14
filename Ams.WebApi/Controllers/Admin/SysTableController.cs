using Microsoft.AspNetCore.Mvc;
using Ams.Model.Admin.Dto;
using Ams.Model.Admin;
using Ams.Service.Admin.IAdminService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Admin
{
    /// <summary>
    /// 表名称
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:06
    /// </summary>
    [Verify]
    [Route("Admin/SysTable")]
    [ApiExplorerSettings(GroupName = "admin")]
    public class SysTableController : BaseController
    {
        /// <summary>
        /// 表名称接口
        /// </summary>
        private readonly ISysTableService _SysTableService;

        public SysTableController(ISysTableService SysTableService)
        {
            _SysTableService = SysTableService;
        }

        /// <summary>
        /// 查询表名称列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sys:table:list")]
        public IActionResult QuerySysTable([FromQuery] SysTableQueryDto parm)
        {
            var response = _SysTableService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询表名称详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "sys:table:query")]
        public IActionResult GetSysTable(long Id)
        {
            var response = _SysTableService.GetInfo(Id);
            
            var info = response.Adapt<SysTableDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加表名称
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sys:table:add")]
        [Log(Title = "表名称", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSysTable([FromBody] SysTableDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_SysTableService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增表名称 '{parm.Id}'失败(Add failed)，输入的表名称已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<SysTable>().ToCreate(HttpContext);

            var response = _SysTableService.AddSysTable(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新表名称
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sys:table:edit")]
        [Log(Title = "表名称", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSysTable([FromBody] SysTableDto parm)
        {
            var modal = parm.Adapt<SysTable>().ToUpdate(HttpContext);
            var response = _SysTableService.UpdateSysTable(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除表名称
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "sys:table:delete")]
        [Log(Title = "表名称", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysTable([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_SysTableService.Delete(idArr, "删除表名称"));
        }

        /// <summary>
        /// 导出表名称
        /// </summary>
        /// <returns></returns>
        [Log(Title = "表名称导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sys:table:export")]
        public IActionResult Export([FromQuery] SysTableQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SysTableService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "表名称", "表名称");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入表名称
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "表名称导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "sys:table:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<SysTableDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SysTableDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SysTableService.ImportSysTable(list.Adapt<List<SysTable>>()));
        }

        /// <summary>
        /// 表名称
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "表名称模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SysTableImportTpl>() { }, "SysTable_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}