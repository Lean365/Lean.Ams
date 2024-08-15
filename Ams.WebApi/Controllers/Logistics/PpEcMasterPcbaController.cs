using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 制二
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:18
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMasterPcba")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterPcbaController : BaseController
    {
        /// <summary>
        /// 制二接口
        /// </summary>
        private readonly IPpEcMasterPcbaService _PpEcMasterPcbaService;

        public PpEcMasterPcbaController(IPpEcMasterPcbaService PpEcMasterPcbaService)
        {
            _PpEcMasterPcbaService = PpEcMasterPcbaService;
        }

        /// <summary>
        /// 查询制二列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpcba:list")]
        public IActionResult QueryPpEcMasterPcba([FromQuery] PpEcMasterPcbaQueryDto parm)
        {
            var response = _PpEcMasterPcbaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询制二详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpcba:query")]
        public IActionResult GetPpEcMasterPcba(long EcmSfId)
        {
            var response = _PpEcMasterPcbaService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterPcbaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加制二
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmasterpcba:add")]
        [Log(Title = "制二", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMasterPcba([FromBody] PpEcMasterPcbaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterPcbaService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增制二 '{parm.EcmSfId}'失败(Add failed)，输入的制二已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMasterPcba>().ToCreate(HttpContext);

            var response = _PpEcMasterPcbaService.AddPpEcMasterPcba(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新制二
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmasterpcba:edit")]
        [Log(Title = "制二", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMasterPcba([FromBody] PpEcMasterPcbaDto parm)
        {
            var modal = parm.Adapt<PpEcMasterPcba>().ToUpdate(HttpContext);
            var response = _PpEcMasterPcbaService.UpdatePpEcMasterPcba(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除制二
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpcba:delete")]
        [Log(Title = "制二", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMasterPcba([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterPcbaService.Delete(idArr, "删除制二"));
        }

        /// <summary>
        /// 导出制二
        /// </summary>
        /// <returns></returns>
        [Log(Title = "制二", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpcba:export")]
        public IActionResult Export([FromQuery] PpEcMasterPcbaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterPcbaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "制二", "制二");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "制二导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmasterpcba:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterPcbaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterPcbaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterPcbaService.ImportPpEcMasterPcba(list.Adapt<List<PpEcMasterPcba>>()));
        }

        /// <summary>
        /// 制二导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "制二模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterPcbaImportTpl>() { }, "PpEcMasterPcba_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}