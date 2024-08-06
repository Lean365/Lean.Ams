using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 部管
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 16:02:20
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMasterMm")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterMmController : BaseController
    {
        /// <summary>
        /// 部管接口
        /// </summary>
        private readonly IPpEcMasterMmService _PpEcMasterMmService;

        public PpEcMasterMmController(IPpEcMasterMmService PpEcMasterMmService)
        {
            _PpEcMasterMmService = PpEcMasterMmService;
        }

        /// <summary>
        /// 查询部管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmastermm:list")]
        public IActionResult QueryPpEcMasterMm([FromQuery] PpEcMasterMmQueryDto parm)
        {
            var response = _PpEcMasterMmService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询部管详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmastermm:query")]
        public IActionResult GetPpEcMasterMm(long EcmSfId)
        {
            var response = _PpEcMasterMmService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterMmDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加部管
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmastermm:add")]
        [Log(Title = "部管", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMasterMm([FromBody] PpEcMasterMmDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterMmService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增部管 '{parm.EcmSfId}'失败(Add failed)，输入的部管已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMasterMm>().ToCreate(HttpContext);

            var response = _PpEcMasterMmService.AddPpEcMasterMm(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新部管
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmastermm:edit")]
        [Log(Title = "部管", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMasterMm([FromBody] PpEcMasterMmDto parm)
        {
            var modal = parm.Adapt<PpEcMasterMm>().ToUpdate(HttpContext);
            var response = _PpEcMasterMmService.UpdatePpEcMasterMm(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除部管
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmastermm:delete")]
        [Log(Title = "部管", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMasterMm([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterMmService.Delete(idArr, "删除部管"));
        }

        /// <summary>
        /// 导出部管
        /// </summary>
        /// <returns></returns>
        [Log(Title = "部管", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmastermm:export")]
        public IActionResult Export([FromQuery] PpEcMasterMmQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterMmService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "部管", "部管");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "部管导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmastermm:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterMmDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterMmDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterMmService.ImportPpEcMasterMm(list.Adapt<List<PpEcMasterMm>>()));
        }

        /// <summary>
        /// 部管导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "部管模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterMmImportTpl>() { }, "PpEcMasterMm_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}