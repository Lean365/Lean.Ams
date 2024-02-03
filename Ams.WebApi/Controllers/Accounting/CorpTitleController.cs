using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 公司科目
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:11:12)
    /// </summary>
    [Verify]
    [Route("accounting/CorpTitle")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class CorpTitleController : BaseController
    {
        /// <summary>
        /// 公司科目接口
        /// </summary>
        private readonly ICorpTitleService _CorpTitleService;

        public CorpTitleController(ICorpTitleService CorpTitleService)
        {
            _CorpTitleService = CorpTitleService;
        }

        /// <summary>
        /// 查询公司科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:corptitle:list")]
        public IActionResult QueryCorpTitle([FromQuery] CorpTitleQueryDto parm)
        {
            var response = _CorpTitleService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询公司科目详情
        /// </summary>
        /// <param name="FctSFID"></param>
        /// <returns></returns>
        [HttpGet("{FctSFID}")]
        [ActionPermissionFilter(Permission = "fico:corptitle:query")]
        public IActionResult GetCorpTitle(long FctSFID)
        {
            var response = _CorpTitleService.GetInfo(FctSFID);
            
            var info = response.Adapt<CorpTitleDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加公司科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:corptitle:add")]
        [Log(Title = "公司科目", BusinessType = BusinessType.INSERT)]
        public IActionResult AddCorpTitle([FromBody] CorpTitleDto parm)
        {
            var modal = parm.Adapt<CorpTitle>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_CorpTitleService.CheckEntryUnique(parm.FctSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)公司科目 '{parm.FctSFID}'失败(failed)，输入的(The entered)公司科目已存在(already exists)"));
            }
            var response = _CorpTitleService.AddCorpTitle(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新公司科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:corptitle:edit")]
        [Log(Title = "公司科目", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateCorpTitle([FromBody] CorpTitleDto parm)
        {
            var modal = parm.Adapt<CorpTitle>().ToUpdate(HttpContext);
            var response = _CorpTitleService.UpdateCorpTitle(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除公司科目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:corptitle:delete")]
        [Log(Title = "公司科目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteCorpTitle([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_CorpTitleService.Delete(idArr, "删除公司科目"));
        }

        /// <summary>
        /// 导出公司科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "公司科目", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:corptitle:export")]
        public IActionResult Export([FromQuery] CorpTitleQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _CorpTitleService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "公司科目", "公司科目","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入公司科目
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "公司科目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:corptitle:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<CorpTitleDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<CorpTitleDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_CorpTitleService.ImportCorpTitle(list.Adapt<List<CorpTitle>>()));
        }

        /// <summary>
        /// 公司科目导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "公司科目模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<CorpTitleDto>() { }, "CorpTitleTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}