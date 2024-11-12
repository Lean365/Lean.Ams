using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 流程
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/31 11:32:52
    /// </summary>
    [Verify]
    [Route("Routine/FlowScheme")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class FlowSchemeController : BaseController
    {
        /// <summary>
        /// 流程接口
        /// </summary>
        private readonly IFlowSchemeService _FlowSchemeService;

        public FlowSchemeController(IFlowSchemeService FlowSchemeService)
        {
            _FlowSchemeService = FlowSchemeService;
        }

        /// <summary>
        /// 查询流程列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "flow:scheme:list")]
        public IActionResult QueryFlowScheme([FromQuery] FlowSchemeQueryDto parm)
        {
            var response = _FlowSchemeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询流程详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "flow:scheme:query")]
        public IActionResult GetFlowScheme(long Id)
        {
            var response = _FlowSchemeService.GetInfo(Id);
            
            var info = response.Adapt<FlowSchemeDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加流程
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "flow:scheme:add")]
        [Log(Title = "流程", BusinessType = BusinessType.ADD)]
        public IActionResult AddFlowScheme([FromBody] FlowSchemeDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FlowSchemeService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增流程 '{parm.Id}'失败(Add failed)，输入的流程已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FlowScheme>().ToCreate(HttpContext);

            var response = _FlowSchemeService.AddFlowScheme(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新流程
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "flow:scheme:edit")]
        [Log(Title = "流程", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFlowScheme([FromBody] FlowSchemeDto parm)
        {
            var modal = parm.Adapt<FlowScheme>().ToUpdate(HttpContext);
            var response = _FlowSchemeService.UpdateFlowScheme(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除流程
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "flow:scheme:delete")]
        [Log(Title = "流程", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFlowScheme([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FlowSchemeService.Delete(idArr, "删除流程"));
        }

        /// <summary>
        /// 导出流程
        /// </summary>
        /// <returns></returns>
        [Log(Title = "流程导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "flow:scheme:export")]
        public IActionResult Export([FromQuery] FlowSchemeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FlowSchemeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "流程", "流程");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入流程
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "流程导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "flow:scheme:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FlowSchemeDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FlowSchemeDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FlowSchemeService.ImportFlowScheme(list.Adapt<List<FlowScheme>>()));
        }

        /// <summary>
        /// 流程
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "流程模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FlowSchemeImportTpl>() { }, "FlowScheme_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}