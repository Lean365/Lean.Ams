using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 利润中心
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:26:49
    /// </summary>
    [Verify]
    [Route("Accounting/FicoPrctr")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoPrctrController : BaseController
    {
        /// <summary>
        /// 利润中心接口
        /// </summary>
        private readonly IFicoPrctrService _FicoPrctrService;

        public FicoPrctrController(IFicoPrctrService FicoPrctrService)
        {
            _FicoPrctrService = FicoPrctrService;
        }

        /// <summary>
        /// 查询利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:prctr:list")]
        public IActionResult QueryFicoPrctr([FromQuery] FicoPrctrQueryDto parm)
        {
            var response = _FicoPrctrService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询利润中心详情
        /// </summary>
        /// <param name="FpSFID"></param>
        /// <returns></returns>
        [HttpGet("{FpSFID}")]
        [ActionPermissionFilter(Permission = "fico:prctr:query")]
        public IActionResult GetFicoPrctr(long FpSFID)
        {
            var response = _FicoPrctrService.GetInfo(FpSFID);
            
            var info = response.Adapt<FicoPrctrDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加利润中心
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:prctr:add")]
        [Log(Title = "利润中心", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoPrctr([FromBody] FicoPrctrDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoPrctrService.CheckInputUnique(parm.FpSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增利润中心 '{parm.FpSFID}'失败(Add failed)，输入的利润中心已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoPrctr>().ToCreate(HttpContext);

            var response = _FicoPrctrService.AddFicoPrctr(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新利润中心
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:prctr:edit")]
        [Log(Title = "利润中心", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoPrctr([FromBody] FicoPrctrDto parm)
        {
            var modal = parm.Adapt<FicoPrctr>().ToUpdate(HttpContext);
            var response = _FicoPrctrService.UpdateFicoPrctr(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除利润中心
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:prctr:delete")]
        [Log(Title = "利润中心", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoPrctr([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoPrctrService.Delete(idArr, "删除利润中心"));
        }

        /// <summary>
        /// 导出利润中心
        /// </summary>
        /// <returns></returns>
        [Log(Title = "利润中心", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:prctr:export")]
        public IActionResult Export([FromQuery] FicoPrctrQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoPrctrService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "fico:prctr:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoPrctrDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoPrctrDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoPrctrService.ImportFicoPrctr(list.Adapt<List<FicoPrctr>>()));
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
            var result = DownloadImportTemplate(new List<FicoPrctrDto>() { }, "FicoPrctr");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}