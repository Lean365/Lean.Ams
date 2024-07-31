using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 主设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:35:09
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMaster")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterController : BaseController
    {
        /// <summary>
        /// 主设变接口
        /// </summary>
        private readonly IPpEcMasterService _PpEcMasterService;

        public PpEcMasterController(IPpEcMasterService PpEcMasterService)
        {
            _PpEcMasterService = PpEcMasterService;
        }

        /// <summary>
        /// 查询主设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:list")]
        public IActionResult QueryPpEcMaster([FromQuery] PpEcMasterQueryDto parm)
        {
            var response = _PpEcMasterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询主设变详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:query")]
        public IActionResult GetPpEcMaster(long EcmSfId)
        {
            var response = _PpEcMasterService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加主设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmaster:add")]
        [Log(Title = "主设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMaster([FromBody] PpEcMasterDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增主设变 '{parm.EcmSfId}'失败(Add failed)，输入的主设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMaster>().ToCreate(HttpContext);

            var response = _PpEcMasterService.AddPpEcMaster(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新主设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmaster:edit")]
        [Log(Title = "主设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMaster([FromBody] PpEcMasterDto parm)
        {
            var modal = parm.Adapt<PpEcMaster>().ToUpdate(HttpContext);
            var response = _PpEcMasterService.UpdatePpEcMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除主设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:delete")]
        [Log(Title = "主设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMaster([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterService.Delete(idArr, "删除主设变"));
        }

        /// <summary>
        /// 导出主设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "主设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:export")]
        public IActionResult Export([FromQuery] PpEcMasterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "主设变", "主设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "主设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmaster:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterService.ImportPpEcMaster(list.Adapt<List<PpEcMaster>>()));
        }

        /// <summary>
        /// 主设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "主设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterImportTpl>() { }, "PpEcMaster_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}