using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 部门消耗
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:47:09
    /// </summary>
    [Verify]
    [Route("Accounting/FicoDeptConsuming")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoDeptConsumingController : BaseController
    {
        /// <summary>
        /// 部门消耗接口
        /// </summary>
        private readonly IFicoDeptConsumingService _FicoDeptConsumingService;

        public FicoDeptConsumingController(IFicoDeptConsumingService FicoDeptConsumingService)
        {
            _FicoDeptConsumingService = FicoDeptConsumingService;
        }

        /// <summary>
        /// 查询部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:list")]
        public IActionResult QueryFicoDeptConsuming([FromQuery] FicoDeptConsumingQueryDto parm)
        {
            var response = _FicoDeptConsumingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询部门消耗详情
        /// </summary>
        /// <param name="DcSFID"></param>
        /// <returns></returns>
        [HttpGet("{DcSFID}")]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:query")]
        public IActionResult GetFicoDeptConsuming(long DcSFID)
        {
            var response = _FicoDeptConsumingService.GetInfo(DcSFID);
            
            var info = response.Adapt<FicoDeptConsumingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 导出部门消耗
        /// </summary>
        /// <returns></returns>
        [Log(Title = "部门消耗", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:export")]
        public IActionResult Export([FromQuery] FicoDeptConsumingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoDeptConsumingService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "部门消耗", "部门消耗");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "部门消耗导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:deptconsuming:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoDeptConsumingDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoDeptConsumingDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoDeptConsumingService.ImportFicoDeptConsuming(list.Adapt<List<FicoDeptConsuming>>()));
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
            var result = DownloadImportTemplate(new List<FicoDeptConsumingDto>() { }, "FicoDeptConsuming");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}