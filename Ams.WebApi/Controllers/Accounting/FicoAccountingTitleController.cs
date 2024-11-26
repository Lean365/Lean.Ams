using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 会计科目
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:53:13
    /// </summary>
    [Verify]
    [Route("Accounting/FicoAccountingTitle")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoAccountingTitleController(IFicoAccountingTitleService FicoAccountingTitleService) : BaseController
    {
        /// <summary>
        /// 会计科目接口
        /// </summary>
        private readonly IFicoAccountingTitleService _FicoAccountingTitleService = FicoAccountingTitleService;

        //public FicoAccountingTitleController(IFicoAccountingTitleService FicoAccountingTitleService)
        //{
        //    _FicoAccountingTitleService = FicoAccountingTitleService;
        //}

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
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:query")]
        public IActionResult GetFicoAccountingTitle(long Id)
        {
            var response = _FicoAccountingTitleService.GetInfo(Id);

            var info = response.Adapt<FicoAccountingTitleDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加会计科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:add")]
        [Log(Title = "会计科目", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoAccountingTitle([FromBody] FicoAccountingTitleDto parm)
        {
            // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoAccountingTitleService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增会计科目 '{parm.Id}'失败(Add failed)，输入的会计科目已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoAccountingTitle>().ToCreate(HttpContext);

            var response = _FicoAccountingTitleService.AddFicoAccountingTitle(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新会计科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:edit")]
        [Log(Title = "会计科目", BusinessType = BusinessType.EDIT)]
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
        public IActionResult DeleteFicoAccountingTitle([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoAccountingTitleService.Delete(idArr, "删除会计科目"));
        }

        /// <summary>
        /// 导出会计科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "会计科目导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
        /// 导入会计科目
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "会计科目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:accountingtitle:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoAccountingTitleDto> list = [];
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
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoAccountingTitleImportTpl>() { }, "FicoAccountingTitle_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}