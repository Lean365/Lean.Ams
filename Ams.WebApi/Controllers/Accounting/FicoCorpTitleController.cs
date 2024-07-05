using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 公司科目
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/5 11:10:04
    /// </summary>
    [Verify]
    [Route("Accounting/FicoCorpTitle")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoCorpTitleController : BaseController
    {
        /// <summary>
        /// 公司科目接口
        /// </summary>
        private readonly IFicoCorpTitleService _FicoCorpTitleService;

        public FicoCorpTitleController(IFicoCorpTitleService FicoCorpTitleService)
        {
            _FicoCorpTitleService = FicoCorpTitleService;
        }

        /// <summary>
        /// 查询公司科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:corptitle:list")]
        public IActionResult QueryFicoCorpTitle([FromQuery] FicoCorpTitleQueryDto parm)
        {
            var response = _FicoCorpTitleService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询公司科目详情
        /// </summary>
        /// <param name="FctSFID"></param>
        /// <returns></returns>
        [HttpGet("{FctSFID}")]
        [ActionPermissionFilter(Permission = "fico:corptitle:query")]
        public IActionResult GetFicoCorpTitle(long FctSFID)
        {
            var response = _FicoCorpTitleService.GetInfo(FctSFID);
            
            var info = response.Adapt<FicoCorpTitleDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加公司科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:corptitle:add")]
        [Log(Title = "公司科目", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoCorpTitle([FromBody] FicoCorpTitleDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoCorpTitleService.CheckInputUnique(parm.FctSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增公司科目 '{parm.FctSFID}'失败(Add failed)，输入的公司科目已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoCorpTitle>().ToCreate(HttpContext);

            var response = _FicoCorpTitleService.AddFicoCorpTitle(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新公司科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:corptitle:edit")]
        [Log(Title = "公司科目", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoCorpTitle([FromBody] FicoCorpTitleDto parm)
        {
            var modal = parm.Adapt<FicoCorpTitle>().ToUpdate(HttpContext);
            var response = _FicoCorpTitleService.UpdateFicoCorpTitle(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除公司科目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:corptitle:delete")]
        [Log(Title = "公司科目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoCorpTitle([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoCorpTitleService.Delete(idArr, "删除公司科目"));
        }

        /// <summary>
        /// 导出公司科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "公司科目", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:corptitle:export")]
        public IActionResult Export([FromQuery] FicoCorpTitleQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoCorpTitleService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "公司科目", "公司科目");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "公司科目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:corptitle:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoCorpTitleDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoCorpTitleDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoCorpTitleService.ImportFicoCorpTitle(list.Adapt<List<FicoCorpTitle>>()));
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
            var result = DownloadImportTemplate(new List<FicoCorpTitleDto>() { }, "FicoCorpTitle");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}