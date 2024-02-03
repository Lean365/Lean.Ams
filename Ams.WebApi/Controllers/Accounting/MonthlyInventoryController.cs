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
    /// 月度存货
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:20:25)
    /// </summary>
    [Verify]
    [Route("accounting/MonthlyInventory")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class MonthlyInventoryController : BaseController
    {
        /// <summary>
        /// 月度存货接口
        /// </summary>
        private readonly IMonthlyInventoryService _MonthlyInventoryService;

        public MonthlyInventoryController(IMonthlyInventoryService MonthlyInventoryService)
        {
            _MonthlyInventoryService = MonthlyInventoryService;
        }

        /// <summary>
        /// 查询月度存货列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:list")]
        public IActionResult QueryMonthlyInventory([FromQuery] MonthlyInventoryQueryDto parm)
        {
            var response = _MonthlyInventoryService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询月度存货详情
        /// </summary>
        /// <param name="MiSFID"></param>
        /// <returns></returns>
        [HttpGet("{MiSFID}")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:query")]
        public IActionResult GetMonthlyInventory(long MiSFID)
        {
            var response = _MonthlyInventoryService.GetInfo(MiSFID);
            
            var info = response.Adapt<MonthlyInventoryDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加月度存货
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:add")]
        [Log(Title = "月度存货", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMonthlyInventory([FromBody] MonthlyInventoryDto parm)
        {
            var modal = parm.Adapt<MonthlyInventory>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_MonthlyInventoryService.CheckEntryUnique(parm.MiSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)月度存货 '{parm.MiSFID}'失败(failed)，输入的(The entered)月度存货已存在(already exists)"));
            }
            var response = _MonthlyInventoryService.AddMonthlyInventory(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新月度存货
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:edit")]
        [Log(Title = "月度存货", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMonthlyInventory([FromBody] MonthlyInventoryDto parm)
        {
            var modal = parm.Adapt<MonthlyInventory>().ToUpdate(HttpContext);
            var response = _MonthlyInventoryService.UpdateMonthlyInventory(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除月度存货
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:delete")]
        [Log(Title = "月度存货", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMonthlyInventory([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MonthlyInventoryService.Delete(idArr, "删除月度存货"));
        }

        /// <summary>
        /// 导出月度存货
        /// </summary>
        /// <returns></returns>
        [Log(Title = "月度存货", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:export")]
        public IActionResult Export([FromQuery] MonthlyInventoryQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MonthlyInventoryService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "月度存货", "月度存货","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入月度存货
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "月度存货导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MonthlyInventoryDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MonthlyInventoryDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MonthlyInventoryService.ImportMonthlyInventory(list.Adapt<List<MonthlyInventory>>()));
        }

        /// <summary>
        /// 月度存货导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "月度存货模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MonthlyInventoryDto>() { }, "MonthlyInventoryTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}