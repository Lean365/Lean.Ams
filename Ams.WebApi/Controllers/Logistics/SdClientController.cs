using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 客户信息
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:26:41
    /// </summary>
    [Verify]
    [Route("Logistics/SdClient")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class SdClientController : BaseController
    {
        /// <summary>
        /// 客户信息接口
        /// </summary>
        private readonly ISdClientService _SdClientService;

        public SdClientController(ISdClientService SdClientService)
        {
            _SdClientService = SdClientService;
        }

        /// <summary>
        /// 查询客户信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:client:list")]
        public IActionResult QuerySdClient([FromQuery] SdClientQueryDto parm)
        {
            var response = _SdClientService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询客户信息详情
        /// </summary>
        /// <param name="ScSfId"></param>
        /// <returns></returns>
        [HttpGet("{ScSfId}")]
        [ActionPermissionFilter(Permission = "sd:client:query")]
        public IActionResult GetSdClient(long ScSfId)
        {
            var response = _SdClientService.GetInfo(ScSfId);
            
            var info = response.Adapt<SdClientDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加客户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:client:add")]
        [Log(Title = "客户信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSdClient([FromBody] SdClientDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_SdClientService.CheckInputUnique(parm.ScSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增客户信息 '{parm.ScSfId}'失败(Add failed)，输入的客户信息已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<SdClient>().ToCreate(HttpContext);

            var response = _SdClientService.AddSdClient(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:client:edit")]
        [Log(Title = "客户信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSdClient([FromBody] SdClientDto parm)
        {
            var modal = parm.Adapt<SdClient>().ToUpdate(HttpContext);
            var response = _SdClientService.UpdateSdClient(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "sd:client:delete")]
        [Log(Title = "客户信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdClient([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_SdClientService.Delete(idArr, "删除客户信息"));
        }

        /// <summary>
        /// 导出客户信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "客户信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:client:export")]
        public IActionResult Export([FromQuery] SdClientQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SdClientService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "客户信息", "客户信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "客户信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "sd:client:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SdClientDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SdClientDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SdClientService.ImportSdClient(list.Adapt<List<SdClient>>()));
        }

        /// <summary>
        /// 客户信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "客户信息模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SdClientImportTpl>() { }, "SdClient_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}