using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// Pur设变
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 14:43:11
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlavePur")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlavePurController : BaseController
    {
        /// <summary>
        /// Pur设变接口
        /// </summary>
        private readonly IPpEcSlavePurService _PpEcSlavePurService;

        public PpEcSlavePurController(IPpEcSlavePurService PpEcSlavePurService)
        {
            _PpEcSlavePurService = PpEcSlavePurService;
        }

        /// <summary>
        /// 查询Pur设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslavepur:list")]
        public IActionResult QueryPpEcSlavePur([FromQuery] PpEcSlavePurQueryDto parm)
        {
            var response = _PpEcSlavePurService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询Pur设变详情
        /// </summary>
        /// <param name="PurSfId"></param>
        /// <returns></returns>
        [HttpGet("{PurSfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslavepur:query")]
        public IActionResult GetPpEcSlavePur(long PurSfId)
        {
            var response = _PpEcSlavePurService.GetInfo(PurSfId);
            
            var info = response.Adapt<PpEcSlavePurDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加Pur设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslavepur:add")]
        [Log(Title = "Pur设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlavePur([FromBody] PpEcSlavePurDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlavePurService.CheckInputUnique(parm.PurSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增Pur设变 '{parm.PurSfId}'失败(Add failed)，输入的Pur设变已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlavePur>().ToCreate(HttpContext);

            var response = _PpEcSlavePurService.AddPpEcSlavePur(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新Pur设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslavepur:edit")]
        [Log(Title = "Pur设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlavePur([FromBody] PpEcSlavePurDto parm)
        {
            var modal = parm.Adapt<PpEcSlavePur>().ToUpdate(HttpContext);
            var response = _PpEcSlavePurService.UpdatePpEcSlavePur(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除Pur设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslavepur:delete")]
        [Log(Title = "Pur设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlavePur([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlavePurService.Delete(idArr, "删除Pur设变"));
        }

        /// <summary>
        /// 导出Pur设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "Pur设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslavepur:export")]
        public IActionResult Export([FromQuery] PpEcSlavePurQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlavePurService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "Pur设变", "Pur设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "Pur设变导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslavepur:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlavePurDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlavePurDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlavePurService.ImportPpEcSlavePur(list.Adapt<List<PpEcSlavePur>>()));
        }

        /// <summary>
        /// Pur设变导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "Pur设变模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlavePurImportTpl>() { }, "PpEcSlavePur_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}