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
    /// @Date: 2024/9/11 16:44:05
    /// </summary>
    [Verify]
    [Route("Logistics/QmIpvReply")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmIpvReplyController : BaseController
    {
        /// <summary>
        /// 分析对策接口
        /// </summary>
        private readonly IQmIpvReplyService _QmIpvReplyService;

        public QmIpvReplyController(IQmIpvReplyService QmIpvReplyService)
        {
            _QmIpvReplyService = QmIpvReplyService;
        }

        /// <summary>
        /// 查询分析对策列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:ipvreply:list")]
        public IActionResult QueryQmIpvReply([FromQuery] QmIpvReplyQueryDto parm)
        {
            var response = _QmIpvReplyService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询分析对策详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:ipvreply:query")]
        public IActionResult GetQmIpvReply(long Id)
        {
            var response = _QmIpvReplyService.GetInfo(Id);
            
            var info = response.Adapt<QmIpvReplyDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加分析对策
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:ipvreply:add")]
        [Log(Title = "分析对策", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmIpvReply([FromBody] QmIpvReplyDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmIpvReplyService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增分析对策 '{parm.Id}'失败(Add failed)，输入的分析对策已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmIpvReply>().ToCreate(HttpContext);

            var response = _QmIpvReplyService.AddQmIpvReply(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新分析对策
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:ipvreply:edit")]
        [Log(Title = "分析对策", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmIpvReply([FromBody] QmIpvReplyDto parm)
        {
            var modal = parm.Adapt<QmIpvReply>().ToUpdate(HttpContext);
            var response = _QmIpvReplyService.UpdateQmIpvReply(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除分析对策
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:ipvreply:delete")]
        [Log(Title = "分析对策", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmIpvReply([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmIpvReplyService.Delete(idArr, "删除分析对策"));
        }

        /// <summary>
        /// 导出分析对策
        /// </summary>
        /// <returns></returns>
        [Log(Title = "分析对策导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:ipvreply:export")]
        public IActionResult Export([FromQuery] QmIpvReplyQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmIpvReplyService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "分析对策", "分析对策");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入分析对策
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "分析对策导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:ipvreply:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmIpvReplyDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmIpvReplyDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmIpvReplyService.ImportQmIpvReply(list.Adapt<List<QmIpvReply>>()));
        }

        /// <summary>
        /// 分析对策
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "分析对策模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmIpvReplyImportTpl>() { }, "QmIpvReply_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}