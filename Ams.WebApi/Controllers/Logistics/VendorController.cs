using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 厂商信息
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 16:26:50)
    /// </summary>
    [Verify]
    [Route("logistics/Vendor")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class VendorController : BaseController
    {
        /// <summary>
        /// 厂商信息接口
        /// </summary>
        private readonly IVendorService _VendorService;

        public VendorController(IVendorService VendorService)
        {
            _VendorService = VendorService;
        }

        /// <summary>
        /// 查询厂商信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:vendor:list")]
        public IActionResult QueryVendor([FromQuery] VendorQueryDto parm)
        {
            var response = _VendorService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询厂商信息详情
        /// </summary>
        /// <param name="VeSFID"></param>
        /// <returns></returns>
        [HttpGet("{VeSFID}")]
        [ActionPermissionFilter(Permission = "mm:vendor:query")]
        public IActionResult GetVendor(long VeSFID)
        {
            var response = _VendorService.GetInfo(VeSFID);
            
            var info = response.Adapt<VendorDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加厂商信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:vendor:add")]
        [Log(Title = "厂商信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddVendor([FromBody] VendorDto parm)
        {
            var modal = parm.Adapt<Vendor>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_VendorService.CheckEntryUnique(parm.VeSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)厂商信息 '{parm.VeSFID}'失败(failed)，输入的(The entered)厂商信息已存在(already exists)"));
            }
            var response = _VendorService.AddVendor(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新厂商信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:vendor:edit")]
        [Log(Title = "厂商信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateVendor([FromBody] VendorDto parm)
        {
            var modal = parm.Adapt<Vendor>().ToUpdate(HttpContext);
            var response = _VendorService.UpdateVendor(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除厂商信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:vendor:delete")]
        [Log(Title = "厂商信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteVendor([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_VendorService.Delete(idArr, "删除厂商信息"));
        }

        /// <summary>
        /// 导出厂商信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "厂商信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:vendor:export")]
        public IActionResult Export([FromQuery] VendorQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _VendorService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "厂商信息", "厂商信息","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入厂商信息
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "厂商信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:vendor:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<VendorDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<VendorDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_VendorService.ImportVendor(list.Adapt<List<Vendor>>()));
        }

        /// <summary>
        /// 厂商信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "厂商信息模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<VendorDto>() { }, "VendorTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}