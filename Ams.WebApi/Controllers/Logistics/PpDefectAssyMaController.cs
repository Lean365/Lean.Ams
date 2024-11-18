using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 不良
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:09
    /// </summary>
    [Verify]
    [Route("Logistics/PpDefectAssyMa")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpDefectAssyMaController : BaseController
    {
        /// <summary>
        /// 不良接口
        /// </summary>
        private readonly IPpDefectAssyMaService _PpDefectAssyMaService;

        public PpDefectAssyMaController(IPpDefectAssyMaService PpDefectAssyMaService)
        {
            _PpDefectAssyMaService = PpDefectAssyMaService;
        }

        /// <summary>
        /// 查询不良列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:defectassyma:list")]
        public IActionResult QueryPpDefectAssyMa([FromQuery] PpDefectAssyMaQueryDto parm)
        {
            var response = _PpDefectAssyMaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询不良详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:defectassyma:query")]
        public IActionResult GetPpDefectAssyMa(long Id)
        {
            var response = _PpDefectAssyMaService.GetInfo(Id);
            
            var info = response.Adapt<PpDefectAssyMaDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加不良
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:defectassyma:add")]
        [Log(Title = "不良", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpDefectAssyMa([FromBody] PpDefectAssyMaDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpDefectAssyMaService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增不良 '{parm.Id}'失败(Add failed)，输入的不良已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpDefectAssyMa>().ToCreate(HttpContext);

            var response = _PpDefectAssyMaService.AddPpDefectAssyMa(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新不良
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:defectassyma:edit")]
        [Log(Title = "不良", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpDefectAssyMa([FromBody] PpDefectAssyMaDto parm)
        {
            var modal = parm.Adapt<PpDefectAssyMa>().ToUpdate(HttpContext);
            var response = _PpDefectAssyMaService.UpdatePpDefectAssyMa(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除不良
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:defectassyma:delete")]
        [Log(Title = "不良", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpDefectAssyMa([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpDefectAssyMaService.Delete(idArr, "删除不良"));
        }

        /// <summary>
        /// 导出不良
        /// </summary>
        /// <returns></returns>
        [Log(Title = "不良导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:defectassyma:export")]
        public IActionResult Export([FromQuery] PpDefectAssyMaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpDefectAssyMaService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "不良", "不良");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入不良
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "不良导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:defectassyma:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpDefectAssyMaDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpDefectAssyMaDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpDefectAssyMaService.ImportPpDefectAssyMa(list.Adapt<List<PpDefectAssyMa>>()));
        }

        /// <summary>
        /// 不良
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "不良模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpDefectAssyMaImportTpl>() { }, "PpDefectAssyMa_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}