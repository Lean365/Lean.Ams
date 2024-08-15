using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 制二OPH主表
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:27
    /// </summary>
    [Verify]
    [Route("Logistics/PpOutputPcbaMaster")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOutputPcbaMasterController : BaseController
    {
        /// <summary>
        /// 制二OPH主表接口
        /// </summary>
        private readonly IPpOutputPcbaMasterService _PpOutputPcbaMasterService;

        public PpOutputPcbaMasterController(IPpOutputPcbaMasterService PpOutputPcbaMasterService)
        {
            _PpOutputPcbaMasterService = PpOutputPcbaMasterService;
        }

        /// <summary>
        /// 查询制二OPH主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputpcbamaster:list")]
        public IActionResult QueryPpOutputPcbaMaster([FromQuery] PpOutputPcbaMasterQueryDto parm)
        {
            var response = _PpOutputPcbaMasterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询制二OPH主表详情
        /// </summary>
        /// <param name="PomSfId"></param>
        /// <returns></returns>
        [HttpGet("{PomSfId}")]
        [ActionPermissionFilter(Permission = "pp:outputpcbamaster:query")]
        public IActionResult GetPpOutputPcbaMaster(long PomSfId)
        {
            var response = _PpOutputPcbaMasterService.GetInfo(PomSfId);
            
            var info = response.Adapt<PpOutputPcbaMasterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加制二OPH主表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputpcbamaster:add")]
        [Log(Title = "制二OPH主表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOutputPcbaMaster([FromBody] PpOutputPcbaMasterDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputPcbaMasterService.CheckInputUnique(parm.PomSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增制二OPH主表 '{parm.PomSfId}'失败(Add failed)，输入的制二OPH主表已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOutputPcbaMaster>().ToCreate(HttpContext);

            var response = _PpOutputPcbaMasterService.AddPpOutputPcbaMaster(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新制二OPH主表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputpcbamaster:edit")]
        [Log(Title = "制二OPH主表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOutputPcbaMaster([FromBody] PpOutputPcbaMasterDto parm)
        {
            var modal = parm.Adapt<PpOutputPcbaMaster>().ToUpdate(HttpContext);
            var response = _PpOutputPcbaMasterService.UpdatePpOutputPcbaMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除制二OPH主表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputpcbamaster:delete")]
        [Log(Title = "制二OPH主表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputPcbaMaster([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOutputPcbaMasterService.Delete(idArr, "删除制二OPH主表"));
        }

        /// <summary>
        /// 导出制二OPH主表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "制二OPH主表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputpcbamaster:export")]
        public IActionResult Export([FromQuery] PpOutputPcbaMasterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOutputPcbaMasterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "制二OPH主表", "制二OPH主表");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "制二OPH主表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputpcbamaster:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpOutputPcbaMasterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOutputPcbaMasterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOutputPcbaMasterService.ImportPpOutputPcbaMaster(list.Adapt<List<PpOutputPcbaMaster>>()));
        }

        /// <summary>
        /// 制二OPH主表导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "制二OPH主表模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOutputPcbaMasterImportTpl>() { }, "PpOutputPcbaMaster_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}