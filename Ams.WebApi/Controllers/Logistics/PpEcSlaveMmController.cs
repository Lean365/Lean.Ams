using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// Mm设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:14
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlaveMm")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlaveMmController : BaseController
    {
        /// <summary>
        /// Mm设变接口
        /// </summary>
        private readonly IPpEcSlaveMmService _PpEcSlaveMmService;

        public PpEcSlaveMmController(IPpEcSlaveMmService PpEcSlaveMmService)
        {
            _PpEcSlaveMmService = PpEcSlaveMmService;
        }

        /// <summary>
        /// 查询Mm设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslavemm:list")]
        public IActionResult QueryPpEcSlaveMm([FromQuery] PpEcSlaveMmQueryDto parm)
        {
            var response = _PpEcSlaveMmService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询Mm设变详情
        /// </summary>
        /// <param name="MmSfId"></param>
        /// <returns></returns>
        [HttpGet("{MmSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslavemm:query")]
        public IActionResult GetPpEcSlaveMm(long MmSfId)
        {
            var response = _PpEcSlaveMmService.GetInfo(MmSfId);
            
            var info = response.Adapt<PpEcSlaveMmDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加Mm设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslavemm:add")]
        [Log(Title = "Mm设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlaveMm([FromBody] PpEcSlaveMmDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlaveMmService.CheckInputUnique(parm.MmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增Mm设变 '{parm.MmSfId}'失败(Add failed)，输入的Mm设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlaveMm>().ToCreate(HttpContext);

            var response = _PpEcSlaveMmService.AddPpEcSlaveMm(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新Mm设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslavemm:edit")]
        [Log(Title = "Mm设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlaveMm([FromBody] PpEcSlaveMmDto parm)
        {
            var modal = parm.Adapt<PpEcSlaveMm>().ToUpdate(HttpContext);
            var response = _PpEcSlaveMmService.UpdatePpEcSlaveMm(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除Mm设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslavemm:delete")]
        [Log(Title = "Mm设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlaveMm([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlaveMmService.Delete(idArr, "删除Mm设变"));
        }

        /// <summary>
        /// 导出Mm设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "Mm设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslavemm:export")]
        public IActionResult Export([FromQuery] PpEcSlaveMmQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlaveMmService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "Mm设变", "Mm设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "Mm设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslavemm:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlaveMmDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlaveMmDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlaveMmService.ImportPpEcSlaveMm(list.Adapt<List<PpEcSlaveMm>>()));
        }

        /// <summary>
        /// Mm设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "Mm设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlaveMmImportTpl>() { }, "PpEcSlaveMm_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}