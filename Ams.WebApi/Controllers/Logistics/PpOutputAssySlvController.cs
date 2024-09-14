using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 组立明细
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:52
    /// </summary>
    [Verify]
    [Route("Logistics/PpOutputAssySlv")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOutputAssySlvController : BaseController
    {
        /// <summary>
        /// 组立明细接口
        /// </summary>
        private readonly IPpOutputAssySlvService _PpOutputAssySlvService;

        public PpOutputAssySlvController(IPpOutputAssySlvService PpOutputAssySlvService)
        {
            _PpOutputAssySlvService = PpOutputAssySlvService;
        }

        /// <summary>
        /// 查询组立明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputassyslv:list")]
        public IActionResult QueryPpOutputAssySlv([FromQuery] PpOutputAssySlvQueryDto parm)
        {
            var response = _PpOutputAssySlvService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询组立明细详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:outputassyslv:query")]
        public IActionResult GetPpOutputAssySlv(long Id)
        {
            var response = _PpOutputAssySlvService.GetInfo(Id);
            
            var info = response.Adapt<PpOutputAssySlvDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加组立明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputassyslv:add")]
        [Log(Title = "组立明细", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpOutputAssySlv([FromBody] PpOutputAssySlvDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputAssySlvService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增组立明细 '{parm.Id}'失败(Add failed)，输入的组立明细已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOutputAssySlv>().ToCreate(HttpContext);

            var response = _PpOutputAssySlvService.AddPpOutputAssySlv(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新组立明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputassyslv:edit")]
        [Log(Title = "组立明细", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpOutputAssySlv([FromBody] PpOutputAssySlvDto parm)
        {
            var modal = parm.Adapt<PpOutputAssySlv>().ToUpdate(HttpContext);
            var response = _PpOutputAssySlvService.UpdatePpOutputAssySlv(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除组立明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputassyslv:delete")]
        [Log(Title = "组立明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputAssySlv([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOutputAssySlvService.Delete(idArr, "删除组立明细"));
        }

        /// <summary>
        /// 导出组立明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "组立明细导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputassyslv:export")]
        public IActionResult Export([FromQuery] PpOutputAssySlvQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOutputAssySlvService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "组立明细", "组立明细");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入组立明细
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "组立明细导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:outputassyslv:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpOutputAssySlvDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOutputAssySlvDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOutputAssySlvService.ImportPpOutputAssySlv(list.Adapt<List<PpOutputAssySlv>>()));
        }

        /// <summary>
        /// 组立明细
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "组立明细模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOutputAssySlvImportTpl>() { }, "PpOutputAssySlv_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}