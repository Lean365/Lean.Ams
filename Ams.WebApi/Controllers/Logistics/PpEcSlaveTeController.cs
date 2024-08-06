using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// Te设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:03
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlaveTe")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlaveTeController : BaseController
    {
        /// <summary>
        /// Te设变接口
        /// </summary>
        private readonly IPpEcSlaveTeService _PpEcSlaveTeService;

        public PpEcSlaveTeController(IPpEcSlaveTeService PpEcSlaveTeService)
        {
            _PpEcSlaveTeService = PpEcSlaveTeService;
        }

        /// <summary>
        /// 查询Te设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslavete:list")]
        public IActionResult QueryPpEcSlaveTe([FromQuery] PpEcSlaveTeQueryDto parm)
        {
            var response = _PpEcSlaveTeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询Te设变详情
        /// </summary>
        /// <param name="TeSfId"></param>
        /// <returns></returns>
        [HttpGet("{TeSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslavete:query")]
        public IActionResult GetPpEcSlaveTe(long TeSfId)
        {
            var response = _PpEcSlaveTeService.GetInfo(TeSfId);
            
            var info = response.Adapt<PpEcSlaveTeDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加Te设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslavete:add")]
        [Log(Title = "Te设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlaveTe([FromBody] PpEcSlaveTeDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlaveTeService.CheckInputUnique(parm.TeSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增Te设变 '{parm.TeSfId}'失败(Add failed)，输入的Te设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlaveTe>().ToCreate(HttpContext);

            var response = _PpEcSlaveTeService.AddPpEcSlaveTe(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新Te设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslavete:edit")]
        [Log(Title = "Te设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlaveTe([FromBody] PpEcSlaveTeDto parm)
        {
            var modal = parm.Adapt<PpEcSlaveTe>().ToUpdate(HttpContext);
            var response = _PpEcSlaveTeService.UpdatePpEcSlaveTe(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除Te设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslavete:delete")]
        [Log(Title = "Te设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlaveTe([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlaveTeService.Delete(idArr, "删除Te设变"));
        }

        /// <summary>
        /// 导出Te设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "Te设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslavete:export")]
        public IActionResult Export([FromQuery] PpEcSlaveTeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlaveTeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "Te设变", "Te设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "Te设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslavete:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlaveTeDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlaveTeDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlaveTeService.ImportPpEcSlaveTe(list.Adapt<List<PpEcSlaveTe>>()));
        }

        /// <summary>
        /// Te设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "Te设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlaveTeImportTpl>() { }, "PpEcSlaveTe_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}