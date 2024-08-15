using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 物料信息
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 14:13:37
    /// </summary>
    [Verify]
    [Route("Logistics/MmMarb")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MmMarbController : BaseController
    {
        /// <summary>
        /// 物料信息接口
        /// </summary>
        private readonly IMmMarbService _MmMarbService;

        public MmMarbController(IMmMarbService MmMarbService)
        {
            _MmMarbService = MmMarbService;
        }

        /// <summary>
        /// 查询物料信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:marb:list")]
        public IActionResult QueryMmMarb([FromQuery] MmMarbQueryDto parm)
        {
            var response = _MmMarbService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询物料信息详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        [HttpGet("{SfId}")]
        [ActionPermissionFilter(Permission = "mm:marb:query")]
        public IActionResult GetMmMarb(long SfId)
        {
            var response = _MmMarbService.GetInfo(SfId);
            
            var info = response.Adapt<MmMarbDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加物料信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:marb:add")]
        [Log(Title = "物料信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmMarb([FromBody] MmMarbDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmMarbService.CheckInputUnique(parm.SfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增物料信息 '{parm.SfId}'失败(Add failed)，输入的物料信息已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<MmMarb>().ToCreate(HttpContext);

            var response = _MmMarbService.AddMmMarb(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新物料信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:marb:edit")]
        [Log(Title = "物料信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmMarb([FromBody] MmMarbDto parm)
        {
            var modal = parm.Adapt<MmMarb>().ToUpdate(HttpContext);
            var response = _MmMarbService.UpdateMmMarb(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除物料信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:marb:delete")]
        [Log(Title = "物料信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMarb([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MmMarbService.Delete(idArr, "删除物料信息"));
        }

        /// <summary>
        /// 导出物料信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "物料信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:marb:export")]
        public IActionResult Export([FromQuery] MmMarbQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MmMarbService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "物料信息", "物料信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "物料信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:marb:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MmMarbDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmMarbDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmMarbService.ImportMmMarb(list.Adapt<List<MmMarb>>()));
        }

        /// <summary>
        /// 物料信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "物料信息模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmMarbImportTpl>() { }, "MmMarb_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}