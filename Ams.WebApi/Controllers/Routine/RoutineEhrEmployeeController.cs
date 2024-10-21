using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 人事
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/18 8:40:20
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrEmployee")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrEmployeeController : BaseController
    {
        /// <summary>
        /// 人事接口
        /// </summary>
        private readonly IRoutineEhrEmployeeService _RoutineEhrEmployeeService;

        public RoutineEhrEmployeeController(IRoutineEhrEmployeeService RoutineEhrEmployeeService)
        {
            _RoutineEhrEmployeeService = RoutineEhrEmployeeService;
        }

        /// <summary>
        /// 查询人事列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehremployee:list")]
        public IActionResult QueryRoutineEhrEmployee([FromQuery] RoutineEhrEmployeeQueryDto parm)
        {
            var response = _RoutineEhrEmployeeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询人事详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:ehremployee:query")]
        public IActionResult GetRoutineEhrEmployee(long Id)
        {
            var response = _RoutineEhrEmployeeService.GetInfo(Id);
            
            var info = response.Adapt<RoutineEhrEmployeeDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加人事
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehremployee:add")]
        [Log(Title = "人事", BusinessType = BusinessType.ADD)]
        public IActionResult AddRoutineEhrEmployee([FromBody] RoutineEhrEmployeeDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrEmployeeService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增人事 '{parm.Id}'失败(Add failed)，输入的人事已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrEmployee>().ToCreate(HttpContext);

            var response = _RoutineEhrEmployeeService.AddRoutineEhrEmployee(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新人事
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehremployee:edit")]
        [Log(Title = "人事", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateRoutineEhrEmployee([FromBody] RoutineEhrEmployeeDto parm)
        {
            var modal = parm.Adapt<RoutineEhrEmployee>().ToUpdate(HttpContext);
            var response = _RoutineEhrEmployeeService.UpdateRoutineEhrEmployee(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除人事
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehremployee:delete")]
        [Log(Title = "人事", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrEmployee([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrEmployeeService.Delete(idArr, "删除人事"));
        }

        /// <summary>
        /// 导出人事
        /// </summary>
        /// <returns></returns>
        [Log(Title = "人事导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehremployee:export")]
        public IActionResult Export([FromQuery] RoutineEhrEmployeeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrEmployeeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "人事", "人事");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入人事
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "人事导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehremployee:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<RoutineEhrEmployeeDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrEmployeeDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrEmployeeService.ImportRoutineEhrEmployee(list.Adapt<List<RoutineEhrEmployee>>()));
        }

        /// <summary>
        /// 人事
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "人事模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrEmployeeImportTpl>() { }, "RoutineEhrEmployee_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}