using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// Pmc设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:45:42
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlavePmc")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlavePmcController : BaseController
    {
        /// <summary>
        /// Pmc设变接口
        /// </summary>
        private readonly IPpEcSlavePmcService _PpEcSlavePmcService;

        public PpEcSlavePmcController(IPpEcSlavePmcService PpEcSlavePmcService)
        {
            _PpEcSlavePmcService = PpEcSlavePmcService;
        }

        /// <summary>
        /// 查询Pmc设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslavepmc:list")]
        public IActionResult QueryPpEcSlavePmc([FromQuery] PpEcSlavePmcQueryDto parm)
        {
            var response = _PpEcSlavePmcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询Pmc设变详情
        /// </summary>
        /// <param name="PmcSfId"></param>
        /// <returns></returns>
        [HttpGet("{PmcSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslavepmc:query")]
        public IActionResult GetPpEcSlavePmc(long PmcSfId)
        {
            var response = _PpEcSlavePmcService.GetInfo(PmcSfId);
            
            var info = response.Adapt<PpEcSlavePmcDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加Pmc设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslavepmc:add")]
        [Log(Title = "Pmc设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlavePmc([FromBody] PpEcSlavePmcDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlavePmcService.CheckInputUnique(parm.PmcSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增Pmc设变 '{parm.PmcSfId}'失败(Add failed)，输入的Pmc设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlavePmc>().ToCreate(HttpContext);

            var response = _PpEcSlavePmcService.AddPpEcSlavePmc(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新Pmc设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslavepmc:edit")]
        [Log(Title = "Pmc设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlavePmc([FromBody] PpEcSlavePmcDto parm)
        {
            var modal = parm.Adapt<PpEcSlavePmc>().ToUpdate(HttpContext);
            var response = _PpEcSlavePmcService.UpdatePpEcSlavePmc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除Pmc设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslavepmc:delete")]
        [Log(Title = "Pmc设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlavePmc([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlavePmcService.Delete(idArr, "删除Pmc设变"));
        }

        /// <summary>
        /// 导出Pmc设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "Pmc设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslavepmc:export")]
        public IActionResult Export([FromQuery] PpEcSlavePmcQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlavePmcService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "Pmc设变", "Pmc设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "Pmc设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslavepmc:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlavePmcDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlavePmcDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlavePmcService.ImportPpEcSlavePmc(list.Adapt<List<PpEcSlavePmc>>()));
        }

        /// <summary>
        /// Pmc设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "Pmc设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlavePmcImportTpl>() { }, "PpEcSlavePmc_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}