using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 检测项目
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:07:59
    /// </summary>
    [Verify]
    [Route("Logistics/QmInspectingItem")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmInspectingItemController : BaseController
    {
        /// <summary>
        /// 检测项目接口
        /// </summary>
        private readonly IQmInspectingItemService _QmInspectingItemService;

        public QmInspectingItemController(IQmInspectingItemService QmInspectingItemService)
        {
            _QmInspectingItemService = QmInspectingItemService;
        }

        /// <summary>
        /// 查询检测项目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:inspectingitem:list")]
        public IActionResult QueryQmInspectingItem([FromQuery] QmInspectingItemQueryDto parm)
        {
            var response = _QmInspectingItemService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询检测项目详情
        /// </summary>
        /// <param name="QminsItemSfId"></param>
        /// <returns></returns>
        [HttpGet("{QminsItemSfId}")]
        [ActionPermissionFilter(Permission = "qm:inspectingitem:query")]
        public IActionResult GetQmInspectingItem(long QminsItemSfId)
        {
            var response = _QmInspectingItemService.GetInfo(QminsItemSfId);
            
            var info = response.Adapt<QmInspectingItemDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加检测项目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:inspectingitem:add")]
        [Log(Title = "检测项目", BusinessType = BusinessType.INSERT)]
        public IActionResult AddQmInspectingItem([FromBody] QmInspectingItemDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmInspectingItemService.CheckInputUnique(parm.QminsItemSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增检测项目 '{parm.QminsItemSfId}'失败(Add failed)，输入的检测项目已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmInspectingItem>().ToCreate(HttpContext);

            var response = _QmInspectingItemService.AddQmInspectingItem(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新检测项目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:inspectingitem:edit")]
        [Log(Title = "检测项目", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateQmInspectingItem([FromBody] QmInspectingItemDto parm)
        {
            var modal = parm.Adapt<QmInspectingItem>().ToUpdate(HttpContext);
            var response = _QmInspectingItemService.UpdateQmInspectingItem(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除检测项目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:inspectingitem:delete")]
        [Log(Title = "检测项目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmInspectingItem([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmInspectingItemService.Delete(idArr, "删除检测项目"));
        }

        /// <summary>
        /// 导出检测项目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "检测项目", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:inspectingitem:export")]
        public IActionResult Export([FromQuery] QmInspectingItemQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmInspectingItemService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "检测项目", "检测项目");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "检测项目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:inspectingitem:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<QmInspectingItemDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmInspectingItemDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmInspectingItemService.ImportQmInspectingItem(list.Adapt<List<QmInspectingItem>>()));
        }

        /// <summary>
        /// 检测项目导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "检测项目模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmInspectingItemImportTpl>() { }, "QmInspectingItem_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}