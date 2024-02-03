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
    /// 标准工时
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 9:28:16)
    /// </summary>
    [Verify]
    [Route("logistics/Manhours")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class ManhoursController : BaseController
    {
        /// <summary>
        /// 标准工时接口
        /// </summary>
        private readonly IManhoursService _ManhoursService;

        public ManhoursController(IManhoursService ManhoursService)
        {
            _ManhoursService = ManhoursService;
        }

        /// <summary>
        /// 查询标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:manhours:list")]
        public IActionResult QueryManhours([FromQuery] ManhoursQueryDto parm)
        {
            var response = _ManhoursService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询标准工时详情
        /// </summary>
        /// <param name="MhSFID"></param>
        /// <returns></returns>
        [HttpGet("{MhSFID}")]
        [ActionPermissionFilter(Permission = "pp:manhours:query")]
        public IActionResult GetManhours(long MhSFID)
        {
            var response = _ManhoursService.GetInfo(MhSFID);
            
            var info = response.Adapt<ManhoursDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加标准工时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:manhours:add")]
        [Log(Title = "标准工时", BusinessType = BusinessType.INSERT)]
        public IActionResult AddManhours([FromBody] ManhoursDto parm)
        {
            var modal = parm.Adapt<Manhours>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_ManhoursService.CheckEntryUnique(parm.MhPlant.ToString()+ parm.MhItem.ToString()+ parm.MhWcName.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)标准工时 '{parm.MhPlant.ToString() +","+ parm.MhItem.ToString() + "," + parm.MhWcName.ToString()}'失败(failed)，输入的(The entered)标准工时已存在(already exists)"));
            }
            var response = _ManhoursService.AddManhours(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新标准工时
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:manhours:edit")]
        [Log(Title = "标准工时", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateManhours([FromBody] ManhoursDto parm)
        {
            var modal = parm.Adapt<Manhours>().ToUpdate(HttpContext);
            var response = _ManhoursService.UpdateManhours(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除标准工时
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:manhours:delete")]
        [Log(Title = "标准工时", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteManhours([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_ManhoursService.Delete(idArr, "删除标准工时"));
        }

        /// <summary>
        /// 导出标准工时
        /// </summary>
        /// <returns></returns>
        [Log(Title = "标准工时", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:manhours:export")]
        public IActionResult Export([FromQuery] ManhoursQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _ManhoursService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "标准工时", "标准工时","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入标准工时
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "标准工时导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:manhours:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<ManhoursDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<ManhoursDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_ManhoursService.ImportManhours(list.Adapt<List<Manhours>>()));
        }

        /// <summary>
        /// 标准工时导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "标准工时模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<ManhoursDto>() { }, "ManhoursTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}