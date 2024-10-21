using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 计算公式
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 11:06:35
    /// </summary>
    [Verify]
    [Route("Routine/InstFormula")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class InstFormulaController : BaseController
    {
        /// <summary>
        /// 计算公式接口
        /// </summary>
        private readonly IInstFormulaService _InstFormulaService;

        public InstFormulaController(IInstFormulaService InstFormulaService)
        {
            _InstFormulaService = InstFormulaService;
        }

        /// <summary>
        /// 查询计算公式列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inst:formula:list")]
        public IActionResult QueryInstFormula([FromQuery] InstFormulaQueryDto parm)
        {
            var response = _InstFormulaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询计算公式详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "inst:formula:query")]
        public IActionResult GetInstFormula(long Id)
        {
            var response = _InstFormulaService.GetInfo(Id);
            
            var info = response.Adapt<InstFormulaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加计算公式
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inst:formula:add")]
        [Log(Title = "计算公式", BusinessType = BusinessType.ADD)]
        public IActionResult AddInstFormula([FromBody] InstFormulaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_InstFormulaService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增计算公式 '{parm.Id}'失败(Add failed)，输入的计算公式已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<InstFormula>().ToCreate(HttpContext);

            var response = _InstFormulaService.AddInstFormula(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新计算公式
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inst:formula:edit")]
        [Log(Title = "计算公式", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateInstFormula([FromBody] InstFormulaDto parm)
        {
            var modal = parm.Adapt<InstFormula>().ToUpdate(HttpContext);
            var response = _InstFormulaService.UpdateInstFormula(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除计算公式
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inst:formula:delete")]
        [Log(Title = "计算公式", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInstFormula([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_InstFormulaService.Delete(idArr, "删除计算公式"));
        }

        /// <summary>
        /// 导出计算公式
        /// </summary>
        /// <returns></returns>
        [Log(Title = "计算公式导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inst:formula:export")]
        public IActionResult Export([FromQuery] InstFormulaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InstFormulaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "计算公式", "计算公式");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入计算公式
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "计算公式导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "inst:formula:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<InstFormulaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InstFormulaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_InstFormulaService.ImportInstFormula(list.Adapt<List<InstFormula>>()));
        }

        /// <summary>
        /// 计算公式
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "计算公式模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InstFormulaImportTpl>() { }, "InstFormula_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}