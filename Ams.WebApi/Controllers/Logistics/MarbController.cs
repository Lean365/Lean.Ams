using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 物料信息
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 11:34:57)
    /// </summary>
    [Verify]
    [Route("logistics/Marb")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MarbController : BaseController
    {
        /// <summary>
        /// 物料信息接口
        /// </summary>
        private readonly IMarbService _MarbService;

        public MarbController(IMarbService MarbService)
        {
            _MarbService = MarbService;
        }

        /// <summary>
        /// 查询物料信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:marb:list")]
        public IActionResult QueryMarb([FromQuery] MarbQueryDto parm)
        {
            var response = _MarbService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询物料信息详情
        /// </summary>
        /// <param name="MmSFID"></param>
        /// <returns></returns>
        [HttpGet("{MmSFID}")]
        [ActionPermissionFilter(Permission = "mm:marb:query")]
        public IActionResult GetMarb(long MmSFID)
        {
            var response = _MarbService.GetInfo(MmSFID);
            
            var info = response.Adapt<MarbDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加物料信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:marb:add")]
        [Log(Title = "物料信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMarb([FromBody] MarbDto parm)
        {
            var modal = parm.Adapt<Marb>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_MarbService.CheckEntryUnique(parm.MmPlnt.ToString()+ parm.MmMatItem.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)物料信息 '{parm.MmPlnt.ToString() +","+ parm.MmMatItem.ToString()}'失败(failed)，输入的(The entered)物料信息已存在(already exists)"));
            }
            var response = _MarbService.AddMarb(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新物料信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:marb:edit")]
        [Log(Title = "物料信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMarb([FromBody] MarbDto parm)
        {
            var modal = parm.Adapt<Marb>().ToUpdate(HttpContext);
            var response = _MarbService.UpdateMarb(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除物料信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:marb:delete")]
        [Log(Title = "物料信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMarb([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MarbService.Delete(idArr, "删除物料信息"));
        }

        /// <summary>
        /// 导出物料信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "物料信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:marb:export")]
        public IActionResult Export([FromQuery] MarbQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MarbService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "物料信息", "物料信息","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入物料信息
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "物料信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:marb:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MarbDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MarbDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MarbService.ImportMarb(list.Adapt<List<Marb>>()));
        }

        /// <summary>
        /// 物料信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "物料信息模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MarbDto>() { }, "MarbTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}