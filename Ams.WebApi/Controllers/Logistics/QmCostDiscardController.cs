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
    /// @Date: 2024/9/18 8:30:51
    /// </summary>
    [Verify]
    [Route("Logistics/QmCostDiscard")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmCostDiscardController : BaseController
    {
        /// <summary>
        /// 废弃部品接口
        /// </summary>
        private readonly IQmCostDiscardService _QmCostDiscardService;

        public QmCostDiscardController(IQmCostDiscardService QmCostDiscardService)
        {
            _QmCostDiscardService = QmCostDiscardService;
        }

        /// <summary>
        /// 查询废弃部品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:costdiscard:list")]
        public IActionResult QueryQmCostDiscard([FromQuery] QmCostDiscardQueryDto parm)
        {
            var response = _QmCostDiscardService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询废弃部品详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:costdiscard:query")]
        public IActionResult GetQmCostDiscard(long Id)
        {
            var response = _QmCostDiscardService.GetInfo(Id);
            
            var info = response.Adapt<QmCostDiscardDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加废弃部品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:costdiscard:add")]
        [Log(Title = "废弃部品", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmCostDiscard([FromBody] QmCostDiscardDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmCostDiscardService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增废弃部品 '{parm.Id}'失败(Add failed)，输入的废弃部品已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmCostDiscard>().ToCreate(HttpContext);

            var response = _QmCostDiscardService.AddQmCostDiscard(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新废弃部品
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:costdiscard:edit")]
        [Log(Title = "废弃部品", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmCostDiscard([FromBody] QmCostDiscardDto parm)
        {
            var modal = parm.Adapt<QmCostDiscard>().ToUpdate(HttpContext);
            var response = _QmCostDiscardService.UpdateQmCostDiscard(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除废弃部品
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:costdiscard:delete")]
        [Log(Title = "废弃部品", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmCostDiscard([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmCostDiscardService.Delete(idArr, "删除废弃部品"));
        }

        /// <summary>
        /// 导出废弃部品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "废弃部品导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:costdiscard:export")]
        public IActionResult Export([FromQuery] QmCostDiscardQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmCostDiscardService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "qm:costdiscard:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmCostDiscardDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmCostDiscardDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmCostDiscardService.ImportQmCostDiscard(list.Adapt<List<QmCostDiscard>>()));
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
            var result = DownloadImportTemplate(new List<QmCostDiscardImportTpl>() { }, "QmCostDiscard_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}