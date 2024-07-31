using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 制一OPH从表
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:07:23
    /// </summary>
    [Verify]
    [Route("Logistics/PpOutputAssySlave")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOutputAssySlaveController : BaseController
    {
        /// <summary>
        /// 制一OPH从表接口
        /// </summary>
        private readonly IPpOutputAssySlaveService _PpOutputAssySlaveService;

        public PpOutputAssySlaveController(IPpOutputAssySlaveService PpOutputAssySlaveService)
        {
            _PpOutputAssySlaveService = PpOutputAssySlaveService;
        }

        /// <summary>
        /// 查询制一OPH从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputassyslave:list")]
        public IActionResult QueryPpOutputAssySlave([FromQuery] PpOutputAssySlaveQueryDto parm)
        {
            var response = _PpOutputAssySlaveService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询制一OPH从表详情
        /// </summary>
        /// <param name="PosSfId"></param>
        /// <returns></returns>
        [HttpGet("{PosSfId}")]
        [ActionPermissionFilter(Permission = "pp:outputassyslave:query")]
        public IActionResult GetPpOutputAssySlave(long PosSfId)
        {
            var response = _PpOutputAssySlaveService.GetInfo(PosSfId);
            
            var info = response.Adapt<PpOutputAssySlaveDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加制一OPH从表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputassyslave:add")]
        [Log(Title = "制一OPH从表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOutputAssySlave([FromBody] PpOutputAssySlaveDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputAssySlaveService.CheckInputUnique(parm.PosSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增制一OPH从表 '{parm.PosSfId}'失败(Add failed)，输入的制一OPH从表已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOutputAssySlave>().ToCreate(HttpContext);

            var response = _PpOutputAssySlaveService.AddPpOutputAssySlave(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新制一OPH从表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputassyslave:edit")]
        [Log(Title = "制一OPH从表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOutputAssySlave([FromBody] PpOutputAssySlaveDto parm)
        {
            var modal = parm.Adapt<PpOutputAssySlave>().ToUpdate(HttpContext);
            var response = _PpOutputAssySlaveService.UpdatePpOutputAssySlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除制一OPH从表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputassyslave:delete")]
        [Log(Title = "制一OPH从表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputAssySlave([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOutputAssySlaveService.Delete(idArr, "删除制一OPH从表"));
        }

        /// <summary>
        /// 导出制一OPH从表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "制一OPH从表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputassyslave:export")]
        public IActionResult Export([FromQuery] PpOutputAssySlaveQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOutputAssySlaveService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "制一OPH从表", "制一OPH从表");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "制一OPH从表导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputassyslave:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpOutputAssySlaveDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOutputAssySlaveDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOutputAssySlaveService.ImportPpOutputAssySlave(list.Adapt<List<PpOutputAssySlave>>()));
        }

        /// <summary>
        /// 制一OPH从表导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "制一OPH从表模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOutputAssySlaveImportTpl>() { }, "PpOutputAssySlave_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}