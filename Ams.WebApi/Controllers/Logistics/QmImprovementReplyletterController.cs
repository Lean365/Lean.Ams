using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 分析对策
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:55
    /// </summary>
    [Verify]
    [Route("Logistics/QmImprovementReplyletter")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmImprovementReplyletterController : BaseController
    {
        /// <summary>
        /// 分析对策接口
        /// </summary>
        private readonly IQmImprovementReplyletterService _QmImprovementReplyletterService;

        public QmImprovementReplyletterController(IQmImprovementReplyletterService QmImprovementReplyletterService)
        {
            _QmImprovementReplyletterService = QmImprovementReplyletterService;
        }

        /// <summary>
        /// 查询分析对策列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:improvementreplyletter:list")]
        public IActionResult QueryQmImprovementReplyletter([FromQuery] QmImprovementReplyletterQueryDto parm)
        {
            var response = _QmImprovementReplyletterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询分析对策详情
        /// </summary>
        /// <param name="QirdSfId"></param>
        /// <returns></returns>
        [HttpGet("{QirdSfId}")]
        [ActionPermissionFilter(Permission = "qm:improvementreplyletter:query")]
        public IActionResult GetQmImprovementReplyletter(long QirdSfId)
        {
            var response = _QmImprovementReplyletterService.GetInfo(QirdSfId);
            
            var info = response.Adapt<QmImprovementReplyletterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加分析对策
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:improvementreplyletter:add")]
        [Log(Title = "分析对策", BusinessType = BusinessType.INSERT)]
        public IActionResult AddQmImprovementReplyletter([FromBody] QmImprovementReplyletterDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmImprovementReplyletterService.CheckInputUnique(parm.QirdSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增分析对策 '{parm.QirdSfId}'失败(Add failed)，输入的分析对策已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmImprovementReplyletter>().ToCreate(HttpContext);

            var response = _QmImprovementReplyletterService.AddQmImprovementReplyletter(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新分析对策
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:improvementreplyletter:edit")]
        [Log(Title = "分析对策", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateQmImprovementReplyletter([FromBody] QmImprovementReplyletterDto parm)
        {
            var modal = parm.Adapt<QmImprovementReplyletter>().ToUpdate(HttpContext);
            var response = _QmImprovementReplyletterService.UpdateQmImprovementReplyletter(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除分析对策
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:improvementreplyletter:delete")]
        [Log(Title = "分析对策", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmImprovementReplyletter([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmImprovementReplyletterService.Delete(idArr, "删除分析对策"));
        }

        /// <summary>
        /// 导出分析对策
        /// </summary>
        /// <returns></returns>
        [Log(Title = "分析对策", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:improvementreplyletter:export")]
        public IActionResult Export([FromQuery] QmImprovementReplyletterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmImprovementReplyletterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "分析对策", "分析对策");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "分析对策导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:improvementreplyletter:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<QmImprovementReplyletterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmImprovementReplyletterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmImprovementReplyletterService.ImportQmImprovementReplyletter(list.Adapt<List<QmImprovementReplyletter>>()));
        }

        /// <summary>
        /// 分析对策导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "分析对策模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmImprovementReplyletterImportTpl>() { }, "QmImprovementReplyletter_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}