using Microsoft.AspNetCore.Mvc;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;

namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// oph从表
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/28 15:35:46
    /// </summary>
    [Verify]
    [Route("logistics/PpOutputSlave")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOutputSlaveController : BaseController
    {
        /// <summary>
        /// oph从表接口
        /// </summary>
        private readonly IPpOutputSlaveService _PpOutputSlaveService;

        public PpOutputSlaveController(IPpOutputSlaveService PpOutputSlaveService)
        {
            _PpOutputSlaveService = PpOutputSlaveService;
        }

        /// <summary>
        /// 查询oph从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputslave:list")]
        public IActionResult QueryPpOutputSlave([FromQuery] PpOutputSlaveQueryDto parm)
        {
            var response = _PpOutputSlaveService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询oph从表详情
        /// </summary>
        /// <param name="PosSfid"></param>
        /// <returns></returns>
        [HttpGet("{PosSfid}")]
        [ActionPermissionFilter(Permission = "pp:outputslave:query")]
        public IActionResult GetPpOutputSlave(long PosSfid)
        {
            var response = _PpOutputSlaveService.GetInfo(PosSfid);
            
            var info = response.Adapt<PpOutputSlaveDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加oph从表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputslave:add")]
        [Log(Title = "oph从表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOutputSlave([FromBody] PpOutputSlaveDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputSlaveService.CheckInputUnique(parm.PosSfid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增oph从表 '{parm.PosSfid}'失败(Add failed)，输入的oph从表已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOutputSlave>().ToCreate(HttpContext);

            var response = _PpOutputSlaveService.AddPpOutputSlave(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新oph从表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputslave:update")]
        [Log(Title = "oph从表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOutputSlave([FromBody] PpOutputSlaveDto parm)
        {
            var modal = parm.Adapt<PpOutputSlave>().ToUpdate(HttpContext);
            var response = _PpOutputSlaveService.UpdatePpOutputSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除oph从表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputslave:delete")]
        [Log(Title = "oph从表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputSlave([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOutputSlaveService.Delete(idArr, "删除oph从表"));
        }

        /// <summary>
        /// 导出oph从表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "oph从表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputslave:export")]
        public IActionResult Export([FromQuery] PpOutputSlaveQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOutputSlaveService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "oph从表", "oph从表");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 批量导入
        /// oph从表数据
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "oph从表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputslave:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpOutputSlaveDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOutputSlaveDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOutputSlaveService.ImportPpOutputSlave(list.Adapt<List<PpOutputSlave>>()));
        }

        /// <summary>
        /// 导入模板下载
        /// oph从表
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "oph从表模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOutputSlaveImportTpl>() { }, "pp_output_slave_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}