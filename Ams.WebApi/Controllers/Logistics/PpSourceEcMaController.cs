using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 主源设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:08:51
    /// </summary>
    [Verify]
    [Route("Logistics/PpSourceEcMa")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpSourceEcMaController : BaseController
    {
        /// <summary>
        /// 主源设变接口
        /// </summary>
        private readonly IPpSourceEcMaService _PpSourceEcMaService;

        public PpSourceEcMaController(IPpSourceEcMaService PpSourceEcMaService)
        {
            _PpSourceEcMaService = PpSourceEcMaService;
        }

        /// <summary>
        /// 查询主源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:sourceecma:list")]
        public IActionResult QueryPpSourceEcMa([FromQuery] PpSourceEcMaQueryDto parm)
        {
            var response = _PpSourceEcMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询主源设变详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        [HttpGet("{SfId}")]
        [ActionPermissionFilter(Permission = "pp:sourceecma:query")]
        public IActionResult GetPpSourceEcMa(long SfId)
        {
            var response = _PpSourceEcMaService.GetInfo(SfId);
            
            var info = response.Adapt<PpSourceEcMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加主源设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:sourceecma:add")]
        [Log(Title = "主源设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpSourceEcMa([FromBody] PpSourceEcMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpSourceEcMaService.CheckInputUnique(parm.SfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增主源设变 '{parm.SfId}'失败(Add failed)，输入的主源设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpSourceEcMa>().ToCreate(HttpContext);

            var response = _PpSourceEcMaService.AddPpSourceEcMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新主源设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:sourceecma:edit")]
        [Log(Title = "主源设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpSourceEcMa([FromBody] PpSourceEcMaDto parm)
        {
            var modal = parm.Adapt<PpSourceEcMa>().ToUpdate(HttpContext);
            var response = _PpSourceEcMaService.UpdatePpSourceEcMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除主源设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:sourceecma:delete")]
        [Log(Title = "主源设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpSourceEcMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpSourceEcMaService.Delete(idArr, "删除主源设变"));
        }

        /// <summary>
        /// 导出主源设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "主源设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:sourceecma:export")]
        public IActionResult Export([FromQuery] PpSourceEcMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpSourceEcMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "主源设变", "主源设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "主源设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:sourceecma:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpSourceEcMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpSourceEcMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpSourceEcMaService.ImportPpSourceEcMa(list.Adapt<List<PpSourceEcMa>>()));
        }

        /// <summary>
        /// 主源设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "主源设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpSourceEcMaImportTpl>() { }, "PpSourceEcMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}