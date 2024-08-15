using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 检查日报ma
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:30
    /// </summary>
    [Verify]
    [Route("Logistics/PpInspPcbaMa")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpInspPcbaMaController : BaseController
    {
        /// <summary>
        /// 检查日报ma接口
        /// </summary>
        private readonly IPpInspPcbaMaService _PpInspPcbaMaService;

        public PpInspPcbaMaController(IPpInspPcbaMaService PpInspPcbaMaService)
        {
            _PpInspPcbaMaService = PpInspPcbaMaService;
        }

        /// <summary>
        /// 查询检查日报ma列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:inscbama:list")]
        public IActionResult QueryPpInspPcbaMa([FromQuery] PpInspPcbaMaQueryDto parm)
        {
            var response = _PpInspPcbaMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询检查日报ma详情
        /// </summary>
        /// <param name="PdiSfId"></param>
        /// <returns></returns>
        [HttpGet("{PdiSfId}")]
        [ActionPermissionFilter(Permission = "pp:inscbama:query")]
        public IActionResult GetPpInspPcbaMa(long PdiSfId)
        {
            var response = _PpInspPcbaMaService.GetInfo(PdiSfId);
            
            var info = response.Adapt<PpInspPcbaMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加检查日报ma
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:inscbama:add")]
        [Log(Title = "检查日报ma", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpInspPcbaMa([FromBody] PpInspPcbaMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpInspPcbaMaService.CheckInputUnique(parm.PdiSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增检查日报ma '{parm.PdiSfId}'失败(Add failed)，输入的检查日报ma已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpInspPcbaMa>().ToCreate(HttpContext);

            var response = _PpInspPcbaMaService.AddPpInspPcbaMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新检查日报ma
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:inscbama:edit")]
        [Log(Title = "检查日报ma", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpInspPcbaMa([FromBody] PpInspPcbaMaDto parm)
        {
            var modal = parm.Adapt<PpInspPcbaMa>().ToUpdate(HttpContext);
            var response = _PpInspPcbaMaService.UpdatePpInspPcbaMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除检查日报ma
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:inscbama:delete")]
        [Log(Title = "检查日报ma", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpInspPcbaMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpInspPcbaMaService.Delete(idArr, "删除检查日报ma"));
        }

        /// <summary>
        /// 导出检查日报ma
        /// </summary>
        /// <returns></returns>
        [Log(Title = "检查日报ma", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:inscbama:export")]
        public IActionResult Export([FromQuery] PpInspPcbaMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpInspPcbaMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "检查日报ma", "检查日报ma");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "检查日报ma导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:inscbama:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpInspPcbaMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpInspPcbaMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpInspPcbaMaService.ImportPpInspPcbaMa(list.Adapt<List<PpInspPcbaMa>>()));
        }

        /// <summary>
        /// 检查日报ma导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "检查日报ma模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpInspPcbaMaImportTpl>() { }, "PpInspPcbaMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}