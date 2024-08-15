using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 顾客信息
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 13:49:23
    /// </summary>
    [Verify]
    [Route("Logistics/SdCustomer")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class SdCustomerController : BaseController
    {
        /// <summary>
        /// 顾客信息接口
        /// </summary>
        private readonly ISdCustomerService _SdCustomerService;

        public SdCustomerController(ISdCustomerService SdCustomerService)
        {
            _SdCustomerService = SdCustomerService;
        }

        /// <summary>
        /// 查询顾客信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:customer:list")]
        public IActionResult QuerySdCustomer([FromQuery] SdCustomerQueryDto parm)
        {
            var response = _SdCustomerService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询顾客信息详情
        /// </summary>
        /// <param name="ScSfId"></param>
        /// <returns></returns>
        [HttpGet("{ScSfId}")]
        [ActionPermissionFilter(Permission = "sd:customer:query")]
        public IActionResult GetSdCustomer(long ScSfId)
        {
            var response = _SdCustomerService.GetInfo(ScSfId);
            
            var info = response.Adapt<SdCustomerDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加顾客信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:customer:add")]
        [Log(Title = "顾客信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSdCustomer([FromBody] SdCustomerDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_SdCustomerService.CheckInputUnique(parm.ScSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增顾客信息 '{parm.ScSfId}'失败(Add failed)，输入的顾客信息已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<SdCustomer>().ToCreate(HttpContext);

            var response = _SdCustomerService.AddSdCustomer(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新顾客信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:customer:edit")]
        [Log(Title = "顾客信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSdCustomer([FromBody] SdCustomerDto parm)
        {
            var modal = parm.Adapt<SdCustomer>().ToUpdate(HttpContext);
            var response = _SdCustomerService.UpdateSdCustomer(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除顾客信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "sd:customer:delete")]
        [Log(Title = "顾客信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdCustomer([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_SdCustomerService.Delete(idArr, "删除顾客信息"));
        }

        /// <summary>
        /// 导出顾客信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "顾客信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:customer:export")]
        public IActionResult Export([FromQuery] SdCustomerQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SdCustomerService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "顾客信息", "顾客信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "顾客信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "sd:customer:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SdCustomerDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SdCustomerDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SdCustomerService.ImportSdCustomer(list.Adapt<List<SdCustomer>>()));
        }

        /// <summary>
        /// 顾客信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "顾客信息模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SdCustomerImportTpl>() { }, "SdCustomer_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}