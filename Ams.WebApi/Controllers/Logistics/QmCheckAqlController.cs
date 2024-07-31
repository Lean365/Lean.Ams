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
    /// @Date: 2024/7/19 8:39:24
    /// </summary>
    [Verify]
    [Route("Logistics/QmCheckAql")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmCheckAqlController : BaseController
    {
        /// <summary>
        /// 抽样标准接口
        /// </summary>
        private readonly IQmCheckAqlService _QmCheckAqlService;

        public QmCheckAqlController(IQmCheckAqlService QmCheckAqlService)
        {
            _QmCheckAqlService = QmCheckAqlService;
        }

        /// <summary>
        /// 查询抽样标准列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:checkaql:list")]
        public IActionResult QueryQmCheckAql([FromQuery] QmCheckAqlQueryDto parm)
        {
            var response = _QmCheckAqlService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询抽样标准详情
        /// </summary>
        /// <param name="QcaSfId"></param>
        /// <returns></returns>
        [HttpGet("{QcaSfId}")]
        [ActionPermissionFilter(Permission = "qm:checkaql:query")]
        public IActionResult GetQmCheckAql(long QcaSfId)
        {
            var response = _QmCheckAqlService.GetInfo(QcaSfId);
            
            var info = response.Adapt<QmCheckAqlDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加抽样标准
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:checkaql:add")]
        [Log(Title = "抽样标准", BusinessType = BusinessType.INSERT)]
        public IActionResult AddQmCheckAql([FromBody] QmCheckAqlDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmCheckAqlService.CheckInputUnique(parm.QcaSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增抽样标准 '{parm.QcaSfId}'失败(Add failed)，输入的抽样标准已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmCheckAql>().ToCreate(HttpContext);

            var response = _QmCheckAqlService.AddQmCheckAql(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新抽样标准
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:checkaql:edit")]
        [Log(Title = "抽样标准", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateQmCheckAql([FromBody] QmCheckAqlDto parm)
        {
            var modal = parm.Adapt<QmCheckAql>().ToUpdate(HttpContext);
            var response = _QmCheckAqlService.UpdateQmCheckAql(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除抽样标准
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:checkaql:delete")]
        [Log(Title = "抽样标准", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmCheckAql([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmCheckAqlService.Delete(idArr, "删除抽样标准"));
        }

        /// <summary>
        /// 导出抽样标准
        /// </summary>
        /// <returns></returns>
        [Log(Title = "抽样标准", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:checkaql:export")]
        public IActionResult Export([FromQuery] QmCheckAqlQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmCheckAqlService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "抽样标准", "抽样标准");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "抽样标准导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:checkaql:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<QmCheckAqlDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmCheckAqlDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmCheckAqlService.ImportQmCheckAql(list.Adapt<List<QmCheckAql>>()));
        }

        /// <summary>
        /// 抽样标准导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "抽样标准模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmCheckAqlImportTpl>() { }, "QmCheckAql_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}