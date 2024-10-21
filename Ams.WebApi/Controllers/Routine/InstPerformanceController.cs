using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 机构目标
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 10:55:04
    /// </summary>
    [Verify]
    [Route("Routine/InstPerformance")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class InstPerformanceController : BaseController
    {
        /// <summary>
        /// 机构目标接口
        /// </summary>
        private readonly IInstPerformanceService _InstPerformanceService;

        public InstPerformanceController(IInstPerformanceService InstPerformanceService)
        {
            _InstPerformanceService = InstPerformanceService;
        }

        /// <summary>
        /// 查询机构目标列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inst:performance:list")]
        public IActionResult QueryInstPerformance([FromQuery] InstPerformanceQueryDto parm)
        {
            var response = _InstPerformanceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询机构目标详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "inst:performance:query")]
        public IActionResult GetInstPerformance(long Id)
        {
            var response = _InstPerformanceService.GetInfo(Id);
            
            var info = response.Adapt<InstPerformanceDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加机构目标
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inst:performance:add")]
        [Log(Title = "机构目标", BusinessType = BusinessType.ADD)]
        public IActionResult AddInstPerformance([FromBody] InstPerformanceDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_InstPerformanceService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增机构目标 '{parm.Id}'失败(Add failed)，输入的机构目标已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<InstPerformance>().ToCreate(HttpContext);

            var response = _InstPerformanceService.AddInstPerformance(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新机构目标
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inst:performance:edit")]
        [Log(Title = "机构目标", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateInstPerformance([FromBody] InstPerformanceDto parm)
        {
            var modal = parm.Adapt<InstPerformance>().ToUpdate(HttpContext);
            var response = _InstPerformanceService.UpdateInstPerformance(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除机构目标
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inst:performance:delete")]
        [Log(Title = "机构目标", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInstPerformance([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_InstPerformanceService.Delete(idArr, "删除机构目标"));
        }

        /// <summary>
        /// 导出机构目标
        /// </summary>
        /// <returns></returns>
        [Log(Title = "机构目标导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inst:performance:export")]
        public IActionResult Export([FromQuery] InstPerformanceQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InstPerformanceService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "机构目标", "机构目标");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入机构目标
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "机构目标导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "inst:performance:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<InstPerformanceDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InstPerformanceDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_InstPerformanceService.ImportInstPerformance(list.Adapt<List<InstPerformance>>()));
        }

        /// <summary>
        /// 机构目标
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "机构目标模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InstPerformanceImportTpl>() { }, "InstPerformance_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}