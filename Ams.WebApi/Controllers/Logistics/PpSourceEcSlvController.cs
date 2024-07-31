using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 从源设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:04:44
    /// </summary>
    [Verify]
    [Route("Logistics/PpSourceEcSlv")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpSourceEcSlvController : BaseController
    {
        /// <summary>
        /// 从源设变接口
        /// </summary>
        private readonly IPpSourceEcSlvService _PpSourceEcSlvService;

        public PpSourceEcSlvController(IPpSourceEcSlvService PpSourceEcSlvService)
        {
            _PpSourceEcSlvService = PpSourceEcSlvService;
        }

        /// <summary>
        /// 查询从源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:sourceecslv:list")]
        public IActionResult QueryPpSourceEcSlv([FromQuery] PpSourceEcSlvQueryDto parm)
        {
            var response = _PpSourceEcSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询从源设变详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        [HttpGet("{SfId}")]
        [ActionPermissionFilter(Permission = "pp:sourceecslv:query")]
        public IActionResult GetPpSourceEcSlv(long SfId)
        {
            var response = _PpSourceEcSlvService.GetInfo(SfId);
            
            var info = response.Adapt<PpSourceEcSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加从源设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:sourceecslv:add")]
        [Log(Title = "从源设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpSourceEcSlv([FromBody] PpSourceEcSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpSourceEcSlvService.CheckInputUnique(parm.SfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增从源设变 '{parm.SfId}'失败(Add failed)，输入的从源设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpSourceEcSlv>().ToCreate(HttpContext);

            var response = _PpSourceEcSlvService.AddPpSourceEcSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新从源设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:sourceecslv:edit")]
        [Log(Title = "从源设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpSourceEcSlv([FromBody] PpSourceEcSlvDto parm)
        {
            var modal = parm.Adapt<PpSourceEcSlv>().ToUpdate(HttpContext);
            var response = _PpSourceEcSlvService.UpdatePpSourceEcSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除从源设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:sourceecslv:delete")]
        [Log(Title = "从源设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpSourceEcSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpSourceEcSlvService.Delete(idArr, "删除从源设变"));
        }

        /// <summary>
        /// 导出从源设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "从源设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:sourceecslv:export")]
        public IActionResult Export([FromQuery] PpSourceEcSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpSourceEcSlvService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "从源设变", "从源设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "从源设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:sourceecslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpSourceEcSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpSourceEcSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpSourceEcSlvService.ImportPpSourceEcSlv(list.Adapt<List<PpSourceEcSlv>>()));
        }

        /// <summary>
        /// 从源设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "从源设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpSourceEcSlvImportTpl>() { }, "PpSourceEcSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}