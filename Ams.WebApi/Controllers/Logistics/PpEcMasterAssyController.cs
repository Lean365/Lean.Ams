using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 制一
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:10
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMasterAssy")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterAssyController : BaseController
    {
        /// <summary>
        /// 制一接口
        /// </summary>
        private readonly IPpEcMasterAssyService _PpEcMasterAssyService;

        public PpEcMasterAssyController(IPpEcMasterAssyService PpEcMasterAssyService)
        {
            _PpEcMasterAssyService = PpEcMasterAssyService;
        }

        /// <summary>
        /// 查询制一列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmasterassy:list")]
        public IActionResult QueryPpEcMasterAssy([FromQuery] PpEcMasterAssyQueryDto parm)
        {
            var response = _PpEcMasterAssyService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询制一详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterassy:query")]
        public IActionResult GetPpEcMasterAssy(long EcmSfId)
        {
            var response = _PpEcMasterAssyService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterAssyDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加制一
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmasterassy:add")]
        [Log(Title = "制一", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMasterAssy([FromBody] PpEcMasterAssyDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterAssyService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增制一 '{parm.EcmSfId}'失败(Add failed)，输入的制一已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMasterAssy>().ToCreate(HttpContext);

            var response = _PpEcMasterAssyService.AddPpEcMasterAssy(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新制一
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmasterassy:edit")]
        [Log(Title = "制一", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMasterAssy([FromBody] PpEcMasterAssyDto parm)
        {
            var modal = parm.Adapt<PpEcMasterAssy>().ToUpdate(HttpContext);
            var response = _PpEcMasterAssyService.UpdatePpEcMasterAssy(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除制一
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterassy:delete")]
        [Log(Title = "制一", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMasterAssy([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterAssyService.Delete(idArr, "删除制一"));
        }

        /// <summary>
        /// 导出制一
        /// </summary>
        /// <returns></returns>
        [Log(Title = "制一", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmasterassy:export")]
        public IActionResult Export([FromQuery] PpEcMasterAssyQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterAssyService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "制一", "制一");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "制一导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmasterassy:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterAssyDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterAssyDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterAssyService.ImportPpEcMasterAssy(list.Adapt<List<PpEcMasterAssy>>()));
        }

        /// <summary>
        /// 制一导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "制一模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterAssyImportTpl>() { }, "PpEcMasterAssy_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}