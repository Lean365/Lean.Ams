using Microsoft.AspNetCore.Mvc;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;

namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// oph主表
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/29 8:56:11
    /// </summary>
    [Verify]
    [Route("logistics/PpOutputMaster")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOutputMasterController : BaseController
    {
        /// <summary>
        /// oph主表接口
        /// </summary>
        private readonly IPpOutputMasterService _PpOutputMasterService;

        public PpOutputMasterController(IPpOutputMasterService PpOutputMasterService)
        {
            _PpOutputMasterService = PpOutputMasterService;
        }

        /// <summary>
        /// 查询oph主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryPpOutputMaster([FromQuery] PpOutputMasterQueryDto parm)
        {
            var response = _PpOutputMasterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询oph主表详情
        /// </summary>
        /// <param name="PomSfid"></param>
        /// <returns></returns>
        [HttpGet("{PomSfid}")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:query")]
        public IActionResult GetPpOutputMaster(long PomSfid)
        {
            var response = _PpOutputMasterService.GetInfo(PomSfid);
            
            var info = response.Adapt<PpOutputMasterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加oph主表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputmaster:add")]
        [Log(Title = "oph主表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOutputMaster([FromBody] PpOutputMasterDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputMasterService.CheckInputUnique(parm.PomSfid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增oph主表 '{parm.PomSfid}'失败(Add failed)，输入的oph主表已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOutputMaster>().ToCreate(HttpContext);

            var response = _PpOutputMasterService.AddPpOutputMaster(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新oph主表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputmaster:update")]
        [Log(Title = "oph主表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOutputMaster([FromBody] PpOutputMasterDto parm)
        {
            var modal = parm.Adapt<PpOutputMaster>().ToUpdate(HttpContext);
            var response = _PpOutputMasterService.UpdatePpOutputMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除oph主表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:delete")]
        [Log(Title = "oph主表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputMaster([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOutputMasterService.Delete(idArr, "删除oph主表"));
        }

        /// <summary>
        /// 导出oph主表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "oph主表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:export")]
        public IActionResult Export([FromQuery] PpOutputMasterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOutputMasterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "oph主表", "oph主表");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 批量导入
        /// oph主表数据
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "oph主表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputmaster:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpOutputMasterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOutputMasterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOutputMasterService.ImportPpOutputMaster(list.Adapt<List<PpOutputMaster>>()));
        }

        /// <summary>
        /// 导入模板下载
        /// oph主表
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "oph主表模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOutputMasterImportTpl>() { }, "pp_output_master_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}