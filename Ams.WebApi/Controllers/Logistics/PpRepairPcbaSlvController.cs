using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 修理明细
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:47
    /// </summary>
    [Verify]
    [Route("Logistics/PpRepairPcbaSlv")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpRepairPcbaSlvController : BaseController
    {
        /// <summary>
        /// 修理明细接口
        /// </summary>
        private readonly IPpRepairPcbaSlvService _PpRepairPcbaSlvService;

        public PpRepairPcbaSlvController(IPpRepairPcbaSlvService PpRepairPcbaSlvService)
        {
            _PpRepairPcbaSlvService = PpRepairPcbaSlvService;
        }

        /// <summary>
        /// 查询修理明细列表
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
        /// 查询修理明细详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:query")]
        public IActionResult GetPpRepairPcbaSlv(long Id)
        {
            var response = _PpRepairPcbaSlvService.GetInfo(Id);
            
            var info = response.Adapt<PpRepairPcbaSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加修理明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:add")]
        [Log(Title = "修理明细", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpRepairPcbaSlv([FromBody] PpRepairPcbaSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpRepairPcbaSlvService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增修理明细 '{parm.Id}'失败(Add failed)，输入的修理明细已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpRepairPcbaSlv>().ToCreate(HttpContext);

            var response = _PpRepairPcbaSlvService.AddPpRepairPcbaSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新修理明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:edit")]
        [Log(Title = "修理明细", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpRepairPcbaSlv([FromBody] PpRepairPcbaSlvDto parm)
        {
            var modal = parm.Adapt<PpRepairPcbaSlv>().ToUpdate(HttpContext);
            var response = _PpRepairPcbaSlvService.UpdatePpRepairPcbaSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除修理明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:delete")]
        [Log(Title = "修理明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpRepairPcbaSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpRepairPcbaSlvService.Delete(idArr, "删除修理明细"));
        }

        /// <summary>
        /// 导出修理明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "修理明细导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
            var result = ExportExcelMini(list, "修理明细", "修理明细");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入修理明细
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "修理明细导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:repairpcbaslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpRepairPcbaSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpRepairPcbaSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpRepairPcbaSlvService.ImportPpRepairPcbaSlv(list.Adapt<List<PpRepairPcbaSlv>>()));
        }

        /// <summary>
        /// 修理明细
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "修理明细模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpRepairPcbaSlvImportTpl>() { }, "PpRepairPcbaSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}