using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 抽样标准
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:39:16
    /// </summary>
    [Verify]
    [Route("Logistics/QmInspAql")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmInspAqlController : BaseController
    {
        /// <summary>
        /// 抽样标准接口
        /// </summary>
        private readonly IQmInspAqlService _QmInspAqlService;

        public QmInspAqlController(IQmInspAqlService QmInspAqlService)
        {
            _QmInspAqlService = QmInspAqlService;
        }

        /// <summary>
        /// 查询抽样标准列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:inspaql:list")]
        public IActionResult QueryQmInspAql([FromQuery] QmInspAqlQueryDto parm)
        {
            var response = _QmInspAqlService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询抽样标准详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:inspaql:query")]
        public IActionResult GetQmInspAql(long Id)
        {
            var response = _QmInspAqlService.GetInfo(Id);
            
            var info = response.Adapt<QmInspAqlDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加抽样标准
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:inspaql:add")]
        [Log(Title = "抽样标准", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmInspAql([FromBody] QmInspAqlDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmInspAqlService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增抽样标准 '{parm.Id}'失败(Add failed)，输入的抽样标准已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmInspAql>().ToCreate(HttpContext);

            var response = _QmInspAqlService.AddQmInspAql(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新抽样标准
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:inspaql:edit")]
        [Log(Title = "抽样标准", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmInspAql([FromBody] QmInspAqlDto parm)
        {
            var modal = parm.Adapt<QmInspAql>().ToUpdate(HttpContext);
            var response = _QmInspAqlService.UpdateQmInspAql(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除抽样标准
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:inspaql:delete")]
        [Log(Title = "抽样标准", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmInspAql([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmInspAqlService.Delete(idArr, "删除抽样标准"));
        }

        /// <summary>
        /// 导出抽样标准
        /// </summary>
        /// <returns></returns>
        [Log(Title = "抽样标准导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:inspaql:export")]
        public IActionResult Export([FromQuery] QmInspAqlQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmInspAqlService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "抽样标准", "抽样标准");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入抽样标准
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "抽样标准导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:inspaql:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmInspAqlDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmInspAqlDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmInspAqlService.ImportQmInspAql(list.Adapt<List<QmInspAql>>()));
        }

        /// <summary>
        /// 抽样标准
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "抽样标准模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmInspAqlImportTpl>() { }, "QmInspAql_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}