using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 部门消耗
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 14:46:50)
    /// </summary>
    [Verify]
    [Route("accounting/DeptConsuming")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class DeptConsumingController : BaseController
    {
        /// <summary>
        /// 部门消耗接口
        /// </summary>
        private readonly IDeptConsumingService _DeptConsumingService;

        public DeptConsumingController(IDeptConsumingService DeptConsumingService)
        {
            _DeptConsumingService = DeptConsumingService;
        }

        /// <summary>
        /// 查询部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:list")]
        public IActionResult QueryDeptConsuming([FromQuery] DeptConsumingQueryDto parm)
        {
            var response = _DeptConsumingService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询部门消耗详情
        /// </summary>
        /// <param name="DcSFID"></param>
        /// <returns></returns>
        [HttpGet("{DcSFID}")]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:query")]
        public IActionResult GetDeptConsuming(long DcSFID)
        {
            var response = _DeptConsumingService.GetInfo(DcSFID);
            
            var info = response.Adapt<DeptConsumingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加部门消耗
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:add")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.INSERT)]
        public IActionResult AddDeptConsuming([FromBody] DeptConsumingDto parm)
        {
            var modal = parm.Adapt<DeptConsuming>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_DeptConsumingService.CheckEntryUnique(parm.DcSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)部门消耗 '{parm.DcSFID}'失败(failed)，输入的(The entered)部门消耗已存在(already exists)"));
            }
            var response = _DeptConsumingService.AddDeptConsuming(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新部门消耗
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:edit")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateDeptConsuming([FromBody] DeptConsumingDto parm)
        {
            var modal = parm.Adapt<DeptConsuming>().ToUpdate(HttpContext);
            var response = _DeptConsumingService.UpdateDeptConsuming(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除部门消耗
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:delete")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteDeptConsuming([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_DeptConsumingService.Delete(idArr, "删除部门消耗"));
        }

        /// <summary>
        /// 导出部门消耗
        /// </summary>
        /// <returns></returns>
        [Log(Title = "部门消耗", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:export")]
        public IActionResult Export([FromQuery] DeptConsumingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _DeptConsumingService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "部门消耗", "部门消耗","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入部门消耗
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "部门消耗导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<DeptConsumingDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<DeptConsumingDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_DeptConsumingService.ImportDeptConsuming(list.Adapt<List<DeptConsuming>>()));
        }

        /// <summary>
        /// 部门消耗导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "部门消耗模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<DeptConsumingDto>() { }, "DeptConsumingTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}