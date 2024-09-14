using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 不合格联络
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:41:22
    /// </summary>
    [Verify]
    [Route("Logistics/QmUnqLetter")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmUnqLetterController : BaseController
    {
        /// <summary>
        /// 不合格联络接口
        /// </summary>
        private readonly IQmUnqLetterService _QmUnqLetterService;

        public QmUnqLetterController(IQmUnqLetterService QmUnqLetterService)
        {
            _QmUnqLetterService = QmUnqLetterService;
        }

        /// <summary>
        /// 查询不合格联络列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:unqletter:list")]
        public IActionResult QueryQmUnqLetter([FromQuery] QmUnqLetterQueryDto parm)
        {
            var response = _QmUnqLetterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询不合格联络详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:unqletter:query")]
        public IActionResult GetQmUnqLetter(long Id)
        {
            var response = _QmUnqLetterService.GetInfo(Id);
            
            var info = response.Adapt<QmUnqLetterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加不合格联络
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:unqletter:add")]
        [Log(Title = "不合格联络", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmUnqLetter([FromBody] QmUnqLetterDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmUnqLetterService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增不合格联络 '{parm.Id}'失败(Add failed)，输入的不合格联络已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmUnqLetter>().ToCreate(HttpContext);

            var response = _QmUnqLetterService.AddQmUnqLetter(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新不合格联络
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:unqletter:edit")]
        [Log(Title = "不合格联络", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmUnqLetter([FromBody] QmUnqLetterDto parm)
        {
            var modal = parm.Adapt<QmUnqLetter>().ToUpdate(HttpContext);
            var response = _QmUnqLetterService.UpdateQmUnqLetter(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除不合格联络
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:unqletter:delete")]
        [Log(Title = "不合格联络", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmUnqLetter([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_QmUnqLetterService.Delete(idArr, "删除不合格联络"));
        }

        /// <summary>
        /// 导出不合格联络
        /// </summary>
        /// <returns></returns>
        [Log(Title = "不合格联络导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:unqletter:export")]
        public IActionResult Export([FromQuery] QmUnqLetterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmUnqLetterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "不合格联络", "不合格联络");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入不合格联络
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "不合格联络导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:unqletter:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmUnqLetterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmUnqLetterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmUnqLetterService.ImportQmUnqLetter(list.Adapt<List<QmUnqLetter>>()));
        }

        /// <summary>
        /// 不合格联络
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "不合格联络模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmUnqLetterImportTpl>() { }, "QmUnqLetter_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}