using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 供应商信息
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:22:58
    /// </summary>
    [Verify]
    [Route("Logistics/MmSupplier")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MmSupplierController : BaseController
    {
        /// <summary>
        /// 供应商信息接口
        /// </summary>
        private readonly IMmSupplierService _MmSupplierService;

        public MmSupplierController(IMmSupplierService MmSupplierService)
        {
            _MmSupplierService = MmSupplierService;
        }

        /// <summary>
        /// 查询供应商信息列表
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
        /// 查询供应商信息详情
        /// </summary>
        /// <param name="SuSfId"></param>
        /// <returns></returns>
        [HttpGet("{SuSfId}")]
        [ActionPermissionFilter(Permission = "mm:supplier:query")]
        public IActionResult GetMmSupplier(long SuSfId)
        {
            var response = _MmSupplierService.GetInfo(SuSfId);
            
            var info = response.Adapt<MmSupplierDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加供应商信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:supplier:add")]
        [Log(Title = "供应商信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmSupplier([FromBody] MmSupplierDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmSupplierService.CheckInputUnique(parm.SuSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增供应商信息 '{parm.SuSfId}'失败(Add failed)，输入的供应商信息已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<MmSupplier>().ToCreate(HttpContext);

            var response = _MmSupplierService.AddMmSupplier(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新供应商信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:supplier:edit")]
        [Log(Title = "供应商信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmSupplier([FromBody] MmSupplierDto parm)
        {
            var modal = parm.Adapt<MmSupplier>().ToUpdate(HttpContext);
            var response = _MmSupplierService.UpdateMmSupplier(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除供应商信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:supplier:delete")]
        [Log(Title = "供应商信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmSupplier([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MmSupplierService.Delete(idArr, "删除供应商信息"));
        }

        /// <summary>
        /// 导出供应商信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "供应商信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
            var result = ExportExcelMini(list, "供应商信息", "供应商信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "供应商信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:supplier:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MmSupplierDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmSupplierDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmSupplierService.ImportMmSupplier(list.Adapt<List<MmSupplier>>()));
        }

        /// <summary>
        /// 供应商信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "供应商信息模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmSupplierImportTpl>() { }, "MmSupplier_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}