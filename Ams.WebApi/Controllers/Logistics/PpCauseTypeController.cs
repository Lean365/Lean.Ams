using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 原因类别
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:12:48
    /// </summary>
    [Verify]
    [Route("Logistics/PpCauseType")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpCauseTypeController : BaseController
    {
        /// <summary>
        /// 原因类别接口
        /// </summary>
        private readonly IPpCauseTypeService _PpCauseTypeService;

        public PpCauseTypeController(IPpCauseTypeService PpCauseTypeService)
        {
            _PpCauseTypeService = PpCauseTypeService;
        }

        /// <summary>
        /// 查询原因类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:causetype:list")]
        public IActionResult QueryPpCauseType([FromQuery] PpCauseTypeQueryDto parm)
        {
            var response = _PpCauseTypeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询原因类别详情
        /// </summary>
        /// <param name="CtSfId"></param>
        /// <returns></returns>
        [HttpGet("{CtSfId}")]
        [ActionPermissionFilter(Permission = "pp:causetype:query")]
        public IActionResult GetPpCauseType(long CtSfId)
        {
            var response = _PpCauseTypeService.GetInfo(CtSfId);
            
            var info = response.Adapt<PpCauseTypeDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加原因类别
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:causetype:add")]
        [Log(Title = "原因类别", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpCauseType([FromBody] PpCauseTypeDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpCauseTypeService.CheckInputUnique(parm.CtSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增原因类别 '{parm.CtSfId}'失败(Add failed)，输入的原因类别已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpCauseType>().ToCreate(HttpContext);

            var response = _PpCauseTypeService.AddPpCauseType(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新原因类别
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:causetype:edit")]
        [Log(Title = "原因类别", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpCauseType([FromBody] PpCauseTypeDto parm)
        {
            var modal = parm.Adapt<PpCauseType>().ToUpdate(HttpContext);
            var response = _PpCauseTypeService.UpdatePpCauseType(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除原因类别
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:causetype:delete")]
        [Log(Title = "原因类别", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpCauseType([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpCauseTypeService.Delete(idArr, "删除原因类别"));
        }

        /// <summary>
        /// 导出原因类别
        /// </summary>
        /// <returns></returns>
        [Log(Title = "原因类别", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:causetype:export")]
        public IActionResult Export([FromQuery] PpCauseTypeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpCauseTypeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "原因类别", "原因类别");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "原因类别导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:causetype:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpCauseTypeDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpCauseTypeDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpCauseTypeService.ImportPpCauseType(list.Adapt<List<PpCauseType>>()));
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
            var result = DownloadImportTemplate(new List<PpCauseTypeImportTpl>() { }, "PpCauseType_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}