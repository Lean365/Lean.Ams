using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 组立不良ma
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:00:50
    /// </summary>
    [Verify]
    [Route("Logistics/PpRepairAssyMa")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpRepairAssyMaController : BaseController
    {
        /// <summary>
        /// 组立不良ma接口
        /// </summary>
        private readonly IPpRepairAssyMaService _PpRepairAssyMaService;

        public PpRepairAssyMaController(IPpRepairAssyMaService PpRepairAssyMaService)
        {
            _PpRepairAssyMaService = PpRepairAssyMaService;
        }

        /// <summary>
        /// 查询组立不良ma列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:repairassyma:list")]
        public IActionResult QueryPpRepairAssyMa([FromQuery] PpRepairAssyMaQueryDto parm)
        {
            var response = _PpRepairAssyMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询组立不良ma详情
        /// </summary>
        /// <param name="PpdSfId"></param>
        /// <returns></returns>
        [HttpGet("{PpdSfId}")]
        [ActionPermissionFilter(Permission = "pp:repairassyma:query")]
        public IActionResult GetPpRepairAssyMa(long PpdSfId)
        {
            var response = _PpRepairAssyMaService.GetInfo(PpdSfId);
            
            var info = response.Adapt<PpRepairAssyMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加组立不良ma
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:repairassyma:add")]
        [Log(Title = "组立不良ma", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpRepairAssyMa([FromBody] PpRepairAssyMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpRepairAssyMaService.CheckInputUnique(parm.PpdSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增组立不良ma '{parm.PpdSfId}'失败(Add failed)，输入的组立不良ma已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpRepairAssyMa>().ToCreate(HttpContext);

            var response = _PpRepairAssyMaService.AddPpRepairAssyMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新组立不良ma
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:repairassyma:edit")]
        [Log(Title = "组立不良ma", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpRepairAssyMa([FromBody] PpRepairAssyMaDto parm)
        {
            var modal = parm.Adapt<PpRepairAssyMa>().ToUpdate(HttpContext);
            var response = _PpRepairAssyMaService.UpdatePpRepairAssyMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除组立不良ma
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:repairassyma:delete")]
        [Log(Title = "组立不良ma", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpRepairAssyMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpRepairAssyMaService.Delete(idArr, "删除组立不良ma"));
        }

        /// <summary>
        /// 导出组立不良ma
        /// </summary>
        /// <returns></returns>
        [Log(Title = "组立不良ma", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:repairassyma:export")]
        public IActionResult Export([FromQuery] PpRepairAssyMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpRepairAssyMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "组立不良ma", "组立不良ma");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "组立不良ma导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:repairassyma:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpRepairAssyMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpRepairAssyMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpRepairAssyMaService.ImportPpRepairAssyMa(list.Adapt<List<PpRepairAssyMa>>()));
        }

        /// <summary>
        /// 组立不良ma导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "组立不良ma模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpRepairAssyMaImportTpl>() { }, "PpRepairAssyMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}