using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 主客诉管理
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:33:20
    /// </summary>
    [Verify]
    [Route("Logistics/QmComplaintsMaster")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmComplaintsMasterController : BaseController
    {
        /// <summary>
        /// 主客诉管理接口
        /// </summary>
        private readonly IQmComplaintsMasterService _QmComplaintsMasterService;

        public QmComplaintsMasterController(IQmComplaintsMasterService QmComplaintsMasterService)
        {
            _QmComplaintsMasterService = QmComplaintsMasterService;
        }

        /// <summary>
        /// 查询主客诉管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:list")]
        public IActionResult QueryQmComplaintsMaster([FromQuery] QmComplaintsMasterQueryDto parm)
        {
            var response = _QmComplaintsMasterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询主客诉管理详情
        /// </summary>
        /// <param name="QmcmSfId"></param>
        /// <returns></returns>
        [HttpGet("{QmcmSfId}")]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:query")]
        public IActionResult GetQmComplaintsMaster(long QmcmSfId)
        {
            var response = _QmComplaintsMasterService.GetInfo(QmcmSfId);
            
            var info = response.Adapt<QmComplaintsMasterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加主客诉管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:add")]
        [Log(Title = "主客诉管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddQmComplaintsMaster([FromBody] QmComplaintsMasterDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmComplaintsMasterService.CheckInputUnique(parm.QmcmSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增主客诉管理 '{parm.QmcmSfId}'失败(Add failed)，输入的主客诉管理已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmComplaintsMaster>().ToCreate(HttpContext);

            var response = _QmComplaintsMasterService.AddQmComplaintsMaster(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新主客诉管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:edit")]
        [Log(Title = "主客诉管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateQmComplaintsMaster([FromBody] QmComplaintsMasterDto parm)
        {
            var modal = parm.Adapt<QmComplaintsMaster>().ToUpdate(HttpContext);
            var response = _QmComplaintsMasterService.UpdateQmComplaintsMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除主客诉管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:delete")]
        [Log(Title = "主客诉管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmComplaintsMaster([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmComplaintsMasterService.Delete(idArr, "删除主客诉管理"));
        }

        /// <summary>
        /// 导出主客诉管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "主客诉管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:export")]
        public IActionResult Export([FromQuery] QmComplaintsMasterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmComplaintsMasterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "主客诉管理", "主客诉管理");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "主客诉管理导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<QmComplaintsMasterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmComplaintsMasterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmComplaintsMasterService.ImportQmComplaintsMaster(list.Adapt<List<QmComplaintsMaster>>()));
        }

        /// <summary>
        /// 主客诉管理导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "主客诉管理模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmComplaintsMasterImportTpl>() { }, "QmComplaintsMaster_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}