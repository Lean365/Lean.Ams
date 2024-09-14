using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 品质业务
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:48:39
    /// </summary>
    [Verify]
    [Route("Logistics/QmCostOperation")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmCostOperationController : BaseController
    {
        /// <summary>
        /// 品质业务接口
        /// </summary>
        private readonly IQmCostOperationService _QmCostOperationService;

        public QmCostOperationController(IQmCostOperationService QmCostOperationService)
        {
            _QmCostOperationService = QmCostOperationService;
        }

        /// <summary>
        /// 查询品质业务列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:costoperation:list")]
        public IActionResult QueryQmCostOperation([FromQuery] QmCostOperationQueryDto parm)
        {
            var response = _QmCostOperationService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询品质业务详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:costoperation:query")]
        public IActionResult GetQmCostOperation(long Id)
        {
            var response = _QmCostOperationService.GetInfo(Id);
            
            var info = response.Adapt<QmCostOperationDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加品质业务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:costoperation:add")]
        [Log(Title = "品质业务", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmCostOperation([FromBody] QmCostOperationDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmCostOperationService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增品质业务 '{parm.Id}'失败(Add failed)，输入的品质业务已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmCostOperation>().ToCreate(HttpContext);

            var response = _QmCostOperationService.AddQmCostOperation(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新品质业务
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:costoperation:edit")]
        [Log(Title = "品质业务", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmCostOperation([FromBody] QmCostOperationDto parm)
        {
            var modal = parm.Adapt<QmCostOperation>().ToUpdate(HttpContext);
            var response = _QmCostOperationService.UpdateQmCostOperation(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除品质业务
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:costoperation:delete")]
        [Log(Title = "品质业务", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmCostOperation([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmCostOperationService.Delete(idArr, "删除品质业务"));
        }

        /// <summary>
        /// 导出品质业务
        /// </summary>
        /// <returns></returns>
        [Log(Title = "品质业务导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:costoperation:export")]
        public IActionResult Export([FromQuery] QmCostOperationQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmCostOperationService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "品质业务", "品质业务");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入品质业务
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "品质业务导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:costoperation:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmCostOperationDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmCostOperationDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmCostOperationService.ImportQmCostOperation(list.Adapt<List<QmCostOperation>>()));
        }

        /// <summary>
        /// 品质业务
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "品质业务模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmCostOperationImportTpl>() { }, "QmCostOperation_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}