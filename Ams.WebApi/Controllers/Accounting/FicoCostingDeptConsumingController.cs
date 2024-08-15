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
    /// @Date: 2024/8/9 12:03:53
    /// </summary>
    [Verify]
    [Route("Accounting/FicoCostingDeptConsuming")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoCostingDeptConsumingController : BaseController
    {
        /// <summary>
        /// 部门消耗接口
        /// </summary>
        private readonly IFicoCostingDeptConsumingService _FicoCostingDeptConsumingService;

        public FicoCostingDeptConsumingController(IFicoCostingDeptConsumingService FicoCostingDeptConsumingService)
        {
            _FicoCostingDeptConsumingService = FicoCostingDeptConsumingService;
        }

        /// <summary>
        /// 查询部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:costingdeptconsuming:list")]
        public IActionResult QueryFicoCostingDeptConsuming([FromQuery] FicoCostingDeptConsumingQueryDto parm)
        {
            var response = _FicoCostingDeptConsumingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询部门消耗详情
        /// </summary>
        /// <param name="DcSfId"></param>
        /// <returns></returns>
        [HttpGet("{DcSfId}")]
        [ActionPermissionFilter(Permission = "fico:costingdeptconsuming:query")]
        public IActionResult GetFicoCostingDeptConsuming(long DcSfId)
        {
            var response = _FicoCostingDeptConsumingService.GetInfo(DcSfId);
            
            var info = response.Adapt<FicoCostingDeptConsumingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加部门消耗
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:costingdeptconsuming:add")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoCostingDeptConsuming([FromBody] FicoCostingDeptConsumingDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoCostingDeptConsumingService.CheckInputUnique(parm.DcSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增部门消耗 '{parm.DcSfId}'失败(Add failed)，输入的部门消耗已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoCostingDeptConsuming>().ToCreate(HttpContext);

            var response = _FicoCostingDeptConsumingService.AddFicoCostingDeptConsuming(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新部门消耗
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:costingdeptconsuming:edit")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoCostingDeptConsuming([FromBody] FicoCostingDeptConsumingDto parm)
        {
            var modal = parm.Adapt<FicoCostingDeptConsuming>().ToUpdate(HttpContext);
            var response = _FicoCostingDeptConsumingService.UpdateFicoCostingDeptConsuming(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除部门消耗
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:costingdeptconsuming:delete")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoCostingDeptConsuming([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoCostingDeptConsumingService.Delete(idArr, "删除部门消耗"));
        }

        /// <summary>
        /// 导出部门消耗
        /// </summary>
        /// <returns></returns>
        [Log(Title = "部门消耗", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:costingdeptconsuming:export")]
        public IActionResult Export([FromQuery] FicoCostingDeptConsumingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoCostingDeptConsumingService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "fico:costingdeptconsuming:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoCostingDeptConsumingDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoCostingDeptConsumingDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoCostingDeptConsumingService.ImportFicoCostingDeptConsuming(list.Adapt<List<FicoCostingDeptConsuming>>()));
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
            var result = DownloadImportTemplate(new List<FicoCostingDeptConsumingImportTpl>() { }, "FicoCostingDeptConsuming_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}