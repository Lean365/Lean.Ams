using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// Pcba设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:40:40
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlavePcba")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlavePcbaController : BaseController
    {
        /// <summary>
        /// Pcba设变接口
        /// </summary>
        private readonly IPpEcSlavePcbaService _PpEcSlavePcbaService;

        public PpEcSlavePcbaController(IPpEcSlavePcbaService PpEcSlavePcbaService)
        {
            _PpEcSlavePcbaService = PpEcSlavePcbaService;
        }

        /// <summary>
        /// 查询Pcba设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslavepcba:list")]
        public IActionResult QueryPpEcSlavePcba([FromQuery] PpEcSlavePcbaQueryDto parm)
        {
            var response = _PpEcSlavePcbaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询Pcba设变详情
        /// </summary>
        /// <param name="PcbaSfId"></param>
        /// <returns></returns>
        [HttpGet("{PcbaSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslavepcba:query")]
        public IActionResult GetPpEcSlavePcba(long PcbaSfId)
        {
            var response = _PpEcSlavePcbaService.GetInfo(PcbaSfId);
            
            var info = response.Adapt<PpEcSlavePcbaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加Pcba设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslavepcba:add")]
        [Log(Title = "Pcba设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlavePcba([FromBody] PpEcSlavePcbaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlavePcbaService.CheckInputUnique(parm.PcbaSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增Pcba设变 '{parm.PcbaSfId}'失败(Add failed)，输入的Pcba设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlavePcba>().ToCreate(HttpContext);

            var response = _PpEcSlavePcbaService.AddPpEcSlavePcba(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新Pcba设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslavepcba:edit")]
        [Log(Title = "Pcba设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlavePcba([FromBody] PpEcSlavePcbaDto parm)
        {
            var modal = parm.Adapt<PpEcSlavePcba>().ToUpdate(HttpContext);
            var response = _PpEcSlavePcbaService.UpdatePpEcSlavePcba(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除Pcba设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslavepcba:delete")]
        [Log(Title = "Pcba设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlavePcba([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlavePcbaService.Delete(idArr, "删除Pcba设变"));
        }

        /// <summary>
        /// 导出Pcba设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "Pcba设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslavepcba:export")]
        public IActionResult Export([FromQuery] PpEcSlavePcbaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlavePcbaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "Pcba设变", "Pcba设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "Pcba设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslavepcba:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlavePcbaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlavePcbaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlavePcbaService.ImportPpEcSlavePcba(list.Adapt<List<PpEcSlavePcba>>()));
        }

        /// <summary>
        /// Pcba设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "Pcba设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlavePcbaImportTpl>() { }, "PpEcSlavePcba_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}