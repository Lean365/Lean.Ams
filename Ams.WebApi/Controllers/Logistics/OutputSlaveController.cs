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
    /// oph从表
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("logistics/OutputSlave")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class OutputSlaveController : BaseController
    {
        /// <summary>
        /// oph从表接口
        /// </summary>
        private readonly IOutputSlaveService _OutputSlaveService;

        public OutputSlaveController(IOutputSlaveService OutputSlaveService)
        {
            _OutputSlaveService = OutputSlaveService;
        }

        /// <summary>
        /// 查询oph从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputslave:list")]
        public IActionResult QueryOutputSlave([FromQuery] OutputSlaveQueryDto parm)
        {
            var response = _OutputSlaveService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询oph从表详情
        /// </summary>
        /// <param name="PosSfid"></param>
        /// <returns></returns>
        [HttpGet("{PosSfid}")]
        [ActionPermissionFilter(Permission = "pp:outputslave:query")]
        public IActionResult GetOutputSlave(long PosSfid)
        {
            var response = _OutputSlaveService.GetInfo(PosSfid);
            
            var info = response.Adapt<OutputSlaveDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加oph从表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputslave:add")]
        [Log(Title = "oph从表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddOutputSlave([FromBody] OutputSlaveDto parm)
        {
            var modal = parm.Adapt<OutputSlave>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_OutputSlaveService.CheckEntryUnique(parm.PosSfid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)oph从表 '{parm.PosSfid}'失败(failed)，输入的(The entered)oph从表已存在(already exists)"));
            }
            var response = _OutputSlaveService.AddOutputSlave(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新oph从表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputslave:edit")]
        [Log(Title = "oph从表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateOutputSlave([FromBody] OutputSlaveDto parm)
        {
            var modal = parm.Adapt<OutputSlave>().ToUpdate(HttpContext);
            var response = _OutputSlaveService.UpdateOutputSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除oph从表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputslave:delete")]
        [Log(Title = "oph从表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteOutputSlave([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_OutputSlaveService.Delete(idArr, "删除oph从表"));
        }

        /// <summary>
        /// 导出oph从表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "oph从表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputslave:export")]
        public IActionResult Export([FromQuery] OutputSlaveQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _OutputSlaveService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "oph从表", "oph从表","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入oph从表
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "oph从表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputslave:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<OutputSlaveDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<OutputSlaveDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_OutputSlaveService.ImportOutputSlave(list.Adapt<List<OutputSlave>>()));
        }

        /// <summary>
        /// oph从表导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "oph从表模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<OutputSlaveDto>() { }, "OutputSlaveTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}