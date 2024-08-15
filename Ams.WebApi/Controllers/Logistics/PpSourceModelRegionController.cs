using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 源机种仕向
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:18:52
    /// </summary>
    [Verify]
    [Route("Logistics/PpSourceModelRegion")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpSourceModelRegionController : BaseController
    {
        /// <summary>
        /// 源机种仕向接口
        /// </summary>
        private readonly IPpSourceModelRegionService _PpSourceModelRegionService;

        public PpSourceModelRegionController(IPpSourceModelRegionService PpSourceModelRegionService)
        {
            _PpSourceModelRegionService = PpSourceModelRegionService;
        }

        /// <summary>
        /// 查询源机种仕向列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:sourcemodelregion:list")]
        public IActionResult QueryPpSourceModelRegion([FromQuery] PpSourceModelRegionQueryDto parm)
        {
            var response = _PpSourceModelRegionService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询源机种仕向详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        [HttpGet("{SfId}")]
        [ActionPermissionFilter(Permission = "pp:sourcemodelregion:query")]
        public IActionResult GetPpSourceModelRegion(long SfId)
        {
            var response = _PpSourceModelRegionService.GetInfo(SfId);
            
            var info = response.Adapt<PpSourceModelRegionDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加源机种仕向
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:sourcemodelregion:add")]
        [Log(Title = "源机种仕向", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpSourceModelRegion([FromBody] PpSourceModelRegionDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpSourceModelRegionService.CheckInputUnique(parm.SfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增源机种仕向 '{parm.SfId}'失败(Add failed)，输入的源机种仕向已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpSourceModelRegion>().ToCreate(HttpContext);

            var response = _PpSourceModelRegionService.AddPpSourceModelRegion(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新源机种仕向
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:sourcemodelregion:edit")]
        [Log(Title = "源机种仕向", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpSourceModelRegion([FromBody] PpSourceModelRegionDto parm)
        {
            var modal = parm.Adapt<PpSourceModelRegion>().ToUpdate(HttpContext);
            var response = _PpSourceModelRegionService.UpdatePpSourceModelRegion(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除源机种仕向
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:sourcemodelregion:delete")]
        [Log(Title = "源机种仕向", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpSourceModelRegion([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpSourceModelRegionService.Delete(idArr, "删除源机种仕向"));
        }

        /// <summary>
        /// 导出源机种仕向
        /// </summary>
        /// <returns></returns>
        [Log(Title = "源机种仕向", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:sourcemodelregion:export")]
        public IActionResult Export([FromQuery] PpSourceModelRegionQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpSourceModelRegionService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "源机种仕向", "源机种仕向");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "源机种仕向导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:sourcemodelregion:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpSourceModelRegionDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpSourceModelRegionDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpSourceModelRegionService.ImportPpSourceModelRegion(list.Adapt<List<PpSourceModelRegion>>()));
        }

        /// <summary>
        /// 源机种仕向导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "源机种仕向模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpSourceModelRegionImportTpl>() { }, "PpSourceModelRegion_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}