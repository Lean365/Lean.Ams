using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 源工时
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:11:09
    /// </summary>
    [Verify]
    [Route("Logistics/PpSourceManhours")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpSourceManhoursController : BaseController
    {
        /// <summary>
        /// 源工时接口
        /// </summary>
        private readonly IPpSourceManhoursService _PpSourceManhoursService;

        public PpSourceManhoursController(IPpSourceManhoursService PpSourceManhoursService)
        {
            _PpSourceManhoursService = PpSourceManhoursService;
        }

        /// <summary>
        /// 查询源工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:sourcemanhours:list")]
        public IActionResult QueryPpSourceManhours([FromQuery] PpSourceManhoursQueryDto parm)
        {
            var response = _PpSourceManhoursService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询源工时详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        [HttpGet("{SfId}")]
        [ActionPermissionFilter(Permission = "pp:sourcemanhours:query")]
        public IActionResult GetPpSourceManhours(long SfId)
        {
            var response = _PpSourceManhoursService.GetInfo(SfId);
            
            var info = response.Adapt<PpSourceManhoursDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加源工时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:sourcemanhours:add")]
        [Log(Title = "源工时", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpSourceManhours([FromBody] PpSourceManhoursDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpSourceManhoursService.CheckInputUnique(parm.SfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增源工时 '{parm.SfId}'失败(Add failed)，输入的源工时已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpSourceManhours>().ToCreate(HttpContext);

            var response = _PpSourceManhoursService.AddPpSourceManhours(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新源工时
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:sourcemanhours:edit")]
        [Log(Title = "源工时", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpSourceManhours([FromBody] PpSourceManhoursDto parm)
        {
            var modal = parm.Adapt<PpSourceManhours>().ToUpdate(HttpContext);
            var response = _PpSourceManhoursService.UpdatePpSourceManhours(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除源工时
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:sourcemanhours:delete")]
        [Log(Title = "源工时", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpSourceManhours([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpSourceManhoursService.Delete(idArr, "删除源工时"));
        }

        /// <summary>
        /// 导出源工时
        /// </summary>
        /// <returns></returns>
        [Log(Title = "源工时", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:sourcemanhours:export")]
        public IActionResult Export([FromQuery] PpSourceManhoursQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpSourceManhoursService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "源工时", "源工时");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "源工时导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:sourcemanhours:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpSourceManhoursDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpSourceManhoursDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpSourceManhoursService.ImportPpSourceManhours(list.Adapt<List<PpSourceManhours>>()));
        }

        /// <summary>
        /// 源工时导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "源工时模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpSourceManhoursImportTpl>() { }, "PpSourceManhours_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}