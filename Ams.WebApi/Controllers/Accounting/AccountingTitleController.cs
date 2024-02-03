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
    /// 会计科目
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    [Verify]
    [Route("accounting/AccountingTitle")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class AccountingTitleController : BaseController
    {
        /// <summary>
        /// 会计科目接口
        /// </summary>
        private readonly IAccountingTitleService _AccountingTitleService;

        public AccountingTitleController(IAccountingTitleService AccountingTitleService)
        {
            _AccountingTitleService = AccountingTitleService;
        }

        /// <summary>
        /// 查询会计科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:list")]
        public IActionResult QueryAccountingTitle([FromQuery] AccountingTitleQueryDto parm)
        {
            var response = _AccountingTitleService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询会计科目详情
        /// </summary>
        /// <param name="FatSFID"></param>
        /// <returns></returns>
        [HttpGet("{FatSFID}")]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:query")]
        public IActionResult GetAccountingTitle(long FatSFID)
        {
            var response = _AccountingTitleService.GetInfo(FatSFID);
            
            var info = response.Adapt<AccountingTitleDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加会计科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:add")]
        [Log(Title = "会计科目", BusinessType = BusinessType.INSERT)]
        public IActionResult AddAccountingTitle([FromBody] AccountingTitleDto parm)
        {
            var modal = parm.Adapt<AccountingTitle>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_AccountingTitleService.CheckEntryUnique(parm.FatSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)会计科目 '{parm.FatSFID}'失败(failed)，输入的(The entered)会计科目已存在(already exists)"));
            }
            var response = _AccountingTitleService.AddAccountingTitle(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新会计科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:edit")]
        [Log(Title = "会计科目", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateAccountingTitle([FromBody] AccountingTitleDto parm)
        {
            var modal = parm.Adapt<AccountingTitle>().ToUpdate(HttpContext);
            var response = _AccountingTitleService.UpdateAccountingTitle(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除会计科目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:delete")]
        [Log(Title = "会计科目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteAccountingTitle([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_AccountingTitleService.Delete(idArr, "删除会计科目"));
        }

        /// <summary>
        /// 导出会计科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "会计科目", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:export")]
        public IActionResult Export([FromQuery] AccountingTitleQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _AccountingTitleService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "会计科目", "会计科目","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入会计科目
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "会计科目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<AccountingTitleDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<AccountingTitleDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_AccountingTitleService.ImportAccountingTitle(list.Adapt<List<AccountingTitle>>()));
        }

        /// <summary>
        /// 会计科目导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "会计科目模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<AccountingTitleDto>() { }, "AccountingTitleTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}