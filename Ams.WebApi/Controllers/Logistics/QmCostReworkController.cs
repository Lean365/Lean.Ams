using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 返工改修
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:47:36
    /// </summary>
    [Verify]
    [Route("Logistics/QmCostRework")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmCostReworkController : BaseController
    {
        /// <summary>
        /// 返工改修接口
        /// </summary>
        private readonly IQmCostReworkService _QmCostReworkService;

        public QmCostReworkController(IQmCostReworkService QmCostReworkService)
        {
            _QmCostReworkService = QmCostReworkService;
        }

        /// <summary>
        /// 查询返工改修列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:costrework:list")]
        public IActionResult QueryQmCostRework([FromQuery] QmCostReworkQueryDto parm)
        {
            var response = _QmCostReworkService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询返工改修详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:costrework:query")]
        public IActionResult GetQmCostRework(int Id)
        {
            var response = _QmCostReworkService.GetInfo(Id);
            
            var info = response.Adapt<QmCostReworkDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加返工改修
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:costrework:add")]
        [Log(Title = "返工改修", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmCostRework([FromBody] QmCostReworkDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmCostReworkService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增返工改修 '{parm.Id}'失败(Add failed)，输入的返工改修已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmCostRework>().ToCreate(HttpContext);

            var response = _QmCostReworkService.AddQmCostRework(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新返工改修
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:costrework:edit")]
        [Log(Title = "返工改修", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmCostRework([FromBody] QmCostReworkDto parm)
        {
            var modal = parm.Adapt<QmCostRework>().ToUpdate(HttpContext);
            var response = _QmCostReworkService.UpdateQmCostRework(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除返工改修
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:costrework:delete")]
        [Log(Title = "返工改修", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmCostRework([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_QmCostReworkService.Delete(idArr, "删除返工改修"));
        }

        /// <summary>
        /// 导出返工改修
        /// </summary>
        /// <returns></returns>
        [Log(Title = "返工改修导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:costrework:export")]
        public IActionResult Export([FromQuery] QmCostReworkQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmCostReworkService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "返工改修", "返工改修");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入返工改修
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "返工改修导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:costrework:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmCostReworkDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmCostReworkDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmCostReworkService.ImportQmCostRework(list.Adapt<List<QmCostRework>>()));
        }

        /// <summary>
        /// 返工改修
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "返工改修模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmCostReworkImportTpl>() { }, "QmCostRework_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}