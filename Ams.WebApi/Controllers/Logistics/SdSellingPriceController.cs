using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 销售价格
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 10:59:46
    /// </summary>
    [Verify]
    [Route("Logistics/SdSellingPrice")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class SdSellingPriceController : BaseController
    {
        /// <summary>
        /// 销售价格接口
        /// </summary>
        private readonly ISdSellingPriceService _SdSellingPriceService;

        public SdSellingPriceController(ISdSellingPriceService SdSellingPriceService)
        {
            _SdSellingPriceService = SdSellingPriceService;
        }

        /// <summary>
        /// 查询销售价格列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:sellingprice:list")]
        public IActionResult QuerySdSellingPrice([FromQuery] SdSellingPriceQueryDto parm)
        {
            var response = _SdSellingPriceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询销售价格详情
        /// </summary>
        /// <param name="SspSfId"></param>
        /// <returns></returns>
        [HttpGet("{SspSfId}")]
        [ActionPermissionFilter(Permission = "sd:sellingprice:query")]
        public IActionResult GetSdSellingPrice(long SspSfId)
        {
            var response = _SdSellingPriceService.GetInfo(SspSfId);
            
            var info = response.Adapt<SdSellingPriceDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加销售价格
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:sellingprice:add")]
        [Log(Title = "销售价格", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSdSellingPrice([FromBody] SdSellingPriceDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_SdSellingPriceService.CheckInputUnique(parm.SspSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增销售价格 '{parm.SspSfId}'失败(Add failed)，输入的销售价格已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<SdSellingPrice>().ToCreate(HttpContext);

            var response = _SdSellingPriceService.AddSdSellingPrice(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新销售价格
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:sellingprice:edit")]
        [Log(Title = "销售价格", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSdSellingPrice([FromBody] SdSellingPriceDto parm)
        {
            var modal = parm.Adapt<SdSellingPrice>().ToUpdate(HttpContext);
            var response = _SdSellingPriceService.UpdateSdSellingPrice(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除销售价格
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "sd:sellingprice:delete")]
        [Log(Title = "销售价格", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdSellingPrice([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_SdSellingPriceService.Delete(idArr, "删除销售价格"));
        }

        /// <summary>
        /// 导出销售价格
        /// </summary>
        /// <returns></returns>
        [Log(Title = "销售价格", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:sellingprice:export")]
        public IActionResult Export([FromQuery] SdSellingPriceQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SdSellingPriceService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "销售价格", "销售价格");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "销售价格导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "sd:sellingprice:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SdSellingPriceDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SdSellingPriceDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SdSellingPriceService.ImportSdSellingPrice(list.Adapt<List<SdSellingPrice>>()));
        }

        /// <summary>
        /// 销售价格导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "销售价格模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SdSellingPriceImportTpl>() { }, "SdSellingPrice_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}