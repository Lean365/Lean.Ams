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
    /// @Date: (2023/12/26 7:53:53)
    /// </summary>
    [Verify]
    [Route("accounting/FicoAccountingTitle")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoAccountingTitleController : BaseController
    {
        /// <summary>
        /// 会计科目接口
        /// </summary>
        private readonly IFicoAccountingTitleService _FicoAccountingTitleService;

        public FicoAccountingTitleController(IFicoAccountingTitleService FicoAccountingTitleService)
        {
            _FicoAccountingTitleService = FicoAccountingTitleService;
        }

        /// <summary>
        /// 查询会计科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:list")]
        public IActionResult QueryFicoAccountingTitle([FromQuery] FicoAccountingTitleQueryDto parm)
        {
            var response = _FicoAccountingTitleService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询会计科目详情
        /// </summary>
        /// <param name="FtSFID"></param>
        /// <returns></returns>
        [HttpGet("{FtSFID}")]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:query")]
        public IActionResult GetFicoAccountingTitle(long FtSFID)
        {
            var response = _FicoAccountingTitleService.GetInfo(FtSFID);
            
            var info = response.Adapt<FicoAccountingTitleDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加会计科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:add")]
        [Log(Title = "会计科目", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoAccountingTitle([FromBody] FicoAccountingTitleDto parm)
        {
            var modal = parm.Adapt<FicoAccountingTitle>().ToCreate(HttpContext);
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoAccountingTitleService.CheckEntryUnique(parm.FtSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)会计科目 '{parm.FtSFID}'失败(failed)，输入的(The entered)会计科目已存在(already exists)"));
            }
            var response = _FicoAccountingTitleService.AddFicoAccountingTitle(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新会计科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:edit")]
        [Log(Title = "会计科目", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoAccountingTitle([FromBody] FicoAccountingTitleDto parm)
        {
            var modal = parm.Adapt<FicoAccountingTitle>().ToUpdate(HttpContext);
            var response = _FicoAccountingTitleService.UpdateFicoAccountingTitle(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除会计科目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:delete")]
        [Log(Title = "会计科目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoAccountingTitle([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoAccountingTitleService.Delete(idArr, "删除会计科目"));
        }

        /// <summary>
        /// 导出
        /// 会计科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "会计科目", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:export")]
        public IActionResult Export([FromQuery] FicoAccountingTitleQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoAccountingTitleService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "会计科目", "会计科目");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 依模板导入
        /// 会计科目
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "会计科目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoAccountingTitleDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoAccountingTitleDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoAccountingTitleService.ImportFicoAccountingTitle(list.Adapt<List<FicoAccountingTitle>>()));
        }

        /// <summary>
        /// 会计科目
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "会计科目模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoAccountingTitleDto>() { }, "FicoAccountingTitle");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}