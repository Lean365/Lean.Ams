using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// bom成本核算
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:12
    /// </summary>
    [Verify]
    [Route("Accounting/FicoBomCosting")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoBomCostingController : BaseController
    {
        /// <summary>
        /// bom成本核算接口
        /// </summary>
        private readonly IFicoBomCostingService _FicoBomCostingService;

        public FicoBomCostingController(IFicoBomCostingService FicoBomCostingService)
        {
            _FicoBomCostingService = FicoBomCostingService;
        }

        /// <summary>
        /// 查询bom成本核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:list")]
        public IActionResult QueryFicoBomCosting([FromQuery] FicoBomCostingQueryDto parm)
        {
            var response = _FicoBomCostingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询bom成本核算详情
        /// </summary>
        /// <param name="BcSFID"></param>
        /// <returns></returns>
        [HttpGet("{BcSFID}")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:query")]
        public IActionResult GetFicoBomCosting(long BcSFID)
        {
            var response = _FicoBomCostingService.GetInfo(BcSFID);
            
            var info = response.Adapt<FicoBomCostingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加bom成本核算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:bomcosting:add")]
        [Log(Title = "bom成本核算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBomCosting([FromBody] FicoBomCostingDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoBomCostingService.CheckInputUnique(parm.BcSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增bom成本核算 '{parm.BcSFID}'失败(Add failed)，输入的bom成本核算已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoBomCosting>().ToCreate(HttpContext);

            var response = _FicoBomCostingService.AddFicoBomCosting(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新bom成本核算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:bomcosting:edit")]
        [Log(Title = "bom成本核算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBomCosting([FromBody] FicoBomCostingDto parm)
        {
            var modal = parm.Adapt<FicoBomCosting>().ToUpdate(HttpContext);
            var response = _FicoBomCostingService.UpdateFicoBomCosting(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除bom成本核算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:delete")]
        [Log(Title = "bom成本核算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBomCosting([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoBomCostingService.Delete(idArr, "删除bom成本核算"));
        }

        /// <summary>
        /// 导出bom成本核算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "bom成本核算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:export")]
        public IActionResult Export([FromQuery] FicoBomCostingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoBomCostingService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "bom成本核算", "bom成本核算");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "bom成本核算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:bomcosting:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoBomCostingDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoBomCostingDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoBomCostingService.ImportFicoBomCosting(list.Adapt<List<FicoBomCosting>>()));
        }

        /// <summary>
        /// bom成本核算导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "bom成本核算模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoBomCostingImportTpl>() { }, "FicoBomCosting_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}