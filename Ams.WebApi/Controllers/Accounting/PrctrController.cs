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
    /// 利润中心
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 17:18:00)
    /// </summary>
    [Verify]
    [Route("accounting/Prctr")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class PrctrController : BaseController
    {
        /// <summary>
        /// 利润中心接口
        /// </summary>
        private readonly IPrctrService _PrctrService;

        public PrctrController(IPrctrService PrctrService)
        {
            _PrctrService = PrctrService;
        }

        /// <summary>
        /// 查询利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:prctr:list")]
        public IActionResult QueryPrctr([FromQuery] PrctrQueryDto parm)
        {
            var response = _PrctrService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询利润中心详情
        /// </summary>
        /// <param name="FpSFID"></param>
        /// <returns></returns>
        [HttpGet("{FpSFID}")]
        [ActionPermissionFilter(Permission = "fico:prctr:query")]
        public IActionResult GetPrctr(long FpSFID)
        {
            var response = _PrctrService.GetInfo(FpSFID);
            
            var info = response.Adapt<PrctrDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加利润中心
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:prctr:add")]
        [Log(Title = "利润中心", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPrctr([FromBody] PrctrDto parm)
        {
            var modal = parm.Adapt<Prctr>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_PrctrService.CheckEntryUnique(parm.FpSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)利润中心 '{parm.FpSFID}'失败(failed)，输入的(The entered)利润中心已存在(already exists)"));
            }
            var response = _PrctrService.AddPrctr(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新利润中心
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:prctr:edit")]
        [Log(Title = "利润中心", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePrctr([FromBody] PrctrDto parm)
        {
            var modal = parm.Adapt<Prctr>().ToUpdate(HttpContext);
            var response = _PrctrService.UpdatePrctr(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除利润中心
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:prctr:delete")]
        [Log(Title = "利润中心", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePrctr([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PrctrService.Delete(idArr, "删除利润中心"));
        }

        /// <summary>
        /// 导出利润中心
        /// </summary>
        /// <returns></returns>
        [Log(Title = "利润中心", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:prctr:export")]
        public IActionResult Export([FromQuery] PrctrQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PrctrService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "利润中心", "利润中心","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入利润中心
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "利润中心导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:prctr:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PrctrDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PrctrDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PrctrService.ImportPrctr(list.Adapt<List<Prctr>>()));
        }

        /// <summary>
        /// 利润中心导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "利润中心模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PrctrDto>() { }, "PrctrTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}