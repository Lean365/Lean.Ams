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
    /// bom成本核算
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 10:37:37)
    /// </summary>
    [Verify]
    [Route("accounting/BomCosting")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class BomCostingController : BaseController
    {
        /// <summary>
        /// bom成本核算接口
        /// </summary>
        private readonly IBomCostingService _BomCostingService;

        public BomCostingController(IBomCostingService BomCostingService)
        {
            _BomCostingService = BomCostingService;
        }

        /// <summary>
        /// 查询bom成本核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:list")]
        public IActionResult QueryBomCosting([FromQuery] BomCostingQueryDto parm)
        {
            var response = _BomCostingService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询bom成本核算详情
        /// </summary>
        /// <param name="BcSFID"></param>
        /// <returns></returns>
        [HttpGet("{BcSFID}")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:query")]
        public IActionResult GetBomCosting(long BcSFID)
        {
            var response = _BomCostingService.GetInfo(BcSFID);
            
            var info = response.Adapt<BomCostingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加bom成本核算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:bomcosting:add")]
        [Log(Title = "bom成本核算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddBomCosting([FromBody] BomCostingDto parm)
        {
            var modal = parm.Adapt<BomCosting>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_BomCostingService.CheckEntryUnique(parm.BcSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)bom成本核算 '{parm.BcSFID}'失败(failed)，输入的(The entered)bom成本核算已存在(already exists)"));
            }
            var response = _BomCostingService.AddBomCosting(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新bom成本核算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:bomcosting:edit")]
        [Log(Title = "bom成本核算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateBomCosting([FromBody] BomCostingDto parm)
        {
            var modal = parm.Adapt<BomCosting>().ToUpdate(HttpContext);
            var response = _BomCostingService.UpdateBomCosting(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除bom成本核算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:delete")]
        [Log(Title = "bom成本核算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteBomCosting([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_BomCostingService.Delete(idArr, "删除bom成本核算"));
        }

        /// <summary>
        /// 导出bom成本核算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "bom成本核算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:export")]
        public IActionResult Export([FromQuery] BomCostingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _BomCostingService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "bom成本核算", "bom成本核算","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入bom成本核算
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "bom成本核算导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:bomcosting:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<BomCostingDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<BomCostingDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_BomCostingService.ImportBomCosting(list.Adapt<List<BomCosting>>()));
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
            var result = DownloadImportTemplate(new List<BomCostingDto>() { }, "BomCostingTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}