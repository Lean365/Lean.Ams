using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 修理日报ma
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:04:48
    /// </summary>
    [Verify]
    [Route("Logistics/PpRepairPcbaMa")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpRepairPcbaMaController : BaseController
    {
        /// <summary>
        /// 修理日报ma接口
        /// </summary>
        private readonly IPpRepairPcbaMaService _PpRepairPcbaMaService;

        public PpRepairPcbaMaController(IPpRepairPcbaMaService PpRepairPcbaMaService)
        {
            _PpRepairPcbaMaService = PpRepairPcbaMaService;
        }

        /// <summary>
        /// 查询修理日报ma列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:repairpcbama:list")]
        public IActionResult QueryPpRepairPcbaMa([FromQuery] PpRepairPcbaMaQueryDto parm)
        {
            var response = _PpRepairPcbaMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询修理日报ma详情
        /// </summary>
        /// <param name="PdrSfId"></param>
        /// <returns></returns>
        [HttpGet("{PdrSfId}")]
        [ActionPermissionFilter(Permission = "pp:repairpcbama:query")]
        public IActionResult GetPpRepairPcbaMa(long PdrSfId)
        {
            var response = _PpRepairPcbaMaService.GetInfo(PdrSfId);
            
            var info = response.Adapt<PpRepairPcbaMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加修理日报ma
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:repairpcbama:add")]
        [Log(Title = "修理日报ma", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpRepairPcbaMa([FromBody] PpRepairPcbaMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpRepairPcbaMaService.CheckInputUnique(parm.PdrSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增修理日报ma '{parm.PdrSfId}'失败(Add failed)，输入的修理日报ma已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpRepairPcbaMa>().ToCreate(HttpContext);

            var response = _PpRepairPcbaMaService.AddPpRepairPcbaMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新修理日报ma
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:repairpcbama:edit")]
        [Log(Title = "修理日报ma", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpRepairPcbaMa([FromBody] PpRepairPcbaMaDto parm)
        {
            var modal = parm.Adapt<PpRepairPcbaMa>().ToUpdate(HttpContext);
            var response = _PpRepairPcbaMaService.UpdatePpRepairPcbaMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除修理日报ma
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:repairpcbama:delete")]
        [Log(Title = "修理日报ma", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpRepairPcbaMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpRepairPcbaMaService.Delete(idArr, "删除修理日报ma"));
        }

        /// <summary>
        /// 导出修理日报ma
        /// </summary>
        /// <returns></returns>
        [Log(Title = "修理日报ma", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:repairpcbama:export")]
        public IActionResult Export([FromQuery] PpRepairPcbaMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpRepairPcbaMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "修理日报ma", "修理日报ma");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "修理日报ma导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:repairpcbama:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpRepairPcbaMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpRepairPcbaMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpRepairPcbaMaService.ImportPpRepairPcbaMa(list.Adapt<List<PpRepairPcbaMa>>()));
        }

        /// <summary>
        /// 修理日报ma导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "修理日报ma模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpRepairPcbaMaImportTpl>() { }, "PpRepairPcbaMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}