using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 采购
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:25
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMasterPur")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterPurController : BaseController
    {
        /// <summary>
        /// 采购接口
        /// </summary>
        private readonly IPpEcMasterPurService _PpEcMasterPurService;

        public PpEcMasterPurController(IPpEcMasterPurService PpEcMasterPurService)
        {
            _PpEcMasterPurService = PpEcMasterPurService;
        }

        /// <summary>
        /// 查询采购列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpur:list")]
        public IActionResult QueryPpEcMasterPur([FromQuery] PpEcMasterPurQueryDto parm)
        {
            var response = _PpEcMasterPurService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询采购详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{EcmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpur:query")]
        public IActionResult GetPpEcMasterPur(long EcmSfId)
        {
            var response = _PpEcMasterPurService.GetInfo(EcmSfId);
            
            var info = response.Adapt<PpEcMasterPurDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加采购
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmasterpur:add")]
        [Log(Title = "采购", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMasterPur([FromBody] PpEcMasterPurDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterPurService.CheckInputUnique(parm.EcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增采购 '{parm.EcmSfId}'失败(Add failed)，输入的采购已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMasterPur>().ToCreate(HttpContext);

            var response = _PpEcMasterPurService.AddPpEcMasterPur(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新采购
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmasterpur:edit")]
        [Log(Title = "采购", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMasterPur([FromBody] PpEcMasterPurDto parm)
        {
            var modal = parm.Adapt<PpEcMasterPur>().ToUpdate(HttpContext);
            var response = _PpEcMasterPurService.UpdatePpEcMasterPur(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除采购
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpur:delete")]
        [Log(Title = "采购", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMasterPur([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterPurService.Delete(idArr, "删除采购"));
        }

        /// <summary>
        /// 导出采购
        /// </summary>
        /// <returns></returns>
        [Log(Title = "采购", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmasterpur:export")]
        public IActionResult Export([FromQuery] PpEcMasterPurQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterPurService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "采购", "采购");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "采购导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmasterpur:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcMasterPurDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterPurDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterPurService.ImportPpEcMasterPur(list.Adapt<List<PpEcMasterPur>>()));
        }

        /// <summary>
        /// 采购导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "采购模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterPurImportTpl>() { }, "PpEcMasterPur_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}