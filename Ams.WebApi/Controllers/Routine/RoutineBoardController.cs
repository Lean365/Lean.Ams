using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 看板
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/20 9:52:38
    /// </summary>
    [Verify]
    [Route("Routine/RoutineBoard")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineBoardController : BaseController
    {
        /// <summary>
        /// 看板接口
        /// </summary>
        private readonly IRoutineBoardService _RoutineBoardService;

        public RoutineBoardController(IRoutineBoardService RoutineBoardService)
        {
            _RoutineBoardService = RoutineBoardService;
        }

        /// <summary>
        /// 查询看板列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:board:list")]
        public IActionResult QueryRoutineBoard([FromQuery] RoutineBoardQueryDto parm)
        {
            var response = _RoutineBoardService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询看板详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:board:query")]
        public IActionResult GetRoutineBoard(long Id)
        {
            var response = _RoutineBoardService.GetInfo(Id);
            
            var info = response.Adapt<RoutineBoardDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加看板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:board:add")]
        [Log(Title = "看板", BusinessType = BusinessType.ADD)]
        public IActionResult AddRoutineBoard([FromBody] RoutineBoardDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineBoardService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增看板 '{parm.Id}'失败(Add failed)，输入的看板已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineBoard>().ToCreate(HttpContext);

            var response = _RoutineBoardService.AddRoutineBoard(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新看板
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:board:edit")]
        [Log(Title = "看板", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateRoutineBoard([FromBody] RoutineBoardDto parm)
        {
            var modal = parm.Adapt<RoutineBoard>().ToUpdate(HttpContext);
            var response = _RoutineBoardService.UpdateRoutineBoard(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除看板
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:board:delete")]
        [Log(Title = "看板", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineBoard([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineBoardService.Delete(idArr, "删除看板"));
        }

        /// <summary>
        /// 导出看板
        /// </summary>
        /// <returns></returns>
        [Log(Title = "看板导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:board:export")]
        public IActionResult Export([FromQuery] RoutineBoardQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineBoardService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "看板", "看板");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入看板
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "看板导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:board:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<RoutineBoardDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineBoardDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineBoardService.ImportRoutineBoard(list.Adapt<List<RoutineBoard>>()));
        }

        /// <summary>
        /// 看板
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "看板模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineBoardImportTpl>() { }, "RoutineBoard_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}