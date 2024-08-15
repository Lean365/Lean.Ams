using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 公积金
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:02
    /// </summary>
    [Verify]
    [Route("Routine/RoutineEhrFunds")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class RoutineEhrFundsController : BaseController
    {
        /// <summary>
        /// 公积金接口
        /// </summary>
        private readonly IRoutineEhrFundsService _RoutineEhrFundsService;

        public RoutineEhrFundsController(IRoutineEhrFundsService RoutineEhrFundsService)
        {
            _RoutineEhrFundsService = RoutineEhrFundsService;
        }

        /// <summary>
        /// 查询公积金列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:ehrfunds:list")]
        public IActionResult QueryRoutineEhrFunds([FromQuery] RoutineEhrFundsQueryDto parm)
        {
            var response = _RoutineEhrFundsService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询公积金详情
        /// </summary>
        /// <param name="EfSfId"></param>
        /// <returns></returns>
        [HttpGet("{EfSfId}")]
        [ActionPermissionFilter(Permission = "routine:ehrfunds:query")]
        public IActionResult GetRoutineEhrFunds(long EfSfId)
        {
            var response = _RoutineEhrFundsService.GetInfo(EfSfId);
            
            var info = response.Adapt<RoutineEhrFundsDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加公积金
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:ehrfunds:add")]
        [Log(Title = "公积金", BusinessType = BusinessType.INSERT)]
        public IActionResult AddRoutineEhrFunds([FromBody] RoutineEhrFundsDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_RoutineEhrFundsService.CheckInputUnique(parm.EfSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增公积金 '{parm.EfSfId}'失败(Add failed)，输入的公积金已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<RoutineEhrFunds>().ToCreate(HttpContext);

            var response = _RoutineEhrFundsService.AddRoutineEhrFunds(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新公积金
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:ehrfunds:edit")]
        [Log(Title = "公积金", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateRoutineEhrFunds([FromBody] RoutineEhrFundsDto parm)
        {
            var modal = parm.Adapt<RoutineEhrFunds>().ToUpdate(HttpContext);
            var response = _RoutineEhrFundsService.UpdateRoutineEhrFunds(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除公积金
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:ehrfunds:delete")]
        [Log(Title = "公积金", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRoutineEhrFunds([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_RoutineEhrFundsService.Delete(idArr, "删除公积金"));
        }

        /// <summary>
        /// 导出公积金
        /// </summary>
        /// <returns></returns>
        [Log(Title = "公积金", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:ehrfunds:export")]
        public IActionResult Export([FromQuery] RoutineEhrFundsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _RoutineEhrFundsService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "公积金", "公积金");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "公积金导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "routine:ehrfunds:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<RoutineEhrFundsDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<RoutineEhrFundsDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_RoutineEhrFundsService.ImportRoutineEhrFunds(list.Adapt<List<RoutineEhrFunds>>()));
        }

        /// <summary>
        /// 公积金导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "公积金模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<RoutineEhrFundsImportTpl>() { }, "RoutineEhrFunds_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}