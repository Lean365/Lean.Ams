using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// Pe设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:48
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlavePe")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlavePeController : BaseController
    {
        /// <summary>
        /// Pe设变接口
        /// </summary>
        private readonly IPpEcSlavePeService _PpEcSlavePeService;

        public PpEcSlavePeController(IPpEcSlavePeService PpEcSlavePeService)
        {
            _PpEcSlavePeService = PpEcSlavePeService;
        }

        /// <summary>
        /// 查询Pe设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslavepe:list")]
        public IActionResult QueryPpEcSlavePe([FromQuery] PpEcSlavePeQueryDto parm)
        {
            var response = _PpEcSlavePeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询Pe设变详情
        /// </summary>
        /// <param name="PeSfId"></param>
        /// <returns></returns>
        [HttpGet("{PeSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslavepe:query")]
        public IActionResult GetPpEcSlavePe(long PeSfId)
        {
            var response = _PpEcSlavePeService.GetInfo(PeSfId);
            
            var info = response.Adapt<PpEcSlavePeDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加Pe设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslavepe:add")]
        [Log(Title = "Pe设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlavePe([FromBody] PpEcSlavePeDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlavePeService.CheckInputUnique(parm.PeSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增Pe设变 '{parm.PeSfId}'失败(Add failed)，输入的Pe设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlavePe>().ToCreate(HttpContext);

            var response = _PpEcSlavePeService.AddPpEcSlavePe(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新Pe设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslavepe:edit")]
        [Log(Title = "Pe设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlavePe([FromBody] PpEcSlavePeDto parm)
        {
            var modal = parm.Adapt<PpEcSlavePe>().ToUpdate(HttpContext);
            var response = _PpEcSlavePeService.UpdatePpEcSlavePe(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除Pe设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslavepe:delete")]
        [Log(Title = "Pe设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlavePe([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlavePeService.Delete(idArr, "删除Pe设变"));
        }

        /// <summary>
        /// 导出Pe设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "Pe设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslavepe:export")]
        public IActionResult Export([FromQuery] PpEcSlavePeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlavePeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "Pe设变", "Pe设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "Pe设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslavepe:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlavePeDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlavePeDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlavePeService.ImportPpEcSlavePe(list.Adapt<List<PpEcSlavePe>>()));
        }

        /// <summary>
        /// Pe设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "Pe设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlavePeImportTpl>() { }, "PpEcSlavePe_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}