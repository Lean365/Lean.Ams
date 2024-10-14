using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 公司科目
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:35:01
    /// </summary>
    [Verify]
    [Route("Accounting/FicoAccountingCorp")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoAccountingCorpController : BaseController
    {
        /// <summary>
        /// 公司科目接口
        /// </summary>
        private readonly IFicoAccountingCorpService _FicoAccountingCorpService;

        public FicoAccountingCorpController(IFicoAccountingCorpService FicoAccountingCorpService)
        {
            _FicoAccountingCorpService = FicoAccountingCorpService;
        }

        /// <summary>
        /// 查询公司科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:accountingcorp:list")]
        public IActionResult QueryFicoAccountingCorp([FromQuery] FicoAccountingCorpQueryDto parm)
        {
            var response = _FicoAccountingCorpService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询公司科目详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:accountingcorp:query")]
        public IActionResult GetFicoAccountingCorp(long Id)
        {
            var response = _FicoAccountingCorpService.GetInfo(Id);

            var info = response.Adapt<FicoAccountingCorpDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加公司科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:accountingcorp:add")]
        [Log(Title = "公司科目", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoAccountingCorp([FromBody] FicoAccountingCorpDto parm)
        {
            // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoAccountingCorpService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增公司科目 '{parm.Id}'失败(Add failed)，输入的公司科目已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoAccountingCorp>().ToCreate(HttpContext);

            var response = _FicoAccountingCorpService.AddFicoAccountingCorp(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新公司科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:accountingcorp:edit")]
        [Log(Title = "公司科目", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoAccountingCorp([FromBody] FicoAccountingCorpDto parm)
        {
            var modal = parm.Adapt<FicoAccountingCorp>().ToUpdate(HttpContext);
            var response = _FicoAccountingCorpService.UpdateFicoAccountingCorp(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除公司科目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:accountingcorp:delete")]
        [Log(Title = "公司科目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoAccountingCorp([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoAccountingCorpService.Delete(idArr, "删除公司科目"));
        }

        /// <summary>
        /// 导出公司科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "公司科目导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:accountingcorp:export")]
        public IActionResult Export([FromQuery] FicoAccountingCorpQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoAccountingCorpService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "公司科目", "公司科目");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入公司科目
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "公司科目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:accountingcorp:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoAccountingCorpDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoAccountingCorpDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoAccountingCorpService.ImportFicoAccountingCorp(list.Adapt<List<FicoAccountingCorp>>()));
        }

        /// <summary>
        /// 公司科目
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "公司科目模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoAccountingCorpImportTpl>() { }, "FicoAccountingCorp_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}