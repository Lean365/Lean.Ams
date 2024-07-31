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
    /// @Date: 2024/7/26 15:04:58
    /// </summary>
    [Verify]
    [Route("Logistics/PpManhours")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpManhoursController : BaseController
    {
        /// <summary>
        /// 标准工时接口
        /// </summary>
        private readonly IPpManhoursService _PpManhoursService;

        public PpManhoursController(IPpManhoursService PpManhoursService)
        {
            _PpManhoursService = PpManhoursService;
        }

        /// <summary>
        /// 查询标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:manhours:list")]
        public IActionResult QueryPpManhours([FromQuery] PpManhoursQueryDto parm)
        {
            var response = _PpManhoursService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询标准工时详情
        /// </summary>
        /// <param name="MhSfId"></param>
        /// <returns></returns>
        [HttpGet("{MhSfId}")]
        [ActionPermissionFilter(Permission = "pp:manhours:query")]
        public IActionResult GetPpManhours(long MhSfId)
        {
            var response = _PpManhoursService.GetInfo(MhSfId);
            
            var info = response.Adapt<PpManhoursDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加标准工时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:manhours:add")]
        [Log(Title = "标准工时", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpManhours([FromBody] PpManhoursDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpManhoursService.CheckInputUnique(parm.MhSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增标准工时 '{parm.MhSfId}'失败(Add failed)，输入的标准工时已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpManhours>().ToCreate(HttpContext);

            var response = _PpManhoursService.AddPpManhours(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新标准工时
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:manhours:edit")]
        [Log(Title = "标准工时", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpManhours([FromBody] PpManhoursDto parm)
        {
            var modal = parm.Adapt<PpManhours>().ToUpdate(HttpContext);
            var response = _PpManhoursService.UpdatePpManhours(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除标准工时
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:manhours:delete")]
        [Log(Title = "标准工时", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpManhours([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpManhoursService.Delete(idArr, "删除标准工时"));
        }

        /// <summary>
        /// 导出标准工时
        /// </summary>
        /// <returns></returns>
        [Log(Title = "标准工时", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:manhours:export")]
        public IActionResult Export([FromQuery] PpManhoursQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpManhoursService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "标准工时", "标准工时");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "标准工时导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:manhours:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpManhoursDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpManhoursDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpManhoursService.ImportPpManhours(list.Adapt<List<PpManhours>>()));
        }

        /// <summary>
        /// 标准工时导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "标准工时模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpManhoursImportTpl>() { }, "PpManhours_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}