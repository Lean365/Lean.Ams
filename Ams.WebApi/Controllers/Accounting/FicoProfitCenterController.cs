using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;
using Microsoft.AspNetCore.Mvc;
using MiniExcelLibs;

namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 利润中心
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 14:40:21
    /// </summary>
    [Verify]
    [Route("Accounting/FicoProfitCenter")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoProfitCenterController : BaseController
    {
        /// <summary>
        /// 利润中心接口
        /// </summary>
        private readonly IFicoProfitCenterService _FicoProfitCenterService;

        public FicoProfitCenterController(IFicoProfitCenterService FicoProfitCenterService)
        {
            _FicoProfitCenterService = FicoProfitCenterService;
        }

        /// <summary>
        /// 查询利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:profitcenter:list")]
        public IActionResult QueryFicoProfitCenter([FromQuery] FicoProfitCenterQueryDto parm)
        {
            var response = _FicoProfitCenterService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询利润中心详情
        /// </summary>
        /// <param name="FpSfId"></param>
        /// <returns></returns>
        [HttpGet("{FpSfId}")]
        [ActionPermissionFilter(Permission = "fico:profitcenter:query")]
        public IActionResult GetFicoProfitCenter(long FpSfId)
        {
            var response = _FicoProfitCenterService.GetInfo(FpSfId);

            var info = response.Adapt<FicoProfitCenterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加利润中心
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:profitcenter:add")]
        [Log(Title = "利润中心", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoProfitCenter([FromBody] FicoProfitCenterDto parm)
        {
            // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoProfitCenterService.CheckInputUnique(parm.Prctr.ToString(), parm.Kokrs.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增利润中心 '{"利润中心：" + parm.Prctr + ",控制领域：" + parm.Kokrs}'失败(Add failed)，输入的利润中心已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoProfitCenter>().ToCreate(HttpContext);

            var response = _FicoProfitCenterService.AddFicoProfitCenter(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新利润中心
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:profitcenter:edit")]
        [Log(Title = "利润中心", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoProfitCenter([FromBody] FicoProfitCenterDto parm)
        {
            var modal = parm.Adapt<FicoProfitCenter>().ToUpdate(HttpContext);
            var response = _FicoProfitCenterService.UpdateFicoProfitCenter(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除利润中心
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:profitcenter:delete")]
        [Log(Title = "利润中心", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoProfitCenter([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoProfitCenterService.Delete(idArr, "删除利润中心"));
        }

        /// <summary>
        /// 导出利润中心
        /// </summary>
        /// <returns></returns>
        [Log(Title = "利润中心", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:profitcenter:export")]
        public IActionResult Export([FromQuery] FicoProfitCenterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoProfitCenterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "利润中心", "利润中心");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "利润中心导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:profitcenter:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoProfitCenterDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoProfitCenterDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoProfitCenterService.ImportFicoProfitCenter(list.Adapt<List<FicoProfitCenter>>()));
        }

        /// <summary>
        /// 利润中心导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "利润中心模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoProfitCenterImportTpl>() { }, "FicoProfitCenter_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}