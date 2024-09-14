using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 原因类别
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:44:02
    /// </summary>
    [Verify]
    [Route("Logistics/PpMasterCause")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpMasterCauseController : BaseController
    {
        /// <summary>
        /// 原因类别接口
        /// </summary>
        private readonly IPpMasterCauseService _PpMasterCauseService;

        public PpMasterCauseController(IPpMasterCauseService PpMasterCauseService)
        {
            _PpMasterCauseService = PpMasterCauseService;
        }

        /// <summary>
        /// 查询原因类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:mastercause:list")]
        public IActionResult QueryPpMasterCause([FromQuery] PpMasterCauseQueryDto parm)
        {
            var response = _PpMasterCauseService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询原因类别详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:mastercause:query")]
        public IActionResult GetPpMasterCause(long Id)
        {
            var response = _PpMasterCauseService.GetInfo(Id);
            
            var info = response.Adapt<PpMasterCauseDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加原因类别
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:mastercause:add")]
        [Log(Title = "原因类别", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpMasterCause([FromBody] PpMasterCauseDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpMasterCauseService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增原因类别 '{parm.Id}'失败(Add failed)，输入的原因类别已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpMasterCause>().ToCreate(HttpContext);

            var response = _PpMasterCauseService.AddPpMasterCause(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新原因类别
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:mastercause:edit")]
        [Log(Title = "原因类别", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpMasterCause([FromBody] PpMasterCauseDto parm)
        {
            var modal = parm.Adapt<PpMasterCause>().ToUpdate(HttpContext);
            var response = _PpMasterCauseService.UpdatePpMasterCause(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除原因类别
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:mastercause:delete")]
        [Log(Title = "原因类别", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpMasterCause([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpMasterCauseService.Delete(idArr, "删除原因类别"));
        }

        /// <summary>
        /// 导出原因类别
        /// </summary>
        /// <returns></returns>
        [Log(Title = "原因类别导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:mastercause:export")]
        public IActionResult Export([FromQuery] PpMasterCauseQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpMasterCauseService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "原因类别", "原因类别");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入原因类别
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "原因类别导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:mastercause:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpMasterCauseDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpMasterCauseDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpMasterCauseService.ImportPpMasterCause(list.Adapt<List<PpMasterCause>>()));
        }

        /// <summary>
        /// 原因类别
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "原因类别模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpMasterCauseImportTpl>() { }, "PpMasterCause_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}