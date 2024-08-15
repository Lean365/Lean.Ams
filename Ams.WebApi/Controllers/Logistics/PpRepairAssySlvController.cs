using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 组立不良slv
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 11:58:58
    /// </summary>
    [Verify]
    [Route("Logistics/PpRepairAssySlv")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpRepairAssySlvController : BaseController
    {
        /// <summary>
        /// 组立不良slv接口
        /// </summary>
        private readonly IPpRepairAssySlvService _PpRepairAssySlvService;

        public PpRepairAssySlvController(IPpRepairAssySlvService PpRepairAssySlvService)
        {
            _PpRepairAssySlvService = PpRepairAssySlvService;
        }

        /// <summary>
        /// 查询组立不良slv列表
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
        /// 查询组立不良slv详情
        /// </summary>
        /// <param name="PpdSfId"></param>
        /// <returns></returns>
        [HttpGet("{PpdSfId}")]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:query")]
        public IActionResult GetPpRepairAssySlv(long PpdSfId)
        {
            var response = _PpRepairAssySlvService.GetInfo(PpdSfId);
            
            var info = response.Adapt<PpRepairAssySlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加组立不良slv
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:add")]
        [Log(Title = "组立不良slv", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpRepairAssySlv([FromBody] PpRepairAssySlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpRepairAssySlvService.CheckInputUnique(parm.PpdSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增组立不良slv '{parm.PpdSfId}'失败(Add failed)，输入的组立不良slv已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpRepairAssySlv>().ToCreate(HttpContext);

            var response = _PpRepairAssySlvService.AddPpRepairAssySlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新组立不良slv
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:edit")]
        [Log(Title = "组立不良slv", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpRepairAssySlv([FromBody] PpRepairAssySlvDto parm)
        {
            var modal = parm.Adapt<PpRepairAssySlv>().ToUpdate(HttpContext);
            var response = _PpRepairAssySlvService.UpdatePpRepairAssySlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除组立不良slv
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:delete")]
        [Log(Title = "组立不良slv", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpRepairAssySlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpRepairAssySlvService.Delete(idArr, "删除组立不良slv"));
        }

        /// <summary>
        /// 导出组立不良slv
        /// </summary>
        /// <returns></returns>
        [Log(Title = "组立不良slv", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
            var result = ExportExcelMini(list, "组立不良slv", "组立不良slv");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "组立不良slv导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:repairassyslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpRepairAssySlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpRepairAssySlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpRepairAssySlvService.ImportPpRepairAssySlv(list.Adapt<List<PpRepairAssySlv>>()));
        }

        /// <summary>
        /// 组立不良slv导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "组立不良slv模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpRepairAssySlvImportTpl>() { }, "PpRepairAssySlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}