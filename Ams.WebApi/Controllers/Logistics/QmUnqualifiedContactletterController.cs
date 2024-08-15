using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 不合格联络
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:53
    /// </summary>
    [Verify]
    [Route("Logistics/QmUnqualifiedContactletter")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmUnqualifiedContactletterController : BaseController
    {
        /// <summary>
        /// 不合格联络接口
        /// </summary>
        private readonly IQmUnqualifiedContactletterService _QmUnqualifiedContactletterService;

        public QmUnqualifiedContactletterController(IQmUnqualifiedContactletterService QmUnqualifiedContactletterService)
        {
            _QmUnqualifiedContactletterService = QmUnqualifiedContactletterService;
        }

        /// <summary>
        /// 查询不合格联络列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:unqualifiedcontactletter:list")]
        public IActionResult QueryQmUnqualifiedContactletter([FromQuery] QmUnqualifiedContactletterQueryDto parm)
        {
            var response = _QmUnqualifiedContactletterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询不合格联络详情
        /// </summary>
        /// <param name="QucdSfId"></param>
        /// <returns></returns>
        [HttpGet("{QucdSfId}")]
        [ActionPermissionFilter(Permission = "qm:unqualifiedcontactletter:query")]
        public IActionResult GetQmUnqualifiedContactletter(long QucdSfId)
        {
            var response = _QmUnqualifiedContactletterService.GetInfo(QucdSfId);
            
            var info = response.Adapt<QmUnqualifiedContactletterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加不合格联络
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:unqualifiedcontactletter:add")]
        [Log(Title = "不合格联络", BusinessType = BusinessType.INSERT)]
        public IActionResult AddQmUnqualifiedContactletter([FromBody] QmUnqualifiedContactletterDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmUnqualifiedContactletterService.CheckInputUnique(parm.QucdSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增不合格联络 '{parm.QucdSfId}'失败(Add failed)，输入的不合格联络已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmUnqualifiedContactletter>().ToCreate(HttpContext);

            var response = _QmUnqualifiedContactletterService.AddQmUnqualifiedContactletter(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新不合格联络
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:unqualifiedcontactletter:edit")]
        [Log(Title = "不合格联络", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateQmUnqualifiedContactletter([FromBody] QmUnqualifiedContactletterDto parm)
        {
            var modal = parm.Adapt<QmUnqualifiedContactletter>().ToUpdate(HttpContext);
            var response = _QmUnqualifiedContactletterService.UpdateQmUnqualifiedContactletter(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除不合格联络
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:unqualifiedcontactletter:delete")]
        [Log(Title = "不合格联络", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmUnqualifiedContactletter([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmUnqualifiedContactletterService.Delete(idArr, "删除不合格联络"));
        }

        /// <summary>
        /// 导出不合格联络
        /// </summary>
        /// <returns></returns>
        [Log(Title = "不合格联络", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:unqualifiedcontactletter:export")]
        public IActionResult Export([FromQuery] QmUnqualifiedContactletterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmUnqualifiedContactletterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "不合格联络", "不合格联络");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "不合格联络导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:unqualifiedcontactletter:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<QmUnqualifiedContactletterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmUnqualifiedContactletterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmUnqualifiedContactletterService.ImportQmUnqualifiedContactletter(list.Adapt<List<QmUnqualifiedContactletter>>()));
        }

        /// <summary>
        /// 不合格联络导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "不合格联络模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmUnqualifiedContactletterImportTpl>() { }, "QmUnqualifiedContactletter_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}