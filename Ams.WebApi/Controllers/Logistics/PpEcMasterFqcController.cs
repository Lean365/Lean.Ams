using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 品管
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:12
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMasterFqc")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterFqcController : BaseController
    {
        /// <summary>
        /// 品管接口
        /// </summary>
        private readonly IPpEcMasterFqcService _PpEcMasterFqcService;

        public PpEcMasterFqcController(IPpEcMasterFqcService PpEcMasterFqcService)
        {
            _PpEcMasterFqcService = PpEcMasterFqcService;
        }

        /// <summary>
        /// 查询品管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmasterfqc:list")]
        public IActionResult QueryPpEcMasterFqc([FromQuery] PpEcMasterFqcQueryDto parm)
        {
            var response = _PpEcMasterFqcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询品管详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterfqc:query")]
        public IActionResult GetPpEcMasterFqc(long EcmSfId)
        {
            var response = _PpEcMasterFqcService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterFqcDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加品管
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmasterfqc:add")]
        [Log(Title = "品管", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMasterFqc([FromBody] PpEcMasterFqcDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterFqcService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增品管 '{parm.EcmSfId}'失败(Add failed)，输入的品管已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMasterFqc>().ToCreate(HttpContext);

            var response = _PpEcMasterFqcService.AddPpEcMasterFqc(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新品管
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmasterfqc:edit")]
        [Log(Title = "品管", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMasterFqc([FromBody] PpEcMasterFqcDto parm)
        {
            var modal = parm.Adapt<PpEcMasterFqc>().ToUpdate(HttpContext);
            var response = _PpEcMasterFqcService.UpdatePpEcMasterFqc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除品管
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterfqc:delete")]
        [Log(Title = "品管", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMasterFqc([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterFqcService.Delete(idArr, "删除品管"));
        }

        /// <summary>
        /// 导出品管
        /// </summary>
        /// <returns></returns>
        [Log(Title = "品管", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmasterfqc:export")]
        public IActionResult Export([FromQuery] PpEcMasterFqcQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterFqcService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "品管", "品管");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "品管导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmasterfqc:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterFqcDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterFqcDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterFqcService.ImportPpEcMasterFqc(list.Adapt<List<PpEcMasterFqc>>()));
        }

        /// <summary>
        /// 品管导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "品管模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterFqcImportTpl>() { }, "PpEcMasterFqc_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}