using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 组立
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:43:00
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcSlaveAssy")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcSlaveAssyController : BaseController
    {
        /// <summary>
        /// 组立接口
        /// </summary>
        private readonly IPpEcSlaveAssyService _PpEcSlaveAssyService;

        public PpEcSlaveAssyController(IPpEcSlaveAssyService PpEcSlaveAssyService)
        {
            _PpEcSlaveAssyService = PpEcSlaveAssyService;
        }

        /// <summary>
        /// 查询组立列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslaveassy:list")]
        public IActionResult QueryPpEcSlaveAssy([FromQuery] PpEcSlaveAssyQueryDto parm)
        {
            var response = _PpEcSlaveAssyService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询组立详情
        /// </summary>
        /// <param name="AssySfId"></param>
        /// <returns></returns>
        [HttpGet("{AssySfId}")]
        [ActionPermissionFilter(Permission = "pp:ecslaveassy:query")]
        public IActionResult GetPpEcSlaveAssy(long AssySfId)
        {
            var response = _PpEcSlaveAssyService.GetInfo(AssySfId);
            
            var info = response.Adapt<PpEcSlaveAssyDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加组立
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslaveassy:add")]
        [Log(Title = "组立", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlaveAssy([FromBody] PpEcSlaveAssyDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlaveAssyService.CheckInputUnique(parm.AssySfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增组立 '{parm.AssySfId}'失败(Add failed)，输入的组立已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcSlaveAssy>().ToCreate(HttpContext);

            var response = _PpEcSlaveAssyService.AddPpEcSlaveAssy(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新组立
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslaveassy:edit")]
        [Log(Title = "组立", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlaveAssy([FromBody] PpEcSlaveAssyDto parm)
        {
            var modal = parm.Adapt<PpEcSlaveAssy>().ToUpdate(HttpContext);
            var response = _PpEcSlaveAssyService.UpdatePpEcSlaveAssy(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除组立
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslaveassy:delete")]
        [Log(Title = "组立", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlaveAssy([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcSlaveAssyService.Delete(idArr, "删除组立"));
        }

        /// <summary>
        /// 导出组立
        /// </summary>
        /// <returns></returns>
        [Log(Title = "组立", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslaveassy:export")]
        public IActionResult Export([FromQuery] PpEcSlaveAssyQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcSlaveAssyService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "组立", "组立");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "组立导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecslaveassy:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpEcSlaveAssyDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcSlaveAssyDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcSlaveAssyService.ImportPpEcSlaveAssy(list.Adapt<List<PpEcSlaveAssy>>()));
        }

        /// <summary>
        /// 组立导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "组立模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcSlaveAssyImportTpl>() { }, "PpEcSlaveAssy_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}