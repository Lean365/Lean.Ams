using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 制技
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:21
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMasterPe")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterPeController : BaseController
    {
        /// <summary>
        /// 制技接口
        /// </summary>
        private readonly IPpEcMasterPeService _PpEcMasterPeService;

        public PpEcMasterPeController(IPpEcMasterPeService PpEcMasterPeService)
        {
            _PpEcMasterPeService = PpEcMasterPeService;
        }

        /// <summary>
        /// 查询制技列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpe:list")]
        public IActionResult QueryPpEcMasterPe([FromQuery] PpEcMasterPeQueryDto parm)
        {
            var response = _PpEcMasterPeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询制技详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpe:query")]
        public IActionResult GetPpEcMasterPe(long EcmSfId)
        {
            var response = _PpEcMasterPeService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterPeDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加制技
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmasterpe:add")]
        [Log(Title = "制技", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMasterPe([FromBody] PpEcMasterPeDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterPeService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增制技 '{parm.EcmSfId}'失败(Add failed)，输入的制技已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMasterPe>().ToCreate(HttpContext);

            var response = _PpEcMasterPeService.AddPpEcMasterPe(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新制技
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmasterpe:edit")]
        [Log(Title = "制技", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMasterPe([FromBody] PpEcMasterPeDto parm)
        {
            var modal = parm.Adapt<PpEcMasterPe>().ToUpdate(HttpContext);
            var response = _PpEcMasterPeService.UpdatePpEcMasterPe(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除制技
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpe:delete")]
        [Log(Title = "制技", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMasterPe([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterPeService.Delete(idArr, "删除制技"));
        }

        /// <summary>
        /// 导出制技
        /// </summary>
        /// <returns></returns>
        [Log(Title = "制技", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpe:export")]
        public IActionResult Export([FromQuery] PpEcMasterPeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterPeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "制技", "制技");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "制技导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmasterpe:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterPeDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterPeDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterPeService.ImportPpEcMasterPe(list.Adapt<List<PpEcMasterPe>>()));
        }

        /// <summary>
        /// 制技导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "制技模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterPeImportTpl>() { }, "PpEcMasterPe_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}