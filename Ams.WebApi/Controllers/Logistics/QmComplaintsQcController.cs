using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// QC客诉
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:13:49
    /// </summary>
    [Verify]
    [Route("Logistics/QmComplaintsQc")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmComplaintsQcController : BaseController
    {
        /// <summary>
        /// QC客诉接口
        /// </summary>
        private readonly IQmComplaintsQcService _QmComplaintsQcService;

        public QmComplaintsQcController(IQmComplaintsQcService QmComplaintsQcService)
        {
            _QmComplaintsQcService = QmComplaintsQcService;
        }

        /// <summary>
        /// 查询QC客诉列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:complaintsqc:list")]
        public IActionResult QueryQmComplaintsQc([FromQuery] QmComplaintsQcQueryDto parm)
        {
            var response = _QmComplaintsQcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询QC客诉详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:complaintsqc:query")]
        public IActionResult GetQmComplaintsQc(long Id)
        {
            var response = _QmComplaintsQcService.GetInfo(Id);
            
            var info = response.Adapt<QmComplaintsQcDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加QC客诉
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:complaintsqc:add")]
        [Log(Title = "QC客诉", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmComplaintsQc([FromBody] QmComplaintsQcDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmComplaintsQcService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增QC客诉 '{parm.Id}'失败(Add failed)，输入的QC客诉已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmComplaintsQc>().ToCreate(HttpContext);

            var response = _QmComplaintsQcService.AddQmComplaintsQc(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新QC客诉
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:complaintsqc:edit")]
        [Log(Title = "QC客诉", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmComplaintsQc([FromBody] QmComplaintsQcDto parm)
        {
            var modal = parm.Adapt<QmComplaintsQc>().ToUpdate(HttpContext);
            var response = _QmComplaintsQcService.UpdateQmComplaintsQc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除QC客诉
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:complaintsqc:delete")]
        [Log(Title = "QC客诉", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmComplaintsQc([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmComplaintsQcService.Delete(idArr, "删除QC客诉"));
        }

        /// <summary>
        /// 导出QC客诉
        /// </summary>
        /// <returns></returns>
        [Log(Title = "QC客诉导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:complaintsqc:export")]
        public IActionResult Export([FromQuery] QmComplaintsQcQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmComplaintsQcService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "QC客诉", "QC客诉");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入QC客诉
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "QC客诉导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:complaintsqc:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmComplaintsQcDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmComplaintsQcDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmComplaintsQcService.ImportQmComplaintsQc(list.Adapt<List<QmComplaintsQc>>()));
        }

        /// <summary>
        /// QC客诉
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "QC客诉模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmComplaintsQcImportTpl>() { }, "QmComplaintsQc_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}