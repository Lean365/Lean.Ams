using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 制一OPH主表
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:23
    /// </summary>
    [Verify]
    [Route("Logistics/PpOutputAssyMaster")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOutputAssyMasterController : BaseController
    {
        /// <summary>
        /// 制一OPH主表接口
        /// </summary>
        private readonly IPpOutputAssyMasterService _PpOutputAssyMasterService;

        public PpOutputAssyMasterController(IPpOutputAssyMasterService PpOutputAssyMasterService)
        {
            _PpOutputAssyMasterService = PpOutputAssyMasterService;
        }

        /// <summary>
        /// 查询制一OPH主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputassymaster:list")]
        public IActionResult QueryPpOutputAssyMaster([FromQuery] PpOutputAssyMasterQueryDto parm)
        {
            var response = _PpOutputAssyMasterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询制一OPH主表详情
        /// </summary>
        /// <param name="PomSfId"></param>
        /// <returns></returns>
        [HttpGet("{PomSfId}")]
        [ActionPermissionFilter(Permission = "pp:outputassymaster:query")]
        public IActionResult GetPpOutputAssyMaster(long PomSfId)
        {
            var response = _PpOutputAssyMasterService.GetInfo(PomSfId);
            
            var info = response.Adapt<PpOutputAssyMasterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加制一OPH主表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputassymaster:add")]
        [Log(Title = "制一OPH主表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOutputAssyMaster([FromBody] PpOutputAssyMasterDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputAssyMasterService.CheckInputUnique(parm.PomSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增制一OPH主表 '{parm.PomSfId}'失败(Add failed)，输入的制一OPH主表已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOutputAssyMaster>().ToCreate(HttpContext);

            var response = _PpOutputAssyMasterService.AddPpOutputAssyMaster(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新制一OPH主表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputassymaster:edit")]
        [Log(Title = "制一OPH主表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOutputAssyMaster([FromBody] PpOutputAssyMasterDto parm)
        {
            var modal = parm.Adapt<PpOutputAssyMaster>().ToUpdate(HttpContext);
            var response = _PpOutputAssyMasterService.UpdatePpOutputAssyMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除制一OPH主表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputassymaster:delete")]
        [Log(Title = "制一OPH主表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputAssyMaster([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOutputAssyMasterService.Delete(idArr, "删除制一OPH主表"));
        }

        /// <summary>
        /// 导出制一OPH主表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "制一OPH主表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputassymaster:export")]
        public IActionResult Export([FromQuery] PpOutputAssyMasterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOutputAssyMasterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "制一OPH主表", "制一OPH主表");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "制一OPH主表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputassymaster:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpOutputAssyMasterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOutputAssyMasterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOutputAssyMasterService.ImportPpOutputAssyMaster(list.Adapt<List<PpOutputAssyMaster>>()));
        }

        /// <summary>
        /// 制一OPH主表导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "制一OPH主表模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOutputAssyMasterImportTpl>() { }, "PpOutputAssyMaster_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}