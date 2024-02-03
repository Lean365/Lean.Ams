using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 生产班组
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:53:14)
    /// </summary>
    [Verify]
    [Route("logistics/Line")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class LineController : BaseController
    {
        /// <summary>
        /// 生产班组接口
        /// </summary>
        private readonly ILineService _LineService;

        public LineController(ILineService LineService)
        {
            _LineService = LineService;
        }

        /// <summary>
        /// 查询生产班组列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:line:list")]
        public IActionResult QueryLine([FromQuery] LineQueryDto parm)
        {
            var response = _LineService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询生产班组详情
        /// </summary>
        /// <param name="PlSFID"></param>
        /// <returns></returns>
        [HttpGet("{PlSFID}")]
        [ActionPermissionFilter(Permission = "pp:line:query")]
        public IActionResult GetLine(long PlSFID)
        {
            var response = _LineService.GetInfo(PlSFID);
            
            var info = response.Adapt<LineDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生产班组
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:line:add")]
        [Log(Title = "生产班组", BusinessType = BusinessType.INSERT)]
        public IActionResult AddLine([FromBody] LineDto parm)
        {
            var modal = parm.Adapt<Line>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_LineService.CheckEntryUnique(parm.PlLineCode.ToString()+ parm.PlLineType.ToString()+ parm.PlLineName.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)生产班组 '{parm.PlLineCode.ToString() +","+ parm.PlLineType.ToString()+"," + parm.PlLineName.ToString()}'失败(failed)，输入的(The entered)生产班组已存在(already exists)"));
            }
            var response = _LineService.AddLine(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生产班组
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:line:edit")]
        [Log(Title = "生产班组", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateLine([FromBody] LineDto parm)
        {
            var modal = parm.Adapt<Line>().ToUpdate(HttpContext);
            var response = _LineService.UpdateLine(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产班组
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:line:delete")]
        [Log(Title = "生产班组", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteLine([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_LineService.Delete(idArr, "删除生产班组"));
        }

        /// <summary>
        /// 导出生产班组
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产班组", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:line:export")]
        public IActionResult Export([FromQuery] LineQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _LineService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生产班组", "生产班组","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入生产班组
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "生产班组导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:line:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<LineDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<LineDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_LineService.ImportLine(list.Adapt<List<Line>>()));
        }

        /// <summary>
        /// 生产班组导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "生产班组模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<LineDto>() { }, "LineTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}