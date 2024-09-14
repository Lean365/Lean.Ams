using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 设变明细
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/13 8:13:42
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlave")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlaveController : BaseController
    {
        /// <summary>
        /// 设变明细接口
        /// </summary>
        private readonly IPpEcSlaveService _PpEcSlaveService;

        public PpEcSlaveController(IPpEcSlaveService PpEcSlaveService)
        {
            _PpEcSlaveService = PpEcSlaveService;
        }

        /// <summary>
        /// 查询设变明细列表
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
        /// 查询设变明细详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:ecslave:query")]
        public IActionResult GetPpEcSlave(long Id)
        {
            var response = _PpEcSlaveService.GetInfo(Id);
            
            var info = response.Adapt<PpEcSlaveDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加设变明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslave:add")]
        [Log(Title = "设变明细", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpEcSlave([FromBody] PpEcSlaveDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlaveService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增设变明细 '{parm.Id}'失败(Add failed)，输入的设变明细已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlave>().ToCreate(HttpContext);

            var response = _PpEcSlaveService.AddPpEcSlave(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新设变明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslave:edit")]
        [Log(Title = "设变明细", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpEcSlave([FromBody] PpEcSlaveDto parm)
        {
            var modal = parm.Adapt<PpEcSlave>().ToUpdate(HttpContext);
            var response = _PpEcSlaveService.UpdatePpEcSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除设变明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslave:delete")]
        [Log(Title = "设变明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlave([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlaveService.Delete(idArr, "删除设变明细"));
        }

        /// <summary>
        /// 导出设变明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "设变明细导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
            var result = ExportExcelMini(list, "设变明细", "设变明细");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入设变明细
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "设变明细导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslave:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpEcSlaveDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlaveDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlaveService.ImportPpEcSlave(list.Adapt<List<PpEcSlave>>()));
        }

        /// <summary>
        /// 设变明细
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "设变明细模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlaveImportTpl>() { }, "PpEcSlave_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}