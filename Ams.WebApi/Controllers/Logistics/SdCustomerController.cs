using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 顾客
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/26 15:20:13
    /// </summary>
    [Verify]
    [Route("Logistics/SdCustomer")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class SdCustomerController(ISdCustomerService SdCustomerService) : BaseController
    {
        /// <summary>
        /// 顾客接口
        /// </summary>
        private readonly ISdCustomerService _SdCustomerService = SdCustomerService;

        //public SdCustomerController(ISdCustomerService SdCustomerService)
        //{
        //    _SdCustomerService = SdCustomerService;
        //}

        /// <summary>
        /// 查询顾客列表
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
        /// 查询顾客详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "sd:customer:query")]
        public IActionResult GetSdCustomer(long Id)
        {
            var response = _SdCustomerService.GetInfo(Id);
            
            var info = response.Adapt<SdCustomerDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加顾客
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:customer:add")]
        [Log(Title = "顾客", BusinessType = BusinessType.ADD)]
        public IActionResult AddSdCustomer([FromBody] SdCustomerDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_SdCustomerService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增顾客 '{parm.Id}'失败(Add failed)，输入的顾客已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<SdCustomer>().ToCreate(HttpContext);

            var response = _SdCustomerService.AddSdCustomer(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新顾客
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:customer:edit")]
        [Log(Title = "顾客", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateSdCustomer([FromBody] SdCustomerDto parm)
        {
            var modal = parm.Adapt<SdCustomer>().ToUpdate(HttpContext);
            var response = _SdCustomerService.UpdateSdCustomer(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除顾客
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "sd:customer:delete")]
        [Log(Title = "顾客", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdCustomer([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_SdCustomerService.Delete(idArr, "删除顾客"));
        }

        /// <summary>
        /// 导出顾客
        /// </summary>
        /// <returns></returns>
        [Log(Title = "顾客导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
            var result = ExportExcelMini(list, "顾客", "顾客");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入顾客
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "顾客导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "sd:customer:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            //List<SdCustomerDto> list = new();
            List<SdCustomerDto> list = [];
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SdCustomerDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SdCustomerService.ImportSdCustomer(list.Adapt<List<SdCustomer>>()));
        }

        /// <summary>
        /// 顾客
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "顾客模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SdCustomerImportTpl>() { }, "SdCustomer_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}