using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// Iqc设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:59
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlaveIqc")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlaveIqcController : BaseController
    {
        /// <summary>
        /// Iqc设变接口
        /// </summary>
        private readonly IPpEcSlaveIqcService _PpEcSlaveIqcService;

        public PpEcSlaveIqcController(IPpEcSlaveIqcService PpEcSlaveIqcService)
        {
            _PpEcSlaveIqcService = PpEcSlaveIqcService;
        }

        /// <summary>
        /// 查询Iqc设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslaveiqc:list")]
        public IActionResult QueryPpEcSlaveIqc([FromQuery] PpEcSlaveIqcQueryDto parm)
        {
            var response = _PpEcSlaveIqcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询Iqc设变详情
        /// </summary>
        /// <param name="IqcSfId"></param>
        /// <returns></returns>
        [HttpGet("{IqcSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslaveiqc:query")]
        public IActionResult GetPpEcSlaveIqc(long IqcSfId)
        {
            var response = _PpEcSlaveIqcService.GetInfo(IqcSfId);
            
            var info = response.Adapt<PpEcSlaveIqcDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加Iqc设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslaveiqc:add")]
        [Log(Title = "Iqc设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlaveIqc([FromBody] PpEcSlaveIqcDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlaveIqcService.CheckInputUnique(parm.IqcSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增Iqc设变 '{parm.IqcSfId}'失败(Add failed)，输入的Iqc设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlaveIqc>().ToCreate(HttpContext);

            var response = _PpEcSlaveIqcService.AddPpEcSlaveIqc(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新Iqc设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslaveiqc:edit")]
        [Log(Title = "Iqc设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlaveIqc([FromBody] PpEcSlaveIqcDto parm)
        {
            var modal = parm.Adapt<PpEcSlaveIqc>().ToUpdate(HttpContext);
            var response = _PpEcSlaveIqcService.UpdatePpEcSlaveIqc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除Iqc设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslaveiqc:delete")]
        [Log(Title = "Iqc设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlaveIqc([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlaveIqcService.Delete(idArr, "删除Iqc设变"));
        }

        /// <summary>
        /// 导出Iqc设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "Iqc设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslaveiqc:export")]
        public IActionResult Export([FromQuery] PpEcSlaveIqcQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlaveIqcService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "Iqc设变", "Iqc设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "Iqc设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslaveiqc:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlaveIqcDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlaveIqcDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlaveIqcService.ImportPpEcSlaveIqc(list.Adapt<List<PpEcSlaveIqc>>()));
        }

        /// <summary>
        /// Iqc设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "Iqc设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlaveIqcImportTpl>() { }, "PpEcSlaveIqc_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}