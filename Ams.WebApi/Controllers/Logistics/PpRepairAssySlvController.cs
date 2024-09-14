using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 不良明细
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:50
    /// </summary>
    [Verify]
    [Route("Logistics/PpRepairAssySlv")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpRepairAssySlvController : BaseController
    {
        /// <summary>
        /// 不良明细接口
        /// </summary>
        private readonly IPpRepairAssySlvService _PpRepairAssySlvService;

        public PpRepairAssySlvController(IPpRepairAssySlvService PpRepairAssySlvService)
        {
            _PpRepairAssySlvService = PpRepairAssySlvService;
        }

        /// <summary>
        /// 查询不良明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:list")]
        public IActionResult QueryPpRepairAssySlv([FromQuery] PpRepairAssySlvQueryDto parm)
        {
            var response = _PpRepairAssySlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询不良明细详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:query")]
        public IActionResult GetPpRepairAssySlv(long Id)
        {
            var response = _PpRepairAssySlvService.GetInfo(Id);
            
            var info = response.Adapt<PpRepairAssySlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加不良明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:add")]
        [Log(Title = "不良明细", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpRepairAssySlv([FromBody] PpRepairAssySlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpRepairAssySlvService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增不良明细 '{parm.Id}'失败(Add failed)，输入的不良明细已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpRepairAssySlv>().ToCreate(HttpContext);

            var response = _PpRepairAssySlvService.AddPpRepairAssySlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新不良明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:edit")]
        [Log(Title = "不良明细", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpRepairAssySlv([FromBody] PpRepairAssySlvDto parm)
        {
            var modal = parm.Adapt<PpRepairAssySlv>().ToUpdate(HttpContext);
            var response = _PpRepairAssySlvService.UpdatePpRepairAssySlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除不良明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:delete")]
        [Log(Title = "不良明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpRepairAssySlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpRepairAssySlvService.Delete(idArr, "删除不良明细"));
        }

        /// <summary>
        /// 导出不良明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "不良明细导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:export")]
        public IActionResult Export([FromQuery] PpRepairAssySlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpRepairAssySlvService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "不良明细", "不良明细");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入不良明细
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "不良明细导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpRepairAssySlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpRepairAssySlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpRepairAssySlvService.ImportPpRepairAssySlv(list.Adapt<List<PpRepairAssySlv>>()));
        }

        /// <summary>
        /// 不良明细
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "不良明细模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpRepairAssySlvImportTpl>() { }, "PpRepairAssySlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}