using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 受检
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:15
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMasterIqc")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterIqcController : BaseController
    {
        /// <summary>
        /// 受检接口
        /// </summary>
        private readonly IPpEcMasterIqcService _PpEcMasterIqcService;

        public PpEcMasterIqcController(IPpEcMasterIqcService PpEcMasterIqcService)
        {
            _PpEcMasterIqcService = PpEcMasterIqcService;
        }

        /// <summary>
        /// 查询受检列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmasteriqc:list")]
        public IActionResult QueryPpEcMasterIqc([FromQuery] PpEcMasterIqcQueryDto parm)
        {
            var response = _PpEcMasterIqcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询受检详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmasteriqc:query")]
        public IActionResult GetPpEcMasterIqc(long EcmSfId)
        {
            var response = _PpEcMasterIqcService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterIqcDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加受检
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmasteriqc:add")]
        [Log(Title = "受检", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMasterIqc([FromBody] PpEcMasterIqcDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterIqcService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增受检 '{parm.EcmSfId}'失败(Add failed)，输入的受检已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMasterIqc>().ToCreate(HttpContext);

            var response = _PpEcMasterIqcService.AddPpEcMasterIqc(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新受检
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmasteriqc:edit")]
        [Log(Title = "受检", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMasterIqc([FromBody] PpEcMasterIqcDto parm)
        {
            var modal = parm.Adapt<PpEcMasterIqc>().ToUpdate(HttpContext);
            var response = _PpEcMasterIqcService.UpdatePpEcMasterIqc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除受检
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmasteriqc:delete")]
        [Log(Title = "受检", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMasterIqc([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterIqcService.Delete(idArr, "删除受检"));
        }

        /// <summary>
        /// 导出受检
        /// </summary>
        /// <returns></returns>
        [Log(Title = "受检", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmasteriqc:export")]
        public IActionResult Export([FromQuery] PpEcMasterIqcQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterIqcService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "受检", "受检");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "受检导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmasteriqc:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterIqcDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterIqcDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterIqcService.ImportPpEcMasterIqc(list.Adapt<List<PpEcMasterIqc>>()));
        }

        /// <summary>
        /// 受检导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "受检模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterIqcImportTpl>() { }, "PpEcMasterIqc_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}