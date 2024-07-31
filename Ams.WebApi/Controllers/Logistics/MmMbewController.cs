using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 物料评估
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:50:11
    /// </summary>
    [Verify]
    [Route("Logistics/MmMbew")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MmMbewController : BaseController
    {
        /// <summary>
        /// 物料评估接口
        /// </summary>
        private readonly IMmMbewService _MmMbewService;

        public MmMbewController(IMmMbewService MmMbewService)
        {
            _MmMbewService = MmMbewService;
        }

        /// <summary>
        /// 查询物料评估列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:mbew:list")]
        public IActionResult QueryMmMbew([FromQuery] MmMbewQueryDto parm)
        {
            var response = _MmMbewService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询物料评估详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        [HttpGet("{SfId}")]
        [ActionPermissionFilter(Permission = "mm:mbew:query")]
        public IActionResult GetMmMbew(long SfId)
        {
            var response = _MmMbewService.GetInfo(SfId);
            
            var info = response.Adapt<MmMbewDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加物料评估
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:mbew:add")]
        [Log(Title = "物料评估", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmMbew([FromBody] MmMbewDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmMbewService.CheckInputUnique(parm.SfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增物料评估 '{parm.SfId}'失败(Add failed)，输入的物料评估已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<MmMbew>().ToCreate(HttpContext);

            var response = _MmMbewService.AddMmMbew(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新物料评估
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:mbew:edit")]
        [Log(Title = "物料评估", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmMbew([FromBody] MmMbewDto parm)
        {
            var modal = parm.Adapt<MmMbew>().ToUpdate(HttpContext);
            var response = _MmMbewService.UpdateMmMbew(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除物料评估
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:mbew:delete")]
        [Log(Title = "物料评估", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMbew([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MmMbewService.Delete(idArr, "删除物料评估"));
        }

        /// <summary>
        /// 导出物料评估
        /// </summary>
        /// <returns></returns>
        [Log(Title = "物料评估", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:mbew:export")]
        public IActionResult Export([FromQuery] MmMbewQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MmMbewService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "物料评估", "物料评估");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "物料评估导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:mbew:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MmMbewDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmMbewDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmMbewService.ImportMmMbew(list.Adapt<List<MmMbew>>()));
        }

        /// <summary>
        /// 物料评估导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "物料评估模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmMbewImportTpl>() { }, "MmMbew_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}