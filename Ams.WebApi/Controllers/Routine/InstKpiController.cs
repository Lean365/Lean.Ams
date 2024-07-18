using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// KPI
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:44:18
    /// </summary>
    [Verify]
    [Route("Routine/InstKpi")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class InstKpiController : BaseController
    {
        /// <summary>
        /// KPI接口
        /// </summary>
        private readonly IInstKpiService _InstKpiService;

        public InstKpiController(IInstKpiService InstKpiService)
        {
            _InstKpiService = InstKpiService;
        }

        /// <summary>
        /// 查询KPI列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inst:kpi:list")]
        public IActionResult QueryInstKpi([FromQuery] InstKpiQueryDto parm)
        {
            var response = _InstKpiService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询KPI详情
        /// </summary>
        /// <param name="IkSFID"></param>
        /// <returns></returns>
        [HttpGet("{IkSFID}")]
        [ActionPermissionFilter(Permission = "inst:kpi:query")]
        public IActionResult GetInstKpi(long IkSFID)
        {
            var response = _InstKpiService.GetInfo(IkSFID);
            
            var info = response.Adapt<InstKpiDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加KPI
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inst:kpi:add")]
        [Log(Title = "KPI", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInstKpi([FromBody] InstKpiDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_InstKpiService.CheckInputUnique(parm.IkSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增KPI '{parm.IkSFID}'失败(Add failed)，输入的KPI已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<InstKpi>().ToCreate(HttpContext);

            var response = _InstKpiService.AddInstKpi(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新KPI
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inst:kpi:edit")]
        [Log(Title = "KPI", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateInstKpi([FromBody] InstKpiDto parm)
        {
            var modal = parm.Adapt<InstKpi>().ToUpdate(HttpContext);
            var response = _InstKpiService.UpdateInstKpi(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除KPI
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inst:kpi:delete")]
        [Log(Title = "KPI", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInstKpi([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_InstKpiService.Delete(idArr, "删除KPI"));
        }

        /// <summary>
        /// 导出KPI
        /// </summary>
        /// <returns></returns>
        [Log(Title = "KPI", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inst:kpi:export")]
        public IActionResult Export([FromQuery] InstKpiQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InstKpiService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "KPI", "KPI");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "KPI导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "inst:kpi:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<InstKpiDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InstKpiDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_InstKpiService.ImportInstKpi(list.Adapt<List<InstKpi>>()));
        }

        /// <summary>
        /// KPI导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "KPI模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InstKpiImportTpl>() { }, "InstKpi_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}