using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 供应商
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:53
    /// </summary>
    [Verify]
    [Route("Logistics/MmSupplier")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MmSupplierController : BaseController
    {
        /// <summary>
        /// 供应商接口
        /// </summary>
        private readonly IMmSupplierService _MmSupplierService;

        public MmSupplierController(IMmSupplierService MmSupplierService)
        {
            _MmSupplierService = MmSupplierService;
        }

        /// <summary>
        /// 查询供应商列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:supplier:list")]
        public IActionResult QueryMmSupplier([FromQuery] MmSupplierQueryDto parm)
        {
            var response = _MmSupplierService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询供应商详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "mm:supplier:query")]
        public IActionResult GetMmSupplier(long Id)
        {
            var response = _MmSupplierService.GetInfo(Id);
            
            var info = response.Adapt<MmSupplierDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:supplier:add")]
        [Log(Title = "供应商", BusinessType = BusinessType.ADD)]
        public IActionResult AddMmSupplier([FromBody] MmSupplierDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmSupplierService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增供应商 '{parm.Id}'失败(Add failed)，输入的供应商已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<MmSupplier>().ToCreate(HttpContext);

            var response = _MmSupplierService.AddMmSupplier(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新供应商
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:supplier:edit")]
        [Log(Title = "供应商", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateMmSupplier([FromBody] MmSupplierDto parm)
        {
            var modal = parm.Adapt<MmSupplier>().ToUpdate(HttpContext);
            var response = _MmSupplierService.UpdateMmSupplier(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:supplier:delete")]
        [Log(Title = "供应商", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmSupplier([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MmSupplierService.Delete(idArr, "删除供应商"));
        }

        /// <summary>
        /// 导出供应商
        /// </summary>
        /// <returns></returns>
        [Log(Title = "供应商导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:supplier:export")]
        public IActionResult Export([FromQuery] MmSupplierQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MmSupplierService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "供应商", "供应商");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入供应商
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "供应商导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:supplier:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<MmSupplierDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmSupplierDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmSupplierService.ImportMmSupplier(list.Adapt<List<MmSupplier>>()));
        }

        /// <summary>
        /// 供应商
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "供应商模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmSupplierImportTpl>() { }, "MmSupplier_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}