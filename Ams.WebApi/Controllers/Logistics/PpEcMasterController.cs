using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/14 8:48:00
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcMaster")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcMasterController : BaseController
    {
        /// <summary>
        /// 设变接口
        /// </summary>
        private readonly IPpEcMasterService _PpEcMasterService;

        public PpEcMasterController(IPpEcMasterService PpEcMasterService)
        {
            _PpEcMasterService = PpEcMasterService;
        }

        /// <summary>
        /// 查询设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:list")]
        public IActionResult QueryPpEcMaster([FromQuery] PpEcMasterQueryDto parm)
        {
            var response = _PpEcMasterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询设变详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:query")]
        public IActionResult GetPpEcMaster(long Id)
        {
            var response = _PpEcMasterService.GetInfo(Id);
            
            var info = response.Adapt<PpEcMasterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmaster:add")]
        [Log(Title = "设变", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpEcMaster([FromBody] PpEcMasterDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增设变 '{parm.Id}'失败(Add failed)，输入的设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcMaster>().ToCreate(HttpContext);

            var response = _PpEcMasterService.AddPpEcMaster(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmaster:edit")]
        [Log(Title = "设变", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpEcMaster([FromBody] PpEcMasterDto parm)
        {
            var modal = parm.Adapt<PpEcMaster>().ToUpdate(HttpContext);
            var response = _PpEcMasterService.UpdatePpEcMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:delete")]
        [Log(Title = "设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMaster([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcMasterService.Delete(idArr, "删除设变"));
        }

        /// <summary>
        /// 导出设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "设变导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:export")]
        public IActionResult Export([FromQuery] PpEcMasterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcMasterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "设变", "设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入设变
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecmaster:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpEcMasterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcMasterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcMasterService.ImportPpEcMaster(list.Adapt<List<PpEcMaster>>()));
        }

        /// <summary>
        /// 设变
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcMasterImportTpl>() { }, "PpEcMaster_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}