using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 修理日报slv
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:03:40
    /// </summary>
    [Verify]
    [Route("Logistics/PpRepairPcbaSlv")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpRepairPcbaSlvController : BaseController
    {
        /// <summary>
        /// 修理日报slv接口
        /// </summary>
        private readonly IPpRepairPcbaSlvService _PpRepairPcbaSlvService;

        public PpRepairPcbaSlvController(IPpRepairPcbaSlvService PpRepairPcbaSlvService)
        {
            _PpRepairPcbaSlvService = PpRepairPcbaSlvService;
        }

        /// <summary>
        /// 查询修理日报slv列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:list")]
        public IActionResult QueryPpRepairPcbaSlv([FromQuery] PpRepairPcbaSlvQueryDto parm)
        {
            var response = _PpRepairPcbaSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询修理日报slv详情
        /// </summary>
        /// <param name="PdrSfId"></param>
        /// <returns></returns>
        [HttpGet("{PdrSfId}")]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:query")]
        public IActionResult GetPpRepairPcbaSlv(long PdrSfId)
        {
            var response = _PpRepairPcbaSlvService.GetInfo(PdrSfId);
            
            var info = response.Adapt<PpRepairPcbaSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加修理日报slv
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:add")]
        [Log(Title = "修理日报slv", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpRepairPcbaSlv([FromBody] PpRepairPcbaSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpRepairPcbaSlvService.CheckInputUnique(parm.PdrSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增修理日报slv '{parm.PdrSfId}'失败(Add failed)，输入的修理日报slv已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpRepairPcbaSlv>().ToCreate(HttpContext);

            var response = _PpRepairPcbaSlvService.AddPpRepairPcbaSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新修理日报slv
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:edit")]
        [Log(Title = "修理日报slv", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpRepairPcbaSlv([FromBody] PpRepairPcbaSlvDto parm)
        {
            var modal = parm.Adapt<PpRepairPcbaSlv>().ToUpdate(HttpContext);
            var response = _PpRepairPcbaSlvService.UpdatePpRepairPcbaSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除修理日报slv
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:delete")]
        [Log(Title = "修理日报slv", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpRepairPcbaSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpRepairPcbaSlvService.Delete(idArr, "删除修理日报slv"));
        }

        /// <summary>
        /// 导出修理日报slv
        /// </summary>
        /// <returns></returns>
        [Log(Title = "修理日报slv", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:export")]
        public IActionResult Export([FromQuery] PpRepairPcbaSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpRepairPcbaSlvService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "修理日报slv", "修理日报slv");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "修理日报slv导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpRepairPcbaSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpRepairPcbaSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpRepairPcbaSlvService.ImportPpRepairPcbaSlv(list.Adapt<List<PpRepairPcbaSlv>>()));
        }

        /// <summary>
        /// 修理日报slv导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "修理日报slv模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpRepairPcbaSlvImportTpl>() { }, "PpRepairPcbaSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}