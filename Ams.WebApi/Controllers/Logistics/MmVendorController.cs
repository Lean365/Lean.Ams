using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 销售商
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:56
    /// </summary>
    [Verify]
    [Route("Logistics/MmVendor")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MmVendorController : BaseController
    {
        /// <summary>
        /// 销售商接口
        /// </summary>
        private readonly IMmVendorService _MmVendorService;

        public MmVendorController(IMmVendorService MmVendorService)
        {
            _MmVendorService = MmVendorService;
        }

        /// <summary>
        /// 查询销售商列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:vendor:list")]
        public IActionResult QueryMmVendor([FromQuery] MmVendorQueryDto parm)
        {
            var response = _MmVendorService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询销售商详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "mm:vendor:query")]
        public IActionResult GetMmVendor(long Id)
        {
            var response = _MmVendorService.GetInfo(Id);
            
            var info = response.Adapt<MmVendorDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加销售商
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:vendor:add")]
        [Log(Title = "销售商", BusinessType = BusinessType.ADD)]
        public IActionResult AddMmVendor([FromBody] MmVendorDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmVendorService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增销售商 '{parm.Id}'失败(Add failed)，输入的销售商已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<MmVendor>().ToCreate(HttpContext);

            var response = _MmVendorService.AddMmVendor(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新销售商
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:vendor:edit")]
        [Log(Title = "销售商", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateMmVendor([FromBody] MmVendorDto parm)
        {
            var modal = parm.Adapt<MmVendor>().ToUpdate(HttpContext);
            var response = _MmVendorService.UpdateMmVendor(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除销售商
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:vendor:delete")]
        [Log(Title = "销售商", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmVendor([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MmVendorService.Delete(idArr, "删除销售商"));
        }

        /// <summary>
        /// 导出销售商
        /// </summary>
        /// <returns></returns>
        [Log(Title = "销售商导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:vendor:export")]
        public IActionResult Export([FromQuery] MmVendorQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MmVendorService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "销售商", "销售商");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入销售商
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "销售商导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:vendor:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<MmVendorDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmVendorDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmVendorService.ImportMmVendor(list.Adapt<List<MmVendor>>()));
        }

        /// <summary>
        /// 销售商
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "销售商模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmVendorImportTpl>() { }, "MmVendor_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}