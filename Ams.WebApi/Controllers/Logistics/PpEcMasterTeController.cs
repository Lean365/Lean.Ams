using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 技术
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 16:05:58
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMasterTe")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterTeController : BaseController
    {
        /// <summary>
        /// 技术接口
        /// </summary>
        private readonly IPpEcMasterTeService _PpEcMasterTeService;

        public PpEcMasterTeController(IPpEcMasterTeService PpEcMasterTeService)
        {
            _PpEcMasterTeService = PpEcMasterTeService;
        }

        /// <summary>
        /// 查询技术列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmasterte:list")]
        public IActionResult QueryPpEcMasterTe([FromQuery] PpEcMasterTeQueryDto parm)
        {
            var response = _PpEcMasterTeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询技术详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterte:query")]
        public IActionResult GetPpEcMasterTe(long EcmSfId)
        {
            var response = _PpEcMasterTeService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterTeDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加技术
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmasterte:add")]
        [Log(Title = "技术", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMasterTe([FromBody] PpEcMasterTeDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterTeService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增技术 '{parm.EcmSfId}'失败(Add failed)，输入的技术已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMasterTe>().ToCreate(HttpContext);

            var response = _PpEcMasterTeService.AddPpEcMasterTe(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新技术
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmasterte:edit")]
        [Log(Title = "技术", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMasterTe([FromBody] PpEcMasterTeDto parm)
        {
            var modal = parm.Adapt<PpEcMasterTe>().ToUpdate(HttpContext);
            var response = _PpEcMasterTeService.UpdatePpEcMasterTe(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除技术
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterte:delete")]
        [Log(Title = "技术", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMasterTe([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterTeService.Delete(idArr, "删除技术"));
        }

        /// <summary>
        /// 导出技术
        /// </summary>
        /// <returns></returns>
        [Log(Title = "技术", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmasterte:export")]
        public IActionResult Export([FromQuery] PpEcMasterTeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterTeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "技术", "技术");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "技术导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmasterte:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterTeDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterTeDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterTeService.ImportPpEcMasterTe(list.Adapt<List<PpEcMasterTe>>()));
        }

        /// <summary>
        /// 技术导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "技术模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterTeImportTpl>() { }, "PpEcMasterTe_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}