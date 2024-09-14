using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 废弃部品
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:46:48
    /// </summary>
    [Verify]
    [Route("Logistics/QmCostWaste")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmCostWasteController : BaseController
    {
        /// <summary>
        /// 废弃部品接口
        /// </summary>
        private readonly IQmCostWasteService _QmCostWasteService;

        public QmCostWasteController(IQmCostWasteService QmCostWasteService)
        {
            _QmCostWasteService = QmCostWasteService;
        }

        /// <summary>
        /// 查询废弃部品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:costwaste:list")]
        public IActionResult QueryQmCostWaste([FromQuery] QmCostWasteQueryDto parm)
        {
            var response = _QmCostWasteService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询废弃部品详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:costwaste:query")]
        public IActionResult GetQmCostWaste(int Id)
        {
            var response = _QmCostWasteService.GetInfo(Id);
            
            var info = response.Adapt<QmCostWasteDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加废弃部品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:costwaste:add")]
        [Log(Title = "废弃部品", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmCostWaste([FromBody] QmCostWasteDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmCostWasteService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增废弃部品 '{parm.Id}'失败(Add failed)，输入的废弃部品已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmCostWaste>().ToCreate(HttpContext);

            var response = _QmCostWasteService.AddQmCostWaste(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新废弃部品
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:costwaste:edit")]
        [Log(Title = "废弃部品", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmCostWaste([FromBody] QmCostWasteDto parm)
        {
            var modal = parm.Adapt<QmCostWaste>().ToUpdate(HttpContext);
            var response = _QmCostWasteService.UpdateQmCostWaste(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除废弃部品
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:costwaste:delete")]
        [Log(Title = "废弃部品", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmCostWaste([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_QmCostWasteService.Delete(idArr, "删除废弃部品"));
        }

        /// <summary>
        /// 导出废弃部品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "废弃部品导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:costwaste:export")]
        public IActionResult Export([FromQuery] QmCostWasteQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmCostWasteService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "废弃部品", "废弃部品");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入废弃部品
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "废弃部品导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:costwaste:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmCostWasteDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmCostWasteDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmCostWasteService.ImportQmCostWaste(list.Adapt<List<QmCostWaste>>()));
        }

        /// <summary>
        /// 废弃部品
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "废弃部品模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmCostWasteImportTpl>() { }, "QmCostWaste_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}