using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// oph主表
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:16:45)
    /// </summary>
    [Verify]
    [Route("logistics/OutputMaster")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class OutputMasterController : BaseController
    {
        /// <summary>
        /// oph主表接口
        /// </summary>
        private readonly IOutputMasterService _OutputMasterService;

        public OutputMasterController(IOutputMasterService OutputMasterService)
        {
            _OutputMasterService = OutputMasterService;
        }

        /// <summary>
        /// 查询oph主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryOutputMaster([FromQuery] OutputMasterQueryDto parm)
        {
            var response = _OutputMasterService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询oph主表详情
        /// </summary>
        /// <param name="PomSfid"></param>
        /// <returns></returns>
        [HttpGet("{PomSfid}")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:query")]
        public IActionResult GetOutputMaster(long PomSfid)
        {
            var response = _OutputMasterService.GetInfo(PomSfid);
            
            var info = response.Adapt<OutputMasterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加oph主表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputmaster:add")]
        [Log(Title = "oph主表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddOutputMaster([FromBody] OutputMasterDto parm)
        {
            var modal = parm.Adapt<OutputMaster>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_OutputMasterService.CheckEntryUnique(parm.PomSfid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)oph主表 '{parm.PomSfid}'失败(failed)，输入的(The entered)oph主表已存在(already exists)"));
            }
            var response = _OutputMasterService.AddOutputMaster(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新oph主表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputmaster:edit")]
        [Log(Title = "oph主表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateOutputMaster([FromBody] OutputMasterDto parm)
        {
            var modal = parm.Adapt<OutputMaster>().ToUpdate(HttpContext);
            var response = _OutputMasterService.UpdateOutputMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除oph主表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:delete")]
        [Log(Title = "oph主表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteOutputMaster([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_OutputMasterService.Delete(idArr, "删除oph主表"));
        }

        /// <summary>
        /// 导出oph主表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "oph主表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:export")]
        public IActionResult Export([FromQuery] OutputMasterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _OutputMasterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "oph主表", "oph主表","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入oph主表
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "oph主表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputmaster:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<OutputMasterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<OutputMasterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_OutputMasterService.ImportOutputMaster(list.Adapt<List<OutputMaster>>()));
        }

        /// <summary>
        /// oph主表导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "oph主表模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<OutputMasterDto>() { }, "OutputMasterTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}