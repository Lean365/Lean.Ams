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
    /// 原因类别
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:54:27)
    /// </summary>
    [Verify]
    [Route("logistics/CauseType")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class CauseTypeController : BaseController
    {
        /// <summary>
        /// 原因类别接口
        /// </summary>
        private readonly ICauseTypeService _CauseTypeService;

        public CauseTypeController(ICauseTypeService CauseTypeService)
        {
            _CauseTypeService = CauseTypeService;
        }

        /// <summary>
        /// 查询原因类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:causetype:list")]
        public IActionResult QueryCauseType([FromQuery] CauseTypeQueryDto parm)
        {
            var response = _CauseTypeService.GetList(parm);
            return SUCCESS(response, TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询原因类别详情
        /// </summary>
        /// <param name="CtSFID"></param>
        /// <returns></returns>
        [HttpGet("{CtSFID}")]
        [ActionPermissionFilter(Permission = "pp:causetype:query")]
        public IActionResult GetCauseType(long CtSFID)
        {
            var response = _CauseTypeService.GetInfo(CtSFID);

            var info = response.Adapt<CauseTypeDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加原因类别
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:causetype:add")]
        [Log(Title = "原因类别", BusinessType = BusinessType.INSERT)]
        public IActionResult AddCauseType([FromBody] CauseTypeDto parm)
        {
            var modal = parm.Adapt<CauseType>().ToCreate(HttpContext);

            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_CauseTypeService.CheckEntryUnique(parm.CtCauseType.ToString() + parm.CtCauseText.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)原因类别 '{parm.CtCauseType.ToString() + "," + parm.CtCauseText.ToString()}'失败(failed)，输入的(The entered)原因类别已存在(already exists)"));
            }
            var response = _CauseTypeService.AddCauseType(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新原因类别
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:causetype:edit")]
        [Log(Title = "原因类别", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateCauseType([FromBody] CauseTypeDto parm)
        {
            var modal = parm.Adapt<CauseType>().ToUpdate(HttpContext);
            var response = _CauseTypeService.UpdateCauseType(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除原因类别
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:causetype:delete")]
        [Log(Title = "原因类别", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteCauseType([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_CauseTypeService.Delete(idArr, "删除原因类别"));
        }

        /// <summary>
        /// 导出原因类别
        /// </summary>
        /// <returns></returns>
        [Log(Title = "原因类别", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:causetype:export")]
        public IActionResult Export([FromQuery] CauseTypeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _CauseTypeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "原因类别", "原因类别", "export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入原因类别
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "原因类别导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:causetype:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<CauseTypeDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<CauseTypeDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_CauseTypeService.ImportCauseType(list.Adapt<List<CauseType>>()));
        }

        /// <summary>
        /// 原因类别导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "原因类别模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<CauseTypeDto>() { }, "CauseTypeTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}