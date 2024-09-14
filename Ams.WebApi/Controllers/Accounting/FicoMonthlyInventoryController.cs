using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 月度存货
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:55:10
    /// </summary>
    [Verify]
    [Route("Accounting/FicoMonthlyInventory")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoMonthlyInventoryController : BaseController
    {
        /// <summary>
        /// 月度存货接口
        /// </summary>
        private readonly IFicoMonthlyInventoryService _FicoMonthlyInventoryService;

        public FicoMonthlyInventoryController(IFicoMonthlyInventoryService FicoMonthlyInventoryService)
        {
            _FicoMonthlyInventoryService = FicoMonthlyInventoryService;
        }

        /// <summary>
        /// 查询月度存货列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:list")]
        public IActionResult QueryFicoMonthlyInventory([FromQuery] FicoMonthlyInventoryQueryDto parm)
        {
            var response = _FicoMonthlyInventoryService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询月度存货详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:query")]
        public IActionResult GetFicoMonthlyInventory(long Id)
        {
            var response = _FicoMonthlyInventoryService.GetInfo(Id);
            
            var info = response.Adapt<FicoMonthlyInventoryDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加月度存货
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:add")]
        [Log(Title = "月度存货", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoMonthlyInventory([FromBody] FicoMonthlyInventoryDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoMonthlyInventoryService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增月度存货 '{parm.Id}'失败(Add failed)，输入的月度存货已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoMonthlyInventory>().ToCreate(HttpContext);

            var response = _FicoMonthlyInventoryService.AddFicoMonthlyInventory(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新月度存货
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:edit")]
        [Log(Title = "月度存货", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoMonthlyInventory([FromBody] FicoMonthlyInventoryDto parm)
        {
            var modal = parm.Adapt<FicoMonthlyInventory>().ToUpdate(HttpContext);
            var response = _FicoMonthlyInventoryService.UpdateFicoMonthlyInventory(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除月度存货
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:delete")]
        [Log(Title = "月度存货", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoMonthlyInventory([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoMonthlyInventoryService.Delete(idArr, "删除月度存货"));
        }

        /// <summary>
        /// 导出月度存货
        /// </summary>
        /// <returns></returns>
        [Log(Title = "月度存货导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:monthlyinventory:export")]
        public IActionResult Export([FromQuery] FicoMonthlyInventoryQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoMonthlyInventoryService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "月度存货", "月度存货");
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
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoMonthlyInventoryDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoMonthlyInventoryDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoMonthlyInventoryService.ImportFicoMonthlyInventory(list.Adapt<List<FicoMonthlyInventory>>()));
        }

        /// <summary>
        /// 月度存货
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "月度存货模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoMonthlyInventoryImportTpl>() { }, "FicoMonthlyInventory_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}