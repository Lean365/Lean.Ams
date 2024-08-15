using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 出货检验
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:46:39
    /// </summary>
    [Verify]
    [Route("Logistics/QmOutgoing")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmOutgoingController : BaseController
    {
        /// <summary>
        /// 出货检验接口
        /// </summary>
        private readonly IQmOutgoingService _QmOutgoingService;

        public QmOutgoingController(IQmOutgoingService QmOutgoingService)
        {
            _QmOutgoingService = QmOutgoingService;
        }

        /// <summary>
        /// 查询出货检验列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:outgoing:list")]
        public IActionResult QueryQmOutgoing([FromQuery] QmOutgoingQueryDto parm)
        {
            var response = _QmOutgoingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询出货检验详情
        /// </summary>
        /// <param name="QmoutSfId"></param>
        /// <returns></returns>
        [HttpGet("{QmoutSfId}")]
        [ActionPermissionFilter(Permission = "qm:outgoing:query")]
        public IActionResult GetQmOutgoing(long QmoutSfId)
        {
            var response = _QmOutgoingService.GetInfo(QmoutSfId);
            
            var info = response.Adapt<QmOutgoingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加出货检验
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:outgoing:add")]
        [Log(Title = "出货检验", BusinessType = BusinessType.INSERT)]
        public IActionResult AddQmOutgoing([FromBody] QmOutgoingDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmOutgoingService.CheckInputUnique(parm.QmoutSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增出货检验 '{parm.QmoutSfId}'失败(Add failed)，输入的出货检验已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmOutgoing>().ToCreate(HttpContext);

            var response = _QmOutgoingService.AddQmOutgoing(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新出货检验
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:outgoing:edit")]
        [Log(Title = "出货检验", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateQmOutgoing([FromBody] QmOutgoingDto parm)
        {
            var modal = parm.Adapt<QmOutgoing>().ToUpdate(HttpContext);
            var response = _QmOutgoingService.UpdateQmOutgoing(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除出货检验
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:outgoing:delete")]
        [Log(Title = "出货检验", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmOutgoing([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmOutgoingService.Delete(idArr, "删除出货检验"));
        }

        /// <summary>
        /// 导出出货检验
        /// </summary>
        /// <returns></returns>
        [Log(Title = "出货检验", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:outgoing:export")]
        public IActionResult Export([FromQuery] QmOutgoingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmOutgoingService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "出货检验", "出货检验");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "出货检验导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:outgoing:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<QmOutgoingDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmOutgoingDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmOutgoingService.ImportQmOutgoing(list.Adapt<List<QmOutgoing>>()));
        }

        /// <summary>
        /// 出货检验导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "出货检验模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmOutgoingImportTpl>() { }, "QmOutgoing_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}