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
    /// @Date: 2024/11/12 17:18:57
    /// </summary>
    [Verify]
    [Route("Logistics/PpDefectAssySlv")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpDefectAssySlvController : BaseController
    {
        /// <summary>
        /// 不良明细接口
        /// </summary>
        private readonly IPpDefectAssySlvService _PpDefectAssySlvService;

        public PpDefectAssySlvController(IPpDefectAssySlvService PpDefectAssySlvService)
        {
            _PpDefectAssySlvService = PpDefectAssySlvService;
        }

        /// <summary>
        /// 查询不良明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:defectassyslv:list")]
        public IActionResult QueryPpDefectAssySlv([FromQuery] PpDefectAssySlvQueryDto parm)
        {
            var response = _PpDefectAssySlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询不良明细详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:defectassyslv:query")]
        public IActionResult GetPpDefectAssySlv(long Id)
        {
            var response = _PpDefectAssySlvService.GetInfo(Id);
            
            var info = response.Adapt<PpDefectAssySlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加不良明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:defectassyslv:add")]
        [Log(Title = "不良明细", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpDefectAssySlv([FromBody] PpDefectAssySlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpDefectAssySlvService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增不良明细 '{parm.Id}'失败(Add failed)，输入的不良明细已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpDefectAssySlv>().ToCreate(HttpContext);

            var response = _PpDefectAssySlvService.AddPpDefectAssySlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新不良明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:defectassyslv:edit")]
        [Log(Title = "不良明细", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpDefectAssySlv([FromBody] PpDefectAssySlvDto parm)
        {
            var modal = parm.Adapt<PpDefectAssySlv>().ToUpdate(HttpContext);
            var response = _PpDefectAssySlvService.UpdatePpDefectAssySlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除不良明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:defectassyslv:delete")]
        [Log(Title = "不良明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpDefectAssySlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpDefectAssySlvService.Delete(idArr, "删除不良明细"));
        }

        /// <summary>
        /// 导出不良明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "不良明细导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:defectassyslv:export")]
        public IActionResult Export([FromQuery] PpDefectAssySlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpDefectAssySlvService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "pp:defectassyslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpDefectAssySlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpDefectAssySlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpDefectAssySlvService.ImportPpDefectAssySlv(list.Adapt<List<PpDefectAssySlv>>()));
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
            var result = DownloadImportTemplate(new List<PpDefectAssySlvImportTpl>() { }, "PpDefectAssySlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}