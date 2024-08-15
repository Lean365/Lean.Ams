using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 品管
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:42:29
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlaveFqc")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlaveFqcController : BaseController
    {
        /// <summary>
        /// 品管接口
        /// </summary>
        private readonly IPpEcSlaveFqcService _PpEcSlaveFqcService;

        public PpEcSlaveFqcController(IPpEcSlaveFqcService PpEcSlaveFqcService)
        {
            _PpEcSlaveFqcService = PpEcSlaveFqcService;
        }

        /// <summary>
        /// 查询品管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslavefqc:list")]
        public IActionResult QueryPpEcSlaveFqc([FromQuery] PpEcSlaveFqcQueryDto parm)
        {
            var response = _PpEcSlaveFqcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询品管详情
        /// </summary>
        /// <param name="FqcSfId"></param>
        /// <returns></returns>
        [HttpGet("{FqcSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslavefqc:query")]
        public IActionResult GetPpEcSlaveFqc(long FqcSfId)
        {
            var response = _PpEcSlaveFqcService.GetInfo(FqcSfId);
            
            var info = response.Adapt<PpEcSlaveFqcDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加品管
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslavefqc:add")]
        [Log(Title = "品管", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlaveFqc([FromBody] PpEcSlaveFqcDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlaveFqcService.CheckInputUnique(parm.FqcSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增品管 '{parm.FqcSfId}'失败(Add failed)，输入的品管已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlaveFqc>().ToCreate(HttpContext);

            var response = _PpEcSlaveFqcService.AddPpEcSlaveFqc(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新品管
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslavefqc:edit")]
        [Log(Title = "品管", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlaveFqc([FromBody] PpEcSlaveFqcDto parm)
        {
            var modal = parm.Adapt<PpEcSlaveFqc>().ToUpdate(HttpContext);
            var response = _PpEcSlaveFqcService.UpdatePpEcSlaveFqc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除品管
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslavefqc:delete")]
        [Log(Title = "品管", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlaveFqc([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlaveFqcService.Delete(idArr, "删除品管"));
        }

        /// <summary>
        /// 导出品管
        /// </summary>
        /// <returns></returns>
        [Log(Title = "品管", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslavefqc:export")]
        public IActionResult Export([FromQuery] PpEcSlaveFqcQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlaveFqcService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "品管", "品管");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "品管导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslavefqc:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlaveFqcDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlaveFqcDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlaveFqcService.ImportPpEcSlaveFqc(list.Adapt<List<PpEcSlaveFqc>>()));
        }

        /// <summary>
        /// 品管导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "品管模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlaveFqcImportTpl>() { }, "PpEcSlaveFqc_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}