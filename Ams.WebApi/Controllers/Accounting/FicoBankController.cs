using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 银行
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:43:04
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBank")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBankController(IFicoBankService FicoBankService) : BaseController
    {
        /// <summary>
        /// 银行接口
        /// </summary>
        private readonly IFicoBankService _FicoBankService = FicoBankService;

        //public FicoBankController(IFicoBankService FicoBankService)
        //{
        //    _FicoBankService = FicoBankService;
        //}

        /// <summary>
        /// 查询银行列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:bank:list")]
        public IActionResult QueryFicoBank([FromQuery] FicoBankQueryDto parm)
        {
            var response = _FicoBankService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询银行详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:bank:query")]
        public IActionResult GetFicoBank(long Id)
        {
            var response = _FicoBankService.GetInfo(Id);

            var info = response.Adapt<FicoBankDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加银行
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:bank:add")]
        [Log(Title = "银行", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoBank([FromBody] FicoBankDto parm)
        {
            // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBankService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增银行 '{parm.Id}'失败(Add failed)，输入的银行已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBank>().ToCreate(HttpContext);

            var response = _FicoBankService.AddFicoBank(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新银行
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:bank:edit")]
        [Log(Title = "银行", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoBank([FromBody] FicoBankDto parm)
        {
            var modal = parm.Adapt<FicoBank>().ToUpdate(HttpContext);
            var response = _FicoBankService.UpdateFicoBank(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除银行
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:bank:delete")]
        [Log(Title = "银行", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBank([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBankService.Delete(idArr, "删除银行"));
        }

        /// <summary>
        /// 导出银行
        /// </summary>
        /// <returns></returns>
        [Log(Title = "银行导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:bank:export")]
        public IActionResult Export([FromQuery] FicoBankQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBankService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "银行", "银行");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入银行
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "银行导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:bank:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoBankDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBankDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBankService.ImportFicoBank(list.Adapt<List<FicoBank>>()));
        }

        /// <summary>
        /// 银行
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "银行模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBankImportTpl>() { }, "FicoBank_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}