using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 进料检验
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:53:50
    /// </summary>
    [Verify]
    [Route("Logistics/QmIncoming")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmIncomingController : BaseController
    {
        /// <summary>
        /// 进料检验接口
        /// </summary>
        private readonly IQmIncomingService _QmIncomingService;

        public QmIncomingController(IQmIncomingService QmIncomingService)
        {
            _QmIncomingService = QmIncomingService;
        }

        /// <summary>
        /// 查询进料检验列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:incoming:list")]
        public IActionResult QueryQmIncoming([FromQuery] QmIncomingQueryDto parm)
        {
            var response = _QmIncomingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询进料检验详情
        /// </summary>
        /// <param name="QminSfId"></param>
        /// <returns></returns>
        [HttpGet("{QminSfId}")]
        [ActionPermissionFilter(Permission = "qm:incoming:query")]
        public IActionResult GetQmIncoming(long QminSfId)
        {
            var response = _QmIncomingService.GetInfo(QminSfId);
            
            var info = response.Adapt<QmIncomingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加进料检验
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:incoming:add")]
        [Log(Title = "进料检验", BusinessType = BusinessType.INSERT)]
        public IActionResult AddQmIncoming([FromBody] QmIncomingDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmIncomingService.CheckInputUnique(parm.QminSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增进料检验 '{parm.QminSfId}'失败(Add failed)，输入的进料检验已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmIncoming>().ToCreate(HttpContext);

            var response = _QmIncomingService.AddQmIncoming(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新进料检验
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:incoming:edit")]
        [Log(Title = "进料检验", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateQmIncoming([FromBody] QmIncomingDto parm)
        {
            var modal = parm.Adapt<QmIncoming>().ToUpdate(HttpContext);
            var response = _QmIncomingService.UpdateQmIncoming(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除进料检验
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:incoming:delete")]
        [Log(Title = "进料检验", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmIncoming([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmIncomingService.Delete(idArr, "删除进料检验"));
        }

        /// <summary>
        /// 导出进料检验
        /// </summary>
        /// <returns></returns>
        [Log(Title = "进料检验", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:incoming:export")]
        public IActionResult Export([FromQuery] QmIncomingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmIncomingService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "进料检验", "进料检验");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "进料检验导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:incoming:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<QmIncomingDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmIncomingDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmIncomingService.ImportQmIncoming(list.Adapt<List<QmIncoming>>()));
        }

        /// <summary>
        /// 进料检验导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "进料检验模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmIncomingImportTpl>() { }, "QmIncoming_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}