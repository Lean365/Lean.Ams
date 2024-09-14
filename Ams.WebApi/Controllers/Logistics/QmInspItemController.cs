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
    /// @Date: 2024/9/11 11:48:49
    /// </summary>
    [Verify]
    [Route("Logistics/QmInspItem")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmInspItemController : BaseController
    {
        /// <summary>
        /// 检测项目接口
        /// </summary>
        private readonly IQmInspItemService _QmInspItemService;

        public QmInspItemController(IQmInspItemService QmInspItemService)
        {
            _QmInspItemService = QmInspItemService;
        }

        /// <summary>
        /// 查询检测项目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:inspitem:list")]
        public IActionResult QueryQmInspItem([FromQuery] QmInspItemQueryDto parm)
        {
            var response = _QmInspItemService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询检测项目详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:inspitem:query")]
        public IActionResult GetQmInspItem(long Id)
        {
            var response = _QmInspItemService.GetInfo(Id);
            
            var info = response.Adapt<QmInspItemDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加检测项目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:inspitem:add")]
        [Log(Title = "检测项目", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmInspItem([FromBody] QmInspItemDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmInspItemService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增检测项目 '{parm.Id}'失败(Add failed)，输入的检测项目已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmInspItem>().ToCreate(HttpContext);

            var response = _QmInspItemService.AddQmInspItem(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新检测项目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:inspitem:edit")]
        [Log(Title = "检测项目", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmInspItem([FromBody] QmInspItemDto parm)
        {
            var modal = parm.Adapt<QmInspItem>().ToUpdate(HttpContext);
            var response = _QmInspItemService.UpdateQmInspItem(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除检测项目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:inspitem:delete")]
        [Log(Title = "检测项目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmInspItem([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmInspItemService.Delete(idArr, "删除检测项目"));
        }

        /// <summary>
        /// 导出检测项目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "检测项目导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:inspitem:export")]
        public IActionResult Export([FromQuery] QmInspItemQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmInspItemService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "检测项目", "检测项目");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入检测项目
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "检测项目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:inspitem:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmInspItemDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmInspItemDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmInspItemService.ImportQmInspItem(list.Adapt<List<QmInspItem>>()));
        }

        /// <summary>
        /// 检测项目
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "检测项目模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmInspItemImportTpl>() { }, "QmInspItem_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}