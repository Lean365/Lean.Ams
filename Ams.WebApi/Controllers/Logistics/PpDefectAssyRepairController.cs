using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 制一不良
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 14:30:29
    /// </summary>
    [Verify]
    [Route("Logistics/PpDefectAssyRepair")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpDefectAssyRepairController : BaseController
    {
        /// <summary>
        /// 制一不良接口
        /// </summary>
        private readonly IPpDefectAssyRepairService _PpDefectAssyRepairService;

        public PpDefectAssyRepairController(IPpDefectAssyRepairService PpDefectAssyRepairService)
        {
            _PpDefectAssyRepairService = PpDefectAssyRepairService;
        }

        /// <summary>
        /// 查询制一不良列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:defectassyrepair:list")]
        public IActionResult QueryPpDefectAssyRepair([FromQuery] PpDefectAssyRepairQueryDto parm)
        {
            var response = _PpDefectAssyRepairService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询制一不良详情
        /// </summary>
        /// <param name="PpdSfid"></param>
        /// <returns></returns>
        [HttpGet("{PpdSfid}")]
        [ActionPermissionFilter(Permission = "pp:defectassyrepair:query")]
        public IActionResult GetPpDefectAssyRepair(long PpdSfid)
        {
            var response = _PpDefectAssyRepairService.GetInfo(PpdSfid);
            
            var info = response.Adapt<PpDefectAssyRepairDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加制一不良
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:defectassyrepair:add")]
        [Log(Title = "制一不良", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpDefectAssyRepair([FromBody] PpDefectAssyRepairDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpDefectAssyRepairService.CheckInputUnique(parm.PpdSfid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增制一不良 '{parm.PpdSfid}'失败(Add failed)，输入的制一不良已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpDefectAssyRepair>().ToCreate(HttpContext);

            var response = _PpDefectAssyRepairService.AddPpDefectAssyRepair(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新制一不良
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:defectassyrepair:edit")]
        [Log(Title = "制一不良", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpDefectAssyRepair([FromBody] PpDefectAssyRepairDto parm)
        {
            var modal = parm.Adapt<PpDefectAssyRepair>().ToUpdate(HttpContext);
            var response = _PpDefectAssyRepairService.UpdatePpDefectAssyRepair(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除制一不良
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:defectassyrepair:delete")]
        [Log(Title = "制一不良", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpDefectAssyRepair([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpDefectAssyRepairService.Delete(idArr, "删除制一不良"));
        }

        /// <summary>
        /// 导出制一不良
        /// </summary>
        /// <returns></returns>
        [Log(Title = "制一不良", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:defectassyrepair:export")]
        public IActionResult Export([FromQuery] PpDefectAssyRepairQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpDefectAssyRepairService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "制一不良", "制一不良");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "制一不良导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:defectassyrepair:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpDefectAssyRepairDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpDefectAssyRepairDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpDefectAssyRepairService.ImportPpDefectAssyRepair(list.Adapt<List<PpDefectAssyRepair>>()));
        }

        /// <summary>
        /// 制一不良导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "制一不良模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpDefectAssyRepairDto>() { }, "PpDefectAssyRepair");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}