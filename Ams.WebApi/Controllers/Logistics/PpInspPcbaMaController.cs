using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 检查
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:26:18
    /// </summary>
    [Verify]
    [Route("Logistics/PpInspPcbaMa")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpInspPcbaMaController : BaseController
    {
        /// <summary>
        /// 检查接口
        /// </summary>
        private readonly IPpInspPcbaMaService _PpInspPcbaMaService;

        public PpInspPcbaMaController(IPpInspPcbaMaService PpInspPcbaMaService)
        {
            _PpInspPcbaMaService = PpInspPcbaMaService;
        }

        /// <summary>
        /// 查询检查列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:inscbama:list")]
        public IActionResult QueryPpInspPcbaMa([FromQuery] PpInspPcbaMaQueryDto parm)
        {
            var response = _PpInspPcbaMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询检查详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:inscbama:query")]
        public IActionResult GetPpInspPcbaMa(long Id)
        {
            var response = _PpInspPcbaMaService.GetInfo(Id);
            
            var info = response.Adapt<PpInspPcbaMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加检查
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:inscbama:add")]
        [Log(Title = "检查", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpInspPcbaMa([FromBody] PpInspPcbaMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpInspPcbaMaService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增检查 '{parm.Id}'失败(Add failed)，输入的检查已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpInspPcbaMa>().ToCreate(HttpContext);

            var response = _PpInspPcbaMaService.AddPpInspPcbaMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新检查
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:inscbama:edit")]
        [Log(Title = "检查", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpInspPcbaMa([FromBody] PpInspPcbaMaDto parm)
        {
            var modal = parm.Adapt<PpInspPcbaMa>().ToUpdate(HttpContext);
            var response = _PpInspPcbaMaService.UpdatePpInspPcbaMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除检查
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:inscbama:delete")]
        [Log(Title = "检查", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpInspPcbaMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpInspPcbaMaService.Delete(idArr, "删除检查"));
        }

        /// <summary>
        /// 导出检查
        /// </summary>
        /// <returns></returns>
        [Log(Title = "检查导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:inscbama:export")]
        public IActionResult Export([FromQuery] PpInspPcbaMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpInspPcbaMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "检查", "检查");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入检查
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "检查导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:inscbama:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpInspPcbaMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpInspPcbaMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpInspPcbaMaService.ImportPpInspPcbaMa(list.Adapt<List<PpInspPcbaMa>>()));
        }

        /// <summary>
        /// 检查
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "检查模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpInspPcbaMaImportTpl>() { }, "PpInspPcbaMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}