using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 检查日报slv
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:22
    /// </summary>
    [Verify]
    [Route("Logistics/PpInspPcbaSlv")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpInspPcbaSlvController : BaseController
    {
        /// <summary>
        /// 检查日报slv接口
        /// </summary>
        private readonly IPpInspPcbaSlvService _PpInspPcbaSlvService;

        public PpInspPcbaSlvController(IPpInspPcbaSlvService PpInspPcbaSlvService)
        {
            _PpInspPcbaSlvService = PpInspPcbaSlvService;
        }

        /// <summary>
        /// 查询检查日报slv列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:inscbaslv:list")]
        public IActionResult QueryPpInspPcbaSlv([FromQuery] PpInspPcbaSlvQueryDto parm)
        {
            var response = _PpInspPcbaSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询检查日报slv详情
        /// </summary>
        /// <param name="PdiSfId"></param>
        /// <returns></returns>
        [HttpGet("{PdiSfId}")]
        [ActionPermissionFilter(Permission = "pp:inscbaslv:query")]
        public IActionResult GetPpInspPcbaSlv(long PdiSfId)
        {
            var response = _PpInspPcbaSlvService.GetInfo(PdiSfId);
            
            var info = response.Adapt<PpInspPcbaSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加检查日报slv
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:inscbaslv:add")]
        [Log(Title = "检查日报slv", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpInspPcbaSlv([FromBody] PpInspPcbaSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpInspPcbaSlvService.CheckInputUnique(parm.PdiSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增检查日报slv '{parm.PdiSfId}'失败(Add failed)，输入的检查日报slv已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpInspPcbaSlv>().ToCreate(HttpContext);

            var response = _PpInspPcbaSlvService.AddPpInspPcbaSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新检查日报slv
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:inscbaslv:edit")]
        [Log(Title = "检查日报slv", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpInspPcbaSlv([FromBody] PpInspPcbaSlvDto parm)
        {
            var modal = parm.Adapt<PpInspPcbaSlv>().ToUpdate(HttpContext);
            var response = _PpInspPcbaSlvService.UpdatePpInspPcbaSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除检查日报slv
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:inscbaslv:delete")]
        [Log(Title = "检查日报slv", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpInspPcbaSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpInspPcbaSlvService.Delete(idArr, "删除检查日报slv"));
        }

        /// <summary>
        /// 导出检查日报slv
        /// </summary>
        /// <returns></returns>
        [Log(Title = "检查日报slv", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:inscbaslv:export")]
        public IActionResult Export([FromQuery] PpInspPcbaSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpInspPcbaSlvService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "检查日报slv", "检查日报slv");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "检查日报slv导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:inscbaslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpInspPcbaSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpInspPcbaSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpInspPcbaSlvService.ImportPpInspPcbaSlv(list.Adapt<List<PpInspPcbaSlv>>()));
        }

        /// <summary>
        /// 检查日报slv导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "检查日报slv模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpInspPcbaSlvImportTpl>() { }, "PpInspPcbaSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}