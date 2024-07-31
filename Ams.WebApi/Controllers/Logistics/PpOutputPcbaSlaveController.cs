using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 制二OPH从表
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:07:20
    /// </summary>
    [Verify]
    [Route("Logistics/PpOutputPcbaSlave")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOutputPcbaSlaveController : BaseController
    {
        /// <summary>
        /// 制二OPH从表接口
        /// </summary>
        private readonly IPpOutputPcbaSlaveService _PpOutputPcbaSlaveService;

        public PpOutputPcbaSlaveController(IPpOutputPcbaSlaveService PpOutputPcbaSlaveService)
        {
            _PpOutputPcbaSlaveService = PpOutputPcbaSlaveService;
        }

        /// <summary>
        /// 查询制二OPH从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslave:list")]
        public IActionResult QueryPpOutputPcbaSlave([FromQuery] PpOutputPcbaSlaveQueryDto parm)
        {
            var response = _PpOutputPcbaSlaveService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询制二OPH从表详情
        /// </summary>
        /// <param name="PosSfId"></param>
        /// <returns></returns>
        [HttpGet("{PosSfId}")]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslave:query")]
        public IActionResult GetPpOutputPcbaSlave(long PosSfId)
        {
            var response = _PpOutputPcbaSlaveService.GetInfo(PosSfId);
            
            var info = response.Adapt<PpOutputPcbaSlaveDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加制二OPH从表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslave:add")]
        [Log(Title = "制二OPH从表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOutputPcbaSlave([FromBody] PpOutputPcbaSlaveDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputPcbaSlaveService.CheckInputUnique(parm.PosSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增制二OPH从表 '{parm.PosSfId}'失败(Add failed)，输入的制二OPH从表已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOutputPcbaSlave>().ToCreate(HttpContext);

            var response = _PpOutputPcbaSlaveService.AddPpOutputPcbaSlave(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新制二OPH从表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslave:edit")]
        [Log(Title = "制二OPH从表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOutputPcbaSlave([FromBody] PpOutputPcbaSlaveDto parm)
        {
            var modal = parm.Adapt<PpOutputPcbaSlave>().ToUpdate(HttpContext);
            var response = _PpOutputPcbaSlaveService.UpdatePpOutputPcbaSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除制二OPH从表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslave:delete")]
        [Log(Title = "制二OPH从表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputPcbaSlave([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOutputPcbaSlaveService.Delete(idArr, "删除制二OPH从表"));
        }

        /// <summary>
        /// 导出制二OPH从表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "制二OPH从表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslave:export")]
        public IActionResult Export([FromQuery] PpOutputPcbaSlaveQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOutputPcbaSlaveService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "制二OPH从表", "制二OPH从表");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "制二OPH从表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslave:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpOutputPcbaSlaveDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOutputPcbaSlaveDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOutputPcbaSlaveService.ImportPpOutputPcbaSlave(list.Adapt<List<PpOutputPcbaSlave>>()));
        }

        /// <summary>
        /// 制二OPH从表导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "制二OPH从表模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOutputPcbaSlaveImportTpl>() { }, "PpOutputPcbaSlave_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}