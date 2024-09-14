using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 组立OPH
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:21:13
    /// </summary>
    [Verify]
    [Route("Logistics/PpOutputAssyMa")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOutputAssyMaController : BaseController
    {
        /// <summary>
        /// 组立OPH接口
        /// </summary>
        private readonly IPpOutputAssyMaService _PpOutputAssyMaService;

        public PpOutputAssyMaController(IPpOutputAssyMaService PpOutputAssyMaService)
        {
            _PpOutputAssyMaService = PpOutputAssyMaService;
        }

        /// <summary>
        /// 查询组立OPH列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputassyma:list")]
        public IActionResult QueryPpOutputAssyMa([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            var response = _PpOutputAssyMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询组立OPH详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:outputassyma:query")]
        public IActionResult GetPpOutputAssyMa(long Id)
        {
            var response = _PpOutputAssyMaService.GetInfo(Id);
            
            var info = response.Adapt<PpOutputAssyMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加组立OPH
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputassyma:add")]
        [Log(Title = "组立OPH", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpOutputAssyMa([FromBody] PpOutputAssyMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputAssyMaService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增组立OPH '{parm.Id}'失败(Add failed)，输入的组立OPH已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOutputAssyMa>().ToCreate(HttpContext);

            var response = _PpOutputAssyMaService.AddPpOutputAssyMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新组立OPH
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputassyma:edit")]
        [Log(Title = "组立OPH", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpOutputAssyMa([FromBody] PpOutputAssyMaDto parm)
        {
            var modal = parm.Adapt<PpOutputAssyMa>().ToUpdate(HttpContext);
            var response = _PpOutputAssyMaService.UpdatePpOutputAssyMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除组立OPH
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputassyma:delete")]
        [Log(Title = "组立OPH", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputAssyMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOutputAssyMaService.Delete(idArr, "删除组立OPH"));
        }

        /// <summary>
        /// 导出组立OPH
        /// </summary>
        /// <returns></returns>
        [Log(Title = "组立OPH导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputassyma:export")]
        public IActionResult Export([FromQuery] PpOutputAssyMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOutputAssyMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "组立OPH", "组立OPH");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入组立OPH
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "组立OPH导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputassyma:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpOutputAssyMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOutputAssyMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOutputAssyMaService.ImportPpOutputAssyMa(list.Adapt<List<PpOutputAssyMa>>()));
        }

        /// <summary>
        /// 组立OPH
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "组立OPH模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOutputAssyMaImportTpl>() { }, "PpOutputAssyMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}