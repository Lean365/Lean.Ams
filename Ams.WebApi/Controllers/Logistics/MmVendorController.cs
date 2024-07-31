using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 厂商信息
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:23:27
    /// </summary>
    [Verify]
    [Route("Logistics/MmVendor")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MmVendorController : BaseController
    {
        /// <summary>
        /// 厂商信息接口
        /// </summary>
        private readonly IMmVendorService _MmVendorService;

        public MmVendorController(IMmVendorService MmVendorService)
        {
            _MmVendorService = MmVendorService;
        }

        /// <summary>
        /// 查询厂商信息列表
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
        /// 查询厂商信息详情
        /// </summary>
        /// <param name="VeSfId"></param>
        /// <returns></returns>
        [HttpGet("{VeSfId}")]
        [ActionPermissionFilter(Permission = "mm:vendor:query")]
        public IActionResult GetMmVendor(long VeSfId)
        {
            var response = _MmVendorService.GetInfo(VeSfId);
            
            var info = response.Adapt<MmVendorDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加厂商信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:vendor:add")]
        [Log(Title = "厂商信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmVendor([FromBody] MmVendorDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmVendorService.CheckInputUnique(parm.VeSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增厂商信息 '{parm.VeSfId}'失败(Add failed)，输入的厂商信息已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<MmVendor>().ToCreate(HttpContext);

            var response = _MmVendorService.AddMmVendor(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新厂商信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:vendor:edit")]
        [Log(Title = "厂商信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmVendor([FromBody] MmVendorDto parm)
        {
            var modal = parm.Adapt<MmVendor>().ToUpdate(HttpContext);
            var response = _MmVendorService.UpdateMmVendor(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除厂商信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:vendor:delete")]
        [Log(Title = "厂商信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmVendor([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MmVendorService.Delete(idArr, "删除厂商信息"));
        }

        /// <summary>
        /// 导出厂商信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "厂商信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
            var result = ExportExcelMini(list, "厂商信息", "厂商信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "厂商信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:vendor:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MmVendorDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmVendorDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmVendorService.ImportMmVendor(list.Adapt<List<MmVendor>>()));
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
            var result = DownloadImportTemplate(new List<MmVendorImportTpl>() { }, "MmVendor_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}