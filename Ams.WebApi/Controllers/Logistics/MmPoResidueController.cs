using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// PO残清单
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:59:13
    /// </summary>
    [Verify]
    [Route("Logistics/MmPoResidue")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MmPoResidueController : BaseController
    {
        /// <summary>
        /// PO残清单接口
        /// </summary>
        private readonly IMmPoResidueService _MmPoResidueService;

        public MmPoResidueController(IMmPoResidueService MmPoResidueService)
        {
            _MmPoResidueService = MmPoResidueService;
        }

        /// <summary>
        /// 查询PO残清单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:poresidue:list")]
        public IActionResult QueryMmPoResidue([FromQuery] MmPoResidueQueryDto parm)
        {
            var response = _MmPoResidueService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询PO残清单详情
        /// </summary>
        /// <param name="PrSfId"></param>
        /// <returns></returns>
        [HttpGet("{PrSfId}")]
        [ActionPermissionFilter(Permission = "mm:poresidue:query")]
        public IActionResult GetMmPoResidue(long PrSfId)
        {
            var response = _MmPoResidueService.GetInfo(PrSfId);
            
            var info = response.Adapt<MmPoResidueDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加PO残清单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:poresidue:add")]
        [Log(Title = "PO残清单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmPoResidue([FromBody] MmPoResidueDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmPoResidueService.CheckInputUnique(parm.PrSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增PO残清单 '{parm.PrSfId}'失败(Add failed)，输入的PO残清单已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<MmPoResidue>().ToCreate(HttpContext);

            var response = _MmPoResidueService.AddMmPoResidue(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新PO残清单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:poresidue:edit")]
        [Log(Title = "PO残清单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmPoResidue([FromBody] MmPoResidueDto parm)
        {
            var modal = parm.Adapt<MmPoResidue>().ToUpdate(HttpContext);
            var response = _MmPoResidueService.UpdateMmPoResidue(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除PO残清单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:poresidue:delete")]
        [Log(Title = "PO残清单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmPoResidue([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MmPoResidueService.Delete(idArr, "删除PO残清单"));
        }

        /// <summary>
        /// 导出PO残清单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "PO残清单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:poresidue:export")]
        public IActionResult Export([FromQuery] MmPoResidueQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MmPoResidueService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "PO残清单", "PO残清单");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "PO残清单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:poresidue:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MmPoResidueDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmPoResidueDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmPoResidueService.ImportMmPoResidue(list.Adapt<List<MmPoResidue>>()));
        }

        /// <summary>
        /// PO残清单导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "PO残清单模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmPoResidueImportTpl>() { }, "MmPoResidue_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}