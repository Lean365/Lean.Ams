using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 工厂物料
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:45:06
    /// </summary>
    [Verify]
    [Route("Logistics/MmMarc")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MmMarcController : BaseController
    {
        /// <summary>
        /// 工厂物料接口
        /// </summary>
        private readonly IMmMarcService _MmMarcService;

        public MmMarcController(IMmMarcService MmMarcService)
        {
            _MmMarcService = MmMarcService;
        }

        /// <summary>
        /// 查询工厂物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:marc:list")]
        public IActionResult QueryMmMarc([FromQuery] MmMarcQueryDto parm)
        {
            var response = _MmMarcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询工厂物料详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        [HttpGet("{SfId}")]
        [ActionPermissionFilter(Permission = "mm:marc:query")]
        public IActionResult GetMmMarc(long SfId)
        {
            var response = _MmMarcService.GetInfo(SfId);
            
            var info = response.Adapt<MmMarcDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加工厂物料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:marc:add")]
        [Log(Title = "工厂物料", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmMarc([FromBody] MmMarcDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmMarcService.CheckInputUnique(parm.SfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增工厂物料 '{parm.SfId}'失败(Add failed)，输入的工厂物料已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<MmMarc>().ToCreate(HttpContext);

            var response = _MmMarcService.AddMmMarc(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新工厂物料
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:marc:edit")]
        [Log(Title = "工厂物料", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmMarc([FromBody] MmMarcDto parm)
        {
            var modal = parm.Adapt<MmMarc>().ToUpdate(HttpContext);
            var response = _MmMarcService.UpdateMmMarc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工厂物料
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:marc:delete")]
        [Log(Title = "工厂物料", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMarc([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MmMarcService.Delete(idArr, "删除工厂物料"));
        }

        /// <summary>
        /// 导出工厂物料
        /// </summary>
        /// <returns></returns>
        [Log(Title = "工厂物料", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:marc:export")]
        public IActionResult Export([FromQuery] MmMarcQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MmMarcService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "工厂物料", "工厂物料");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "工厂物料导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:marc:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MmMarcDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmMarcDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmMarcService.ImportMmMarc(list.Adapt<List<MmMarc>>()));
        }

        /// <summary>
        /// 工厂物料导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "工厂物料模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmMarcImportTpl>() { }, "MmMarc_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}