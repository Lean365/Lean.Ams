using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 从设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:30:08
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlave")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlaveController : BaseController
    {
        /// <summary>
        /// 从设变接口
        /// </summary>
        private readonly IPpEcSlaveService _PpEcSlaveService;

        public PpEcSlaveController(IPpEcSlaveService PpEcSlaveService)
        {
            _PpEcSlaveService = PpEcSlaveService;
        }

        /// <summary>
        /// 查询从设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslave:list")]
        public IActionResult QueryPpEcSlave([FromQuery] PpEcSlaveQueryDto parm)
        {
            var response = _PpEcSlaveService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询从设变详情
        /// </summary>
        /// <param name="EcsSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcsSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslave:query")]
        public IActionResult GetPpEcSlave(long EcsSfId)
        {
            var response = _PpEcSlaveService.GetInfo(EcsSfId);
            
            var info = response.Adapt<PpEcSlaveDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加从设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslave:add")]
        [Log(Title = "从设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlave([FromBody] PpEcSlaveDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlaveService.CheckInputUnique(parm.EcsSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增从设变 '{parm.EcsSfId}'失败(Add failed)，输入的从设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlave>().ToCreate(HttpContext);

            var response = _PpEcSlaveService.AddPpEcSlave(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新从设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslave:edit")]
        [Log(Title = "从设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlave([FromBody] PpEcSlaveDto parm)
        {
            var modal = parm.Adapt<PpEcSlave>().ToUpdate(HttpContext);
            var response = _PpEcSlaveService.UpdatePpEcSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除从设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslave:delete")]
        [Log(Title = "从设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlave([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlaveService.Delete(idArr, "删除从设变"));
        }

        /// <summary>
        /// 导出从设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "从设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslave:export")]
        public IActionResult Export([FromQuery] PpEcSlaveQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlaveService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "从设变", "从设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "从设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslave:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlaveDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlaveDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlaveService.ImportPpEcSlave(list.Adapt<List<PpEcSlave>>()));
        }

        /// <summary>
        /// 从设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "从设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlaveImportTpl>() { }, "PpEcSlave_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}