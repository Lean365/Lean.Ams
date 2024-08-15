using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 明细科目
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 17:37:35
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBudgetAccountingSlv")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBudgetAccountingSlvController : BaseController
    {
        /// <summary>
        /// 明细科目接口
        /// </summary>
        private readonly IFicoBudgetAccountingSlvService _FicoBudgetAccountingSlvService;

        public FicoBudgetAccountingSlvController(IFicoBudgetAccountingSlvService FicoBudgetAccountingSlvService)
        {
            _FicoBudgetAccountingSlvService = FicoBudgetAccountingSlvService;
        }

        /// <summary>
        /// 查询明细科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingslv:list")]
        public IActionResult QueryFicoBudgetAccountingSlv([FromQuery] FicoBudgetAccountingSlvQueryDto parm)
        {
            var response = _FicoBudgetAccountingSlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询明细科目详情
        /// </summary>
        /// <param name="FbasSfId"></param>
        /// <returns></returns>
        [HttpGet("{FbasSfId}")]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingslv:query")]
        public IActionResult GetFicoBudgetAccountingSlv(long FbasSfId)
        {
            var response = _FicoBudgetAccountingSlvService.GetInfo(FbasSfId);
            
            var info = response.Adapt<FicoBudgetAccountingSlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加明细科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingslv:add")]
        [Log(Title = "明细科目", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetAccountingSlv([FromBody] FicoBudgetAccountingSlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetAccountingSlvService.CheckInputUnique(parm.FbasSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增明细科目 '{parm.FbasSfId}'失败(Add failed)，输入的明细科目已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBudgetAccountingSlv>().ToCreate(HttpContext);

            var response = _FicoBudgetAccountingSlvService.AddFicoBudgetAccountingSlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新明细科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingslv:edit")]
        [Log(Title = "明细科目", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetAccountingSlv([FromBody] FicoBudgetAccountingSlvDto parm)
        {
            var modal = parm.Adapt<FicoBudgetAccountingSlv>().ToUpdate(HttpContext);
            var response = _FicoBudgetAccountingSlvService.UpdateFicoBudgetAccountingSlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除明细科目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingslv:delete")]
        [Log(Title = "明细科目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetAccountingSlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBudgetAccountingSlvService.Delete(idArr, "删除明细科目"));
        }

        /// <summary>
        /// 导出明细科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "明细科目", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingslv:export")]
        public IActionResult Export([FromQuery] FicoBudgetAccountingSlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBudgetAccountingSlvService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "明细科目", "明细科目");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "明细科目导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:budgetaccountingslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBudgetAccountingSlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBudgetAccountingSlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBudgetAccountingSlvService.ImportFicoBudgetAccountingSlv(list.Adapt<List<FicoBudgetAccountingSlv>>()));
        }

        /// <summary>
        /// 明细科目导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "明细科目模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBudgetAccountingSlvImportTpl>() { }, "FicoBudgetAccountingSlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}