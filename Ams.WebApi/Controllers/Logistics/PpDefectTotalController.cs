using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 不良统计
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:12
    /// </summary>
    [Verify]
    [Route("Logistics/PpDefectTotal")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpDefectTotalController : BaseController
    {
        /// <summary>
        /// 不良统计接口
        /// </summary>
        private readonly IPpDefectTotalService _PpDefectTotalService;

        public PpDefectTotalController(IPpDefectTotalService PpDefectTotalService)
        {
            _PpDefectTotalService = PpDefectTotalService;
        }

        /// <summary>
        /// 查询不良统计列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:defecttotal:list")]
        public IActionResult QueryPpDefectTotal([FromQuery] PpDefectTotalQueryDto parm)
        {
            var response = _PpDefectTotalService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询不良统计详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:defecttotal:query")]
        public IActionResult GetPpDefectTotal(long Id)
        {
            var response = _PpDefectTotalService.GetInfo(Id);
            
            var info = response.Adapt<PpDefectTotalDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加不良统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:defecttotal:add")]
        [Log(Title = "不良统计", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpDefectTotal([FromBody] PpDefectTotalDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpDefectTotalService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增不良统计 '{parm.Id}'失败(Add failed)，输入的不良统计已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpDefectTotal>().ToCreate(HttpContext);

            var response = _PpDefectTotalService.AddPpDefectTotal(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新不良统计
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:defecttotal:edit")]
        [Log(Title = "不良统计", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpDefectTotal([FromBody] PpDefectTotalDto parm)
        {
            var modal = parm.Adapt<PpDefectTotal>().ToUpdate(HttpContext);
            var response = _PpDefectTotalService.UpdatePpDefectTotal(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除不良统计
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:defecttotal:delete")]
        [Log(Title = "不良统计", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpDefectTotal([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpDefectTotalService.Delete(idArr, "删除不良统计"));
        }

        /// <summary>
        /// 导出不良统计
        /// </summary>
        /// <returns></returns>
        [Log(Title = "不良统计导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:defecttotal:export")]
        public IActionResult Export([FromQuery] PpDefectTotalQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpDefectTotalService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "不良统计", "不良统计");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入不良统计
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "不良统计导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:defecttotal:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpDefectTotalDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpDefectTotalDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpDefectTotalService.ImportPpDefectTotal(list.Adapt<List<PpDefectTotal>>()));
        }

        /// <summary>
        /// 不良统计
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "不良统计模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpDefectTotalImportTpl>() { }, "PpDefectTotal_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}