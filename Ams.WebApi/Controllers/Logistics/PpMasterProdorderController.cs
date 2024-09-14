using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 生产工单
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:05:47
    /// </summary>
    [Verify]
    [Route("Logistics/PpMasterProdorder")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpMasterProdorderController : BaseController
    {
        /// <summary>
        /// 生产工单接口
        /// </summary>
        private readonly IPpMasterProdorderService _PpMasterProdorderService;

        public PpMasterProdorderController(IPpMasterProdorderService PpMasterProdorderService)
        {
            _PpMasterProdorderService = PpMasterProdorderService;
        }

        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:masterprodorder:list")]
        public IActionResult QueryPpMasterProdorder([FromQuery] PpMasterProdorderQueryDto parm)
        {
            var response = _PpMasterProdorderService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询生产工单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:masterprodorder:query")]
        public IActionResult GetPpMasterProdorder(long Id)
        {
            var response = _PpMasterProdorderService.GetInfo(Id);
            
            var info = response.Adapt<PpMasterProdorderDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:masterprodorder:add")]
        [Log(Title = "生产工单", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpMasterProdorder([FromBody] PpMasterProdorderDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpMasterProdorderService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增生产工单 '{parm.Id}'失败(Add failed)，输入的生产工单已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpMasterProdorder>().ToCreate(HttpContext);

            var response = _PpMasterProdorderService.AddPpMasterProdorder(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:masterprodorder:edit")]
        [Log(Title = "生产工单", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpMasterProdorder([FromBody] PpMasterProdorderDto parm)
        {
            var modal = parm.Adapt<PpMasterProdorder>().ToUpdate(HttpContext);
            var response = _PpMasterProdorderService.UpdatePpMasterProdorder(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产工单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:masterprodorder:delete")]
        [Log(Title = "生产工单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpMasterProdorder([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpMasterProdorderService.Delete(idArr, "删除生产工单"));
        }

        /// <summary>
        /// 导出生产工单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产工单导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:masterprodorder:export")]
        public IActionResult Export([FromQuery] PpMasterProdorderQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpMasterProdorderService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生产工单", "生产工单");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入生产工单
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "生产工单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:masterprodorder:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpMasterProdorderDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpMasterProdorderDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpMasterProdorderService.ImportPpMasterProdorder(list.Adapt<List<PpMasterProdorder>>()));
        }

        /// <summary>
        /// 生产工单
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "生产工单模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpMasterProdorderImportTpl>() { }, "PpMasterProdorder_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}