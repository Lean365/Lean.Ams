using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Service.Filters;
using Ams.Service.Logistics.ILogisticsService;
using Microsoft.AspNetCore.Mvc;
using MiniExcelLibs;

//创建时间：2024-06-27
namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 生产班组
    /// </summary>
    [Verify]
    [Route("Logistics/PpLine")]
    public class PpLineController : BaseController
    {
        /// <summary>
        /// 生产班组接口
        /// </summary>
        private readonly IPpLineService _PpLineService;

        public PpLineController(IPpLineService PpLineService)
        {
            _PpLineService = PpLineService;
        }

        /// <summary>
        /// 查询生产班组列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "ppline:list")]
        public IActionResult QueryPpLine([FromQuery] PpLineQueryDto parm)
        {
            var response = _PpLineService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询生产班组详情
        /// </summary>
        /// <param name="PlSFID"></param>
        /// <returns></returns>
        [HttpGet("{PlSFID}")]
        [ActionPermissionFilter(Permission = "ppline:query")]
        public IActionResult GetPpLine(long PlSFID)
        {
            var response = _PpLineService.GetInfo(PlSFID);

            var info = response.Adapt<PpLineDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生产班组
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "ppline:add")]
        [Log(Title = "生产班组", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpLine([FromBody] PpLineDto parm)
        {
            var modal = parm.Adapt<PpLine>().ToCreate(HttpContext);

            var response = _PpLineService.AddPpLine(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生产班组
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "ppline:edit")]
        [Log(Title = "生产班组", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpLine([FromBody] PpLineDto parm)
        {
            var modal = parm.Adapt<PpLine>().ToUpdate(HttpContext);
            var response = _PpLineService.UpdatePpLine(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产班组
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "ppline:delete")]
        [Log(Title = "生产班组", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpLine([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpLineService.Delete(idArr));
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "生产班组导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "ppline:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpLineDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpLineDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpLineService.ImportPpLine(list.Adapt<List<PpLine>>()));
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
            var result = DownloadImportTemplate(new List<PpLineDto>() { }, "PpLine");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}