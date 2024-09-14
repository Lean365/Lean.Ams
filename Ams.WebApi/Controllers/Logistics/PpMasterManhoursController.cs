using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 标准工时
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:31:00
    /// </summary>
    [Verify]
    [Route("Logistics/PpMasterManhours")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpMasterManhoursController : BaseController
    {
        /// <summary>
        /// 标准工时接口
        /// </summary>
        private readonly IPpMasterManhoursService _PpMasterManhoursService;

        public PpMasterManhoursController(IPpMasterManhoursService PpMasterManhoursService)
        {
            _PpMasterManhoursService = PpMasterManhoursService;
        }

        /// <summary>
        /// 查询标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:mastermanhours:list")]
        public IActionResult QueryPpMasterManhours([FromQuery] PpMasterManhoursQueryDto parm)
        {
            var response = _PpMasterManhoursService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询标准工时详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:mastermanhours:query")]
        public IActionResult GetPpMasterManhours(long Id)
        {
            var response = _PpMasterManhoursService.GetInfo(Id);
            
            var info = response.Adapt<PpMasterManhoursDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加标准工时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:mastermanhours:add")]
        [Log(Title = "标准工时", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpMasterManhours([FromBody] PpMasterManhoursDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpMasterManhoursService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增标准工时 '{parm.Id}'失败(Add failed)，输入的标准工时已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpMasterManhours>().ToCreate(HttpContext);

            var response = _PpMasterManhoursService.AddPpMasterManhours(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新标准工时
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:mastermanhours:edit")]
        [Log(Title = "标准工时", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpMasterManhours([FromBody] PpMasterManhoursDto parm)
        {
            var modal = parm.Adapt<PpMasterManhours>().ToUpdate(HttpContext);
            var response = _PpMasterManhoursService.UpdatePpMasterManhours(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除标准工时
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:mastermanhours:delete")]
        [Log(Title = "标准工时", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpMasterManhours([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpMasterManhoursService.Delete(idArr, "删除标准工时"));
        }

        /// <summary>
        /// 导出标准工时
        /// </summary>
        /// <returns></returns>
        [Log(Title = "标准工时导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:mastermanhours:export")]
        public IActionResult Export([FromQuery] PpMasterManhoursQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpMasterManhoursService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "标准工时", "标准工时");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入标准工时
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "标准工时导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:mastermanhours:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpMasterManhoursDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpMasterManhoursDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpMasterManhoursService.ImportPpMasterManhours(list.Adapt<List<PpMasterManhours>>()));
        }

        /// <summary>
        /// 标准工时
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "标准工时模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpMasterManhoursImportTpl>() { }, "PpMasterManhours_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}