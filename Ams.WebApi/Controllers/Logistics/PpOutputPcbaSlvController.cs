using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// PCBA明细
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:35
    /// </summary>
    [Verify]
    [Route("Logistics/PpOutputPcbaSlv")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOutputPcbaSlvController : BaseController
    {
        /// <summary>
        /// PCBA明细接口
        /// </summary>
        private readonly IPpOutputPcbaSlvService _PpOutputPcbaSlvService;

        public PpOutputPcbaSlvController(IPpOutputPcbaSlvService PpOutputPcbaSlvService)
        {
            _PpOutputPcbaSlvService = PpOutputPcbaSlvService;
        }

        /// <summary>
        /// 查询PCBA明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslv:list")]
        public IActionResult QueryPpOutputPcbaSlv([FromQuery] PpOutputPcbaSlvQueryDto parm)
        {
            var response = _PpOutputPcbaSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询PCBA明细详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslv:query")]
        public IActionResult GetPpOutputPcbaSlv(long Id)
        {
            var response = _PpOutputPcbaSlvService.GetInfo(Id);
            
            var info = response.Adapt<PpOutputPcbaSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加PCBA明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslv:add")]
        [Log(Title = "PCBA明细", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpOutputPcbaSlv([FromBody] PpOutputPcbaSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputPcbaSlvService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增PCBA明细 '{parm.Id}'失败(Add failed)，输入的PCBA明细已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOutputPcbaSlv>().ToCreate(HttpContext);

            var response = _PpOutputPcbaSlvService.AddPpOutputPcbaSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新PCBA明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslv:edit")]
        [Log(Title = "PCBA明细", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpOutputPcbaSlv([FromBody] PpOutputPcbaSlvDto parm)
        {
            var modal = parm.Adapt<PpOutputPcbaSlv>().ToUpdate(HttpContext);
            var response = _PpOutputPcbaSlvService.UpdatePpOutputPcbaSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除PCBA明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslv:delete")]
        [Log(Title = "PCBA明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputPcbaSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOutputPcbaSlvService.Delete(idArr, "删除PCBA明细"));
        }

        /// <summary>
        /// 导出PCBA明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "PCBA明细导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslv:export")]
        public IActionResult Export([FromQuery] PpOutputPcbaSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOutputPcbaSlvService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "PCBA明细", "PCBA明细");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入PCBA明细
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "PCBA明细导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputpcbaslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpOutputPcbaSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOutputPcbaSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOutputPcbaSlvService.ImportPpOutputPcbaSlv(list.Adapt<List<PpOutputPcbaSlv>>()));
        }

        /// <summary>
        /// PCBA明细
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "PCBA明细模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOutputPcbaSlvImportTpl>() { }, "PpOutputPcbaSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}