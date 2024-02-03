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
    /// 物料评估
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 15:30:16)
    /// </summary>
    [Verify]
    [Route("accounting/Mbew")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class MbewController : BaseController
    {
        /// <summary>
        /// 物料评估接口
        /// </summary>
        private readonly IMbewService _MbewService;

        public MbewController(IMbewService MbewService)
        {
            _MbewService = MbewService;
        }

        /// <summary>
        /// 查询物料评估列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:mbew:list")]
        public IActionResult QueryMbew([FromQuery] MbewQueryDto parm)
        {
            var response = _MbewService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询物料评估详情
        /// </summary>
        /// <param name="MbewSFID"></param>
        /// <returns></returns>
        [HttpGet("{MbewSFID}")]
        [ActionPermissionFilter(Permission = "mm:mbew:query")]
        public IActionResult GetMbew(long MbewSFID)
        {
            var response = _MbewService.GetInfo(MbewSFID);
            
            var info = response.Adapt<MbewDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加物料评估
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:mbew:add")]
        [Log(Title = "物料评估", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMbew([FromBody] MbewDto parm)
        {
            var modal = parm.Adapt<Mbew>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_MbewService.CheckEntryUnique(parm.MbewSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)物料评估 '{parm.MbewSFID}'失败(failed)，输入的(The entered)物料评估已存在(already exists)"));
            }
            var response = _MbewService.AddMbew(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新物料评估
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:mbew:edit")]
        [Log(Title = "物料评估", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMbew([FromBody] MbewDto parm)
        {
            var modal = parm.Adapt<Mbew>().ToUpdate(HttpContext);
            var response = _MbewService.UpdateMbew(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除物料评估
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:mbew:delete")]
        [Log(Title = "物料评估", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMbew([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MbewService.Delete(idArr, "删除物料评估"));
        }

        /// <summary>
        /// 导出物料评估
        /// </summary>
        /// <returns></returns>
        [Log(Title = "物料评估", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:mbew:export")]
        public IActionResult Export([FromQuery] MbewQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MbewService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "物料评估", "物料评估","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入物料评估
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "物料评估导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:mbew:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MbewDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MbewDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MbewService.ImportMbew(list.Adapt<List<Mbew>>()));
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
            var result = DownloadImportTemplate(new List<MbewDto>() { }, "MbewTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}