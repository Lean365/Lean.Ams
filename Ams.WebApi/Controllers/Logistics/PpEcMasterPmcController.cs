using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 生管
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:28
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMasterPmc")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterPmcController : BaseController
    {
        /// <summary>
        /// 生管接口
        /// </summary>
        private readonly IPpEcMasterPmcService _PpEcMasterPmcService;

        public PpEcMasterPmcController(IPpEcMasterPmcService PpEcMasterPmcService)
        {
            _PpEcMasterPmcService = PpEcMasterPmcService;
        }

        /// <summary>
        /// 查询生管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpmc:list")]
        public IActionResult QueryPpEcMasterPmc([FromQuery] PpEcMasterPmcQueryDto parm)
        {
            var response = _PpEcMasterPmcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询生管详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpmc:query")]
        public IActionResult GetPpEcMasterPmc(long EcmSfId)
        {
            var response = _PpEcMasterPmcService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterPmcDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生管
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmasterpmc:add")]
        [Log(Title = "生管", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMasterPmc([FromBody] PpEcMasterPmcDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterPmcService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增生管 '{parm.EcmSfId}'失败(Add failed)，输入的生管已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMasterPmc>().ToCreate(HttpContext);

            var response = _PpEcMasterPmcService.AddPpEcMasterPmc(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生管
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmasterpmc:edit")]
        [Log(Title = "生管", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMasterPmc([FromBody] PpEcMasterPmcDto parm)
        {
            var modal = parm.Adapt<PpEcMasterPmc>().ToUpdate(HttpContext);
            var response = _PpEcMasterPmcService.UpdatePpEcMasterPmc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生管
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpmc:delete")]
        [Log(Title = "生管", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMasterPmc([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterPmcService.Delete(idArr, "删除生管"));
        }

        /// <summary>
        /// 导出生管
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生管", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpmc:export")]
        public IActionResult Export([FromQuery] PpEcMasterPmcQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterPmcService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生管", "生管");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "生管导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmasterpmc:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterPmcDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterPmcDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterPmcService.ImportPpEcMasterPmc(list.Adapt<List<PpEcMasterPmc>>()));
        }

        /// <summary>
        /// 生管导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "生管模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterPmcImportTpl>() { }, "PpEcMasterPmc_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}